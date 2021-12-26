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

    //configuracion base de datos eliminar apenas funcione
    private void crearBaseDeDatos()
    {

        Task.Run(async () => {

            
            //bool createdTables = await database.createTables(entities: clases);
            //bool deleteTables = await database.deleteTables(entities: clases);


            #region
            await ConectionDBSqliteImpl.getInstance().startQueryWithOutResponses("");
            #endregion

            #region leer tabla
            /*
            List<Condition> conditions = new List<Condition>();

            Condition condition1 = new Condition();
            condition1.columnName = "id";
            condition1.clausure = Clause.EQUALS;
            condition1.valueInt = 1;
            condition1.type = TypeElement.INTEGER;


            conditions.Add(condition1);

            List<GameGalacticToSaveEntity> element = await database.getElements<GameGalacticToSaveEntity>(conditions: conditions);
            */
            #endregion

            #region insertar
            /*
            GameGalacticToSaveEntity gameGalacticToSave = new GameGalacticToSaveEntity();
            //gameGalacticToSave.id = 10;
            gameGalacticToSave.name = "Mola un monton";
            gameGalacticToSave.dateTime = DateTime.Now;
            gameGalacticToSave.ejem = true;
            List<GameGalacticToSaveEntity> list = new List<GameGalacticToSaveEntity>();
            list.Add(gameGalacticToSave);
            await database.insertAll(list);
            */
            #endregion

            #region  eliminar de la tabla
            /*
            //bool limpioTabla = await database.clearTable<GameGalacticToSaveEntity>();
            GameGalacticToSaveEntity game = new GameGalacticToSaveEntity();
            game.id = 1;
            
            List<GameGalacticToSaveEntity> listGame = new List<GameGalacticToSaveEntity>();

            listGame.Add(game);

            //bool elementoEliminado = await database.deleteElement(game);
            bool elementoEliminado = await database.deleteElements(listGame);
            */

            #endregion


        });
    }

}

