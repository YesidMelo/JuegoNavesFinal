using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteTableDB {
    Task<bool> deleteTables(List<Type> entities);
}

public class DeleteTableDBImpl : DeleteTableDB
{

    //static variables
    private static DeleteTableDBImpl instance;

    //static methods
    public static DeleteTableDBImpl getInstance() {
        if (instance == null) {
            instance = new DeleteTableDBImpl();
        }
        return instance;
    }

    private DeleteTableDBImpl() { }

    //public methods
    public async Task<bool> deleteTables(List<Type> entities)
    {
        string queryToDelete = generateQueryDeleteTables(entities: entities);
        Debug.Log(queryToDelete);
        return true;
    }

    //private methods

    private string generateQueryDeleteTables(List<Type> entities) {
        string query = "";
        if (entities == null || entities.Count == 0) return query;
        foreach (Type currentEntity in entities) {
            query += generateQueryDeleteTable(entity: currentEntity);
            if (entities.IndexOf(currentEntity) < entities.Count - 1) {
                query += "; ";
            }
        }
        return query;
    }

    private string generateQueryDeleteTable(Type entity) {
        string query = string.Format(
            "DROP TABLE IF EXISTS {0}",
            entity.Name
        );
        return query;
    }
}