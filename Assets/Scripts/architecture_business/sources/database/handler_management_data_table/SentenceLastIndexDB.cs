using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public interface SentenceLastIndexDB {
    Task<long> getLastIndex<T>();
}
public class SentenceLastIndexDBImpl : SentenceLastIndexDB
{
    //static variables
    private static SentenceLastIndexDBImpl instance;

    //static methods
    public static SentenceLastIndexDB getInstance(ConectionDBSqlite conectionDB) {
        if (instance == null) {
            instance = new SentenceLastIndexDBImpl();
            instance.conectionDB = conectionDB;
        }
        return instance;
    }

    private ConectionDBSqlite conectionDB;

    private SentenceLastIndexDBImpl() { }

    public async Task<long> getLastIndex<T>()
    {
        string currentQuery = generateQuery<T>();
        List<Dictionary<string, object>> mapObject = await conectionDB.startQueryWithResponses(query: currentQuery, nameTable: typeof(T).Name);
        List<T> list = (new ChangeDictionaryToElement<T>()).convertListDictionaryToListElements<T>(listDictionary: mapObject);
        if (list.Count == 0) return 0;

        GetValuesByAttribute<T> getValues = new GetValuesByAttribute<T>();
        getValues.initVariables(element: list[0]);
        return getValues.getPrimaryKey();
    }

    private string generateQuery<T>() {
        Type table = typeof(T);
        string nameTable = table.Name;
        string namePrimaryKey = "";
        FieldInfo[] fields = table.GetFields();

        foreach (FieldInfo currentField in fields) {
            var listPrimaryKeys = (PrimaryKey[])currentField.GetCustomAttributes(typeof(PrimaryKey), true);
            if (listPrimaryKeys.Length == 0) continue;
            namePrimaryKey = currentField.Name;
            break;
        }

        return $"SELECT MAX({namePrimaryKey}) AS {namePrimaryKey} FROM {nameTable}"; 
    }

   
    
}