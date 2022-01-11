using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface SentenceDeleteDB {

    Task<bool> deleteElement<T>(T element) where T : BaseDBEntity;
    Task<bool> deleteElements<T>(List<T> element) where T : BaseDBEntity;
    Task<bool> clearTable<T>() where T : BaseDBEntity;
    Task<bool> deleteElementsWithCondition<T>(List<Condition> conditions) where T : BaseDBEntity;
}

public class SentenceDeleteDBImpl : SentenceDeleteDB
{
    //static variables
    private static SentenceDeleteDBImpl instance;

    //static methods
    public static SentenceDeleteDBImpl getInstance(ConectionDBSqlite conectionDB) {
        if (instance == null) {
            instance = new SentenceDeleteDBImpl();
            instance.conectionDB = conectionDB;
        }
        return instance;
    }

    private ConectionDBSqlite conectionDB;

    private SentenceDeleteDBImpl() { }

    public async Task<bool> clearTable<T>() where T : BaseDBEntity
    {
        string query = createQueryClearTable<T>();
        if (string.IsNullOrEmpty(query)) return false;
        return await conectionDB.startQueryWithOutResponses(query: query);
    }

    public async Task<bool> deleteElement<T>(T element) where T : BaseDBEntity
    {
        string query = createQueryDeleteElement(element: element);
        return await conectionDB.startQueryWithOutResponses(query: query);
    }

    public async Task<bool> deleteElements<T>(List<T> element) where T : BaseDBEntity
    {
        StringBuilder query = new StringBuilder("");
        foreach (T currentElement in element) {
            string queryElement = createQueryDeleteElement(element: currentElement);
            if (string.IsNullOrEmpty(queryElement)) continue;

            query.Append(queryElement);
            if (element.IndexOf(currentElement) < element.Count - 1) {
                query.Append(";\n");
            }
        }
        return await conectionDB.startQueryWithOutResponses(query: query.ToString());
    }

    public async Task<bool> deleteElementsWithCondition<T>(List<Condition> conditions) where T : BaseDBEntity{
        string query = generateQueryDeleteFromTableWithConditions<T>(conditions: conditions);
        return await conectionDB.startQueryWithOutResponses(query: query);
    }

    // private methods

    private string createQueryClearTable<T>() => $"DELETE FROM TABLE {typeof(T)}";

    private string createQueryDeleteElement<T>(T element) {

        Type type = typeof(T);
        FieldInfo[] fields = type.GetFields();
        FieldInfo primaryKey = null;

        foreach (FieldInfo field in fields) {
            var listPrimaryKeys = (PrimaryKey[])field.GetCustomAttributes(typeof(PrimaryKey), true);
            if (listPrimaryKeys == null || listPrimaryKeys.Length == 0) continue;
            primaryKey = field;
        }

        if (primaryKey == null) return "";

        string query = string.Format(
            "DELETE FROM {0} WHERE {1} = {2}",
            typeof(T),
            primaryKey.Name,
            getValueField(field: primaryKey, element: element)
        );

        return query;
    }

    private string getValueField<T>(FieldInfo field, T element) {

        if (field.FieldType == typeof(long) || field.FieldType == typeof(long?)) return $"{field.GetValue(element)}";
        if (field.FieldType == typeof(float) || field.FieldType == typeof(float?)) return $"{field.GetValue(element)}";
        if (field.FieldType == typeof(bool) || field.FieldType == typeof(bool?)) return $"{field.GetValue(element)}";

        return $"\"{field.GetValue(element)}\"";
    }

    private string generateQueryDeleteFromTableWithConditions<T>(List<Condition> conditions) {
        StringBuilder query = new StringBuilder($"DELETE FROM {typeof(T)}");
        if (conditions.Count == 0) {
            return query.ToString();
        }

        query.Append(" WHERE ");
        for (int indexConditions = 0; indexConditions < conditions.Count; indexConditions++) {

            if (string.IsNullOrEmpty(conditions[indexConditions].columnName)) continue;

            query.Append(generateName(condition: conditions[indexConditions]));
            query.Append(getValueFromCondition(condition: conditions[indexConditions]));

        }
        query.Append(";");
        return query.ToString();
    }

    private string generateName(Condition condition) {
        StringBuilder query = new StringBuilder("");
        query.Append($" {condition.columnName} = ");
        return query.ToString();
    }


    private string getValueFromCondition(Condition condition) {
        StringBuilder query = new StringBuilder("");
        if (condition.type == TypeElement.TEXT)
        {
            query.Append($" \"{condition.value}\"");
            return query.ToString();
        }
        query.Append($" {condition.value}");
        return query.ToString();
    }

}