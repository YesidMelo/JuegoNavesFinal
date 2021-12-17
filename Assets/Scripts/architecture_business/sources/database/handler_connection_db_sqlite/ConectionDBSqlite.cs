using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Mono.Data.Sqlite;

using UnityEngine;

public interface ConectionDBSqlite {

    //Transactions Scripts
    Task<bool> startQueryWithOutResponses(string query);

    Task<object> startQueryWithResponses(string query);

}

public class ConectionDBSqliteImpl : ConectionDBSqlite
{
    //static variables
    private static ConectionDBSqliteImpl instance;

    //static methods
    public static async Task<bool> initInstance(string DBFileName, string applicationDataPath) {
        if (instance != null)  return true;
        instance = new ConectionDBSqliteImpl(DBFileName: DBFileName, applicationDataPath: applicationDataPath);
        await Task.Delay(100);
        return true;
    }

    public static ConectionDBSqliteImpl getInstance() => instance;

    //strings configuration
    private string applicationDataPath;
    private string DBFileName;
    private string nameDirDB = "dbs";

    // paths 
    private string filePathDB;
    private string pathDB;

    //connection
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader dbReader;

    //creator files
    private CustomCreatorFiles creatorFiles = CreatorFilesImpl.getInstance();

    private ConectionDBSqliteImpl(string DBFileName, string applicationDataPath)
    {
        this.DBFileName = DBFileName;
        this.applicationDataPath = applicationDataPath;
        createPathsDB();
        Task.Run(async () => {
            
            await createDatabase();
            
        });
        
    }

    //public methods

    public async Task<bool> startQueryWithOutResponses(string query)
    {
        
        openDB();
        closeDB();
        return true;
    }

    public async Task<object> startQueryWithResponses(string query)
    {
        openDB();
        closeDB();
        return true;
    }

    private async Task<bool> createDatabase()
    {
        bool isCreatedFile = await creatorFiles.createFile(
            rootDir: applicationDataPath,
            fileName: DBFileName,
            nameDir: nameDirDB,
            extentionFile: "sqlite"
        );
        if (isCreatedFile) return false;
        Debug.Log("Finalizo la creacion del archivo .sqlite");
        return true;
    }

    //private methods

    private void createPathsDB() {
        createPathDB();
        createFilePathDB();
    }

    private void createPathDB() {
        pathDB = string.Format(
            "{0}/{1}/{2}.sqlite",
            applicationDataPath,
            nameDirDB,
            DBFileName
        );
    }

    private void createFilePathDB() { 
        filePathDB = $"URI=file:{pathDB}";
        Debug.Log(@filePathDB);
    }

    private bool openDB()
    {
        try
        {

            if (dbConnection == null)
            {
                dbConnection = new SqliteConnection(@filePathDB);
            }
            dbConnection.Open();
            Debug.Log("Se abrio la base de datos");
            return true;
        }
        catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    private bool closeDB()
    {
        try
        {

            if (dbConnection == null) return false;
            dbConnection.Close();
            Debug.Log("Se cerro la base de datos");
            return true;
        }
        catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    
}
