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
    Task<bool> startQueryWithOutResponses(string query, string nameTable = "");

    Task<List<Dictionary<string, object>>> startQueryWithResponses(string query, string nameTable = "");

}

public class ConectionDBSqliteImpl : ConectionDBSqlite
{
    //static variables
    private static ConectionDBSqliteImpl instance;

    //static methods
    public static async Task<bool> initInstance(string DBFileName, string applicationDataPath) {
        if (instance != null)  return true;
        instance = new ConectionDBSqliteImpl(DBFileName: DBFileName, applicationDataPath: applicationDataPath);
        await Task.Delay(1000);
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

    //creator files
    private CustomCreatorFiles creatorFiles = CreatorFilesImpl.getInstance();

    private ConectionDBSqliteImpl(string DBFileName, string applicationDataPath)
    {
        this.DBFileName = DBFileName;
        this.applicationDataPath = applicationDataPath;
        createPathsDB();
        Task.Run(async () => await createDatabase());
    }

    //public methods

    public async Task<bool> startQueryWithOutResponses(string query,string nameTable = "")
    {
        try {
            openDB();
            if (dbConnection == null) return false;
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            dbCommand.ExecuteNonQuery();
            closeDB();
            return true;
        } catch (Exception e) {
            closeDB();
            Debug.LogError(e.Message);
            return false;
        }
    }

    public async Task<List<Dictionary<string, object>>> startQueryWithResponses(string query, string nameTable = "")
    {
        List<Dictionary<string, object>>  listMapObject = new List<Dictionary<string, object>>();
        try {
            
            openDB();

            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            IDataReader dbReader = dbCommand.ExecuteReader();

            
            while (dbReader.Read()) {
                listMapObject.Add(getField(reader: dbReader));
            }

            closeDB();
            return listMapObject;
        }
        catch (Exception e) {
            closeDB();
            Debug.LogError(e.Message);
            return listMapObject;
        }
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

    private void createFilePathDB() => filePathDB = $"URI=file:{pathDB}";

    private Dictionary<string, object> getField(IDataReader reader) {
        Dictionary<string, object> file = new Dictionary<string, object>();

        for (int index = 0; index< reader.FieldCount; index++) {
            file.Add(
                reader.GetName(index),
                getValueFromDB(index: index, reader: reader)
            );
        }
        
        return file;
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
            return true;
        }
        catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    private object getValueFromDB(int index, IDataReader reader) {
        try {
            return getValueInt(index: index, reader: reader);
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }

    private object getValueInt(int index, IDataReader reader) {
        try
        {
            return reader.GetInt32(index);
        }
        catch (Exception e) {
            return getBool(index: index, reader: reader);
        }
    }

    private object getBool(int index, IDataReader reader) {
        try {
            return reader.GetBoolean(index);
        } catch(Exception e) {
            return getFloat(index: index, reader: reader);
        }
    }

    private object getFloat(int index, IDataReader reader) {
        try
        {
            return reader.GetFloat(index);
        }
        catch(Exception e) {
            return getString(index: index, reader: reader);
        }
    }

    private object getString(int index, IDataReader reader) {
        return reader.GetString(index);
    }

}
