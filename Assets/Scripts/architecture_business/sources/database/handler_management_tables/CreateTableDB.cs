using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface CreateTableDB {

    Task<bool> createTables(List<Type> entities);

}

public class CreateTableDBImpl : CreateTableDB
{
    //static variable
    private static CreateTableDBImpl instance;

    //static method
    public static CreateTableDBImpl getInstance(ConectionDBSqlite conectionDB) {
        if (instance == null) {
            instance = new CreateTableDBImpl();
            instance.conectionDB = conectionDB;
        }
        return instance;
    }

    private ConectionDBSqlite conectionDB;

    private CreateTableDBImpl(){}

    //public method
    public async Task<bool> createTables(List<Type> entities)
    {
        if (entities == null || entities.Count == 0) return false;
        string queryToExecute = generateQueryCreationTables(entities: entities);
        Debug.Log(queryToExecute);
        return true;
    }

    //private methods
    private string generateQueryCreationTables(List<Type> entities)
    {
        StringBuilder queryCreation = new StringBuilder("");

        foreach (Type entity in entities)
        {
            queryCreation.Append($"{generateQueryCreationTable(entity: entity)}");

            if (entities.IndexOf(entity) != entities.Count - 1)
            {
                queryCreation.Append(";\n");
            }
        }
        return queryCreation.ToString();
    }

    private string generateQueryCreationTable(Type entity)
    {
        int currentIndex = 0;
        FieldInfo[] currentFields = entity.GetFields();
        StringBuilder queryCreationTable = new StringBuilder($"CREATE TABLE IF NOT EXISTS {entity.Name} ( ");
        foreach (FieldInfo field in currentFields)
        {

            var listPrimaryKeys = (PrimaryKey[])field.GetCustomAttributes(typeof(PrimaryKey), true);
            var listNotNull = (NotNull[])field.GetCustomAttributes(typeof(NotNull), true);
            string column = string.Format(
                "{0} {1} {2} {3}",
                field.Name,
                getTypeColumn(field: field),
                listNotNull.Length == 0 ? "" : "NOT NULL",
                listPrimaryKeys.Length == 0 ? "" : "PRIMARY KEY"
            );

            queryCreationTable.Append(column);

            if (currentIndex < currentFields.Length - 1)
            {
                queryCreationTable.Append(", ");
            }
            currentIndex += 1;
        }
        queryCreationTable.Append(")");
        return queryCreationTable.ToString();
    }

    private string getTypeColumn(FieldInfo field)
    {
        if (field.FieldType == typeof(long) || field.FieldType == typeof(long?)) return "INTEGER";
        if (field.FieldType == typeof(float) || field.FieldType == typeof(float?)) return "REAL";
        if (field.FieldType == typeof(bool) || field.FieldType == typeof(bool?)) return "BLOB";

        return "TEXT";
    }

}
