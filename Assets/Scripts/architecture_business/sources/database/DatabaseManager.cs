using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public interface DatabaseManager {

    #region creacion, eliminacion, modificacion tablas
    Task<bool> createTables(List<Type> entities);
    Task<bool> deleteTables(List<Type> entities);
    Task<bool> updateTables<T>(List<Versions<T>> versions) where T : BaseDBEntity;

    #endregion

    #region creacion, actualizacion, modificacion, eliminacion contenido tablas

    Task<bool> insert<T>(T element) where T : BaseDBEntity;
    Task<bool> insertAll<T>(List<T> element) where T : BaseDBEntity;
    Task<List<T>> getElements<T>(List<Condition> conditions) where T : BaseDBEntity;

    Task<bool> deleteElement<T>(T element) where T : BaseDBEntity;
    Task<bool> deleteElements<T>(List<T> element) where T : BaseDBEntity;
    Task<bool> clearTable<T>() where T : BaseDBEntity;

    #endregion


}

public class DatabaseManagerImpl : DatabaseManager
{
   
    //static instance
    private static DatabaseManagerImpl instance;

    //static methods
    public static DatabaseManagerImpl getInstance() {
        if (instance == null) {
            instance = new DatabaseManagerImpl();
        }
        return instance;
    }

    //management tables
    private CreateTableDB createTableDB = CreateTableDBImpl.getInstance();
    private DeleteTableDB deleteTableDB = DeleteTableDBImpl.getInstance();
    private UpdateTableDB updateTableDB = UpdateTableDBImpl.getInstance();

    //management data
    private SencenceSelectDB sencenceSelectDB = SencenceSelectDBImpl.getInstance();
    private SentenceInsertDB sentenceInsertDB = SentenceInsertDBImpl.getInstance();
    private SentenceDeleteDB sentenceDeleteDB = SentenceDeleteDBImpl.getInstance();

    private DatabaseManagerImpl() { }

    #region creacion, actualizacion eliminacion modificacion tablas

    //public methods

    public async Task<bool> createTables(List<Type> entities) => await createTableDB.createTables(entities: entities);

    public async Task<bool> deleteTables(List<Type> entities) => await deleteTableDB.deleteTables(entities: entities);

    public async Task<bool> updateTables<T>(List<Versions<T>> versions) where T : BaseDBEntity
        => await updateTableDB.updateTable(versions: versions);

    #endregion

    
    //public methods

    public async Task<List<T>> getElements<T>(List<Condition> conditions) where T : BaseDBEntity
        => await sencenceSelectDB.getElements<T>(conditions: conditions);

    public async Task<bool> insert<T>(T element) where T : BaseDBEntity
        => await sentenceInsertDB.insert(element: element);

    public async Task<bool> insertAll<T>(List<T> element) where T : BaseDBEntity
        => await sentenceInsertDB.insertAll(elements: element);

    public async Task<bool> deleteElement<T>(T element) where T : BaseDBEntity 
        => await sentenceDeleteDB.deleteElement(element: element);

    public async Task<bool> deleteElements<T>(List<T> element) where T : BaseDBEntity
        => await sentenceDeleteDB.deleteElements(element: element);

    public async Task<bool> clearTable<T>() where T : BaseDBEntity
        => await sentenceDeleteDB.clearTable<T>();
}
