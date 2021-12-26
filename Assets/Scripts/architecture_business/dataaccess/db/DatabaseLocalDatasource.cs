using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DatabaseLocalDatasource {
    Task<bool> createDatabase(string applicationDataPath);
    Task<bool> createTablesDataBase();
}

public class DatabaseLocalDatasourceImpl : DatabaseLocalDatasource {

    //static variables
    private static DatabaseLocalDatasourceImpl instance;

    //static methods
    public static DatabaseLocalDatasourceImpl getInstance() {
        if (instance == null) {
            instance = new DatabaseLocalDatasourceImpl();
        }
        return instance;
    }

    //public methods
    public async Task<bool> createDatabase(string applicationDataPath) {

        await ConectionDBSqliteImpl.initInstance(DBFileName: "dbs", applicationDataPath: Application.dataPath);
        DatabaseManagerImpl.initInstance(conectionDB: ConectionDBSqliteImpl.getInstance());
        return true;
    }

    public async Task<bool> createTablesDataBase() {
        try
        {
            await DatabaseManagerImpl
                .getInstance()
                .createTables(entities: generateEntitiesDataBase());
            return true;
        }
        catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    //private methods

    private List<Type> generateEntitiesDataBase() {
        return new List<Type>()
        {
            typeof(GameEntity),
            typeof(LaserEntity),
            typeof(LifeEntity),
            typeof(MotorEntity),
            typeof(RadarEntitty),
            typeof(ShieldEntity),
            typeof(ShieldEntity),
            typeof(StorageEntity),
            typeof(StructureEntity),
        };
    }

}

