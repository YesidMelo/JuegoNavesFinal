using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface UpdateTableDB {
    Task<bool> updateTable<T>(List<Versions<T>> versions) where T : BaseDBEntity;
}

public class UpdateTableDBImpl : UpdateTableDB {

    //static variables
    private static UpdateTableDBImpl instance;

    //static methods
    public static UpdateTableDBImpl getInstance(ConectionDBSqlite conectionDB) {
        if (instance == null) {
            instance = new UpdateTableDBImpl();
            instance.conectionDB = conectionDB;
        }
        return instance;
    }

    private ConectionDBSqlite conectionDB;

    private UpdateTableDBImpl() { }

    //TODO: implementar funcionalidad aqui
    public async Task<bool> updateTable<T>(List<Versions<T>> versions) where T : BaseDBEntity
    {
        return true;
    }

}