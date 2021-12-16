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
    public static bool initInstance(string DBFileName, string applicationDataPath) {
        if (instance != null)  return true;
        instance = new ConectionDBSqliteImpl(DBFileName: DBFileName, applicationDataPath: applicationDataPath);
        return true;
    }

    public static ConectionDBSqliteImpl getInstance() => instance;

    //strings configuration
    private string applicationDataPath;
    private string DBFileName;
    private string filePath;
    private string pathDB;
    private string strConnectionDbs;
    private string nameDirDB = "dbs";

    //connection
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader dbReader;

    private ConectionDBSqliteImpl(string DBFileName, string applicationDataPath)
    {
        this.DBFileName = DBFileName;
        this.applicationDataPath = applicationDataPath;
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
        if (!createDir()) return false;
        await Task.Delay(200);
        if (!createFile()) return false;
        await Task.Delay(200);

        Debug.Log("Finalizo la creacion del archivo .sqlite");
        return true;
    }

    private bool createDir() {

        string element = string.Format(
            "{0}/{1}",
            applicationDataPath,
            nameDirDB
        );

        if (Directory.Exists(element)) return true;

        try {
            Directory.CreateDirectory(element);
        } catch (Exception e) {
            Debug.Log(e.Message);
            return false;
        }
        return true;
    }

    private bool createFile() {
        this.pathDB = string.Format(
            "{0}/{1}/{2}",
            applicationDataPath,
            nameDirDB,
            DBFileName
        );

        if (File.Exists(path: pathDB)) return true;

        try {
            File.Create(pathDB);
        } catch (Exception e) {
            Debug.Log(e.Message);
            return false;
        }

        this.filePath = @$"file:{pathDB}";
        this.strConnectionDbs = $"URI={filePath}";

        Debug.Log(
           string.Format(
               "pathDB: {0}\nstrConnection: {1}",
               pathDB,
               strConnectionDbs
           )
        );

        return true;
    }

    //private methods

    private bool openDB()
    {
        if (dbConnection == null) { 
            dbConnection = new SqliteConnection(strConnectionDbs);
        }
        dbConnection.Open();
        Debug.Log("Se abrio la base de datos");
        return true;
    }

    private bool closeDB()
    {
        if (dbConnection == null) return false;
        dbConnection.Close();
        Debug.Log("Se cerro la base de datos");
        return true;
    }

    
}
