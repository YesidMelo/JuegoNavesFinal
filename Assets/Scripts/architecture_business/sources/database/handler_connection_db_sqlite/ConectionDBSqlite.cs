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
    public static bool initInstance(
        string pathDB,
        string strConnection,
        string DBFileName
    ) {
        if (instance != null)  return true;
        instance = new ConectionDBSqliteImpl(pathDB: pathDB, strConnection: strConnection, DBFileName: DBFileName);
        return true;
    }

    public static ConectionDBSqliteImpl getInstance() => instance;

    //strings configuration
    private string pathDB;
    private string strConnection;
    private string DBFileName;

    //connection
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader dbReader;

    private ConectionDBSqliteImpl(
        string pathDB,
        string strConnection,
        string DBFileName
    )
    {
        this.pathDB = pathDB;
        this.strConnection = strConnection;
        this.DBFileName = DBFileName;
    }

    //public methods

    public async Task<bool> startQueryWithOutResponses(string query)
    {
        await openDB();
        await closeDB();
        return true;
    }

    public async Task<object> startQueryWithResponses(string query)
    {
        await openDB();
        await closeDB();
        return true;
    }

    //private methods


    private async Task<bool> openDB()
    {
        return true;
    }

    private async Task<bool> closeDB()
    {
        return true;
    }




}
