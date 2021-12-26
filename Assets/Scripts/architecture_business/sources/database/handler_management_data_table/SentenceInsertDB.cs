using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface SentenceInsertDB {
    Task<bool> insert<T>(T element) where T : BaseDBEntity;
    Task<bool> insertAll<T>(List<T> elements) where T : BaseDBEntity;
}

public class SentenceInsertDBImpl : SentenceInsertDB
{
    //static variables
    private static SentenceInsertDBImpl instance;

    //static methods
    public static SentenceInsertDBImpl getInstance(ConectionDBSqlite conectionDB) {
        if (instance == null) {
            instance = new SentenceInsertDBImpl();
            instance.conectionDB = conectionDB;
        }
        return instance;
    }

    private ConectionDBSqlite conectionDB;

    private SentenceInsertDBImpl() { }

    //public methods
    public async Task<bool> insert<T>(T element) where T : BaseDBEntity
    {
        string query = generateQueryInsertElement(element: element);
        return await conectionDB.startQueryWithOutResponses(query: query);
    }

    public async Task<bool> insertAll<T>(List<T> elements) where T : BaseDBEntity
    {
        StringBuilder query = new StringBuilder("");
        foreach (T element in elements) {
            query.Append(generateQueryInsertElement(element: element));
            if (elements.IndexOf(element) < elements.Count - 1) {
                query.Append(";\n");
            }
        }
        return await conectionDB.startQueryWithOutResponses(query: query.ToString());
    }

    //private methods

    private string generateQueryInsertElement<T>(T element) {
        int index = 0;
        Type type = typeof(T);
        FieldInfo[] fields = type.GetFields();
        StringBuilder nameColumns = new StringBuilder("");
        StringBuilder valueColumns = new StringBuilder("");
        
        foreach (FieldInfo field in fields) {
            object currentValue = field.GetValue(element);
            
            if (currentValue == null) {
                index++;
                continue;
            }

            nameColumns.Append($"{field.Name}");
            valueColumns.Append($"{getValueElement(field: field, element: element)}");
            if (index < fields.Length - 1) {
                nameColumns.Append(", ");
                valueColumns.Append(", ");
            }
            index++;
        }

        string query = string.Format(
            "INSERT OR REPLACE INTO {0}({1}) VALUES({2})",
            type.Name,
            nameColumns,
            valueColumns
        );
        return query;
    }

    private string getValueElement<T>(FieldInfo field, T element) {
        if (field.FieldType == typeof(string)) {
            return $"\"{field.GetValue(element)}\"";        
        }

        if (field.FieldType == typeof(DateTime) || field.FieldType == typeof(DateTime?)) {
            DateTime date = (DateTime)field.GetValue(element);
            return $"\"{date.convertToString(format: DateFormats.ISO_8601)}\"";
        }

        if (field.FieldType == typeof(bool?) || field.FieldType == typeof(bool)) {
            bool value = (bool)field.GetValue(element);
            return $"{(value ? 1 : 0 )}";
        }

        return $"{field.GetValue(element)}";
    }

}