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
    Task<long> getLastIndex<T>() where T : BaseDBEntity;

    #endregion


}

public class DatabaseManagerImpl : DatabaseManager
{
   
    //static instance
    private static DatabaseManagerImpl instance;

    //static methods

    public static bool initInstance(ConectionDBSqlite conectionDB) {
        if (instance == null)
        {
            instance = new DatabaseManagerImpl(conectionDB: conectionDB);
        }
        return true;
    }
    public static DatabaseManagerImpl getInstance() => instance;

    //management tables
    private CreateTableDB createTableDB;
    private DeleteTableDB deleteTableDB ;
    private UpdateTableDB updateTableDB ;

    //management data
    private SencenceSelectDB sencenceSelectDB;
    private SentenceInsertDB sentenceInsertDB;
    private SentenceDeleteDB sentenceDeleteDB;
    private SentenceLastIndexDB sentenceLastIndexDB;

    private DatabaseManagerImpl(ConectionDBSqlite conectionDB) {
        
        createTableDB = CreateTableDBImpl.getInstance(conectionDB: conectionDB);
        deleteTableDB = DeleteTableDBImpl.getInstance(conectionDB: conectionDB);
        updateTableDB = UpdateTableDBImpl.getInstance(conectionDB: conectionDB);

        sencenceSelectDB = SencenceSelectDBImpl.getInstance(conectionDB: conectionDB);
        sentenceInsertDB = SentenceInsertDBImpl.getInstance(conectionDB: conectionDB);
        sentenceDeleteDB = SentenceDeleteDBImpl.getInstance(conectionDB: conectionDB);
        sentenceLastIndexDB = SentenceLastIndexDBImpl.getInstance(conectionDB: conectionDB);
    }

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

    public async Task<long> getLastIndex<T>() where T : BaseDBEntity
        => await sentenceLastIndexDB.getLastIndex<T>();
}
