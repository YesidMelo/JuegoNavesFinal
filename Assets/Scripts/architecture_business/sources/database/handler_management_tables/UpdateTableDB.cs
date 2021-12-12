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
    public static UpdateTableDBImpl getInstance() {
        if (instance == null) {
            instance = new UpdateTableDBImpl();
        }
        return instance;
    }

    //TODO: implementar funcionalidad aqui
    public async Task<bool> updateTable<T>(List<Versions<T>> versions) where T : BaseDBEntity
    {
        return true;
    }

    private UpdateTableDBImpl() { }
}