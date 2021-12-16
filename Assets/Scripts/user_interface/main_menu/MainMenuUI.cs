using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public interface MainMenuUIDelegate : AbstractCanvasUIDelegate
{
    void goToAbout();
    void goToConfiguration();
    void goToLoadGame();
    void goToNewGame();
}

public class MainMenuUI : AbstractCanvas, MainMenuUIViewModelDelegate
{
    public TextMeshProUGUI about;
    public TextMeshProUGUI configuration;
    public TextMeshProUGUI loadGame;
    public TextMeshProUGUI newGame;

    public MainMenuUIDelegate myDelegate;
    private MainMenuUIViewModel viewModel = new MainMenuUIViewModelImpl();

    void Start() {
        viewModel.myDelegate = this;
        initValues();
        crearBaseDeDatos();
    }

    //configuracion base de datos eliminar apenas funcione
    private void crearBaseDeDatos() {

        ConectionDBSqliteImpl.initInstance(DBFileName: "dbs.sqlite", applicationDataPath: Application.dataPath);
        DatabaseManagerImpl.initInstance(conectionDB: ConectionDBSqliteImpl.getInstance());
        DatabaseManager database = DatabaseManagerImpl.getInstance();

        Task.Run(async () => {

            List<Type> clases = new List<Type>() {
                typeof(GameGalacticToSaveEntity)
            };

            //bool createdTables = await database.createTables(entities: clases);
            //bool deleteTables = await database.deleteTables(entities: clases);


            #region
            await ConectionDBSqliteImpl.getInstance().startQueryWithOutResponses("");
            #endregion

            #region leer tabla
            List<Condition> conditions = new List<Condition>();

            Condition condition1 = new Condition();
            condition1.columnName = "id";
            condition1.clausure = Clause.EQUALS;
            condition1.valueInt = 1;
            condition1.type = TypeElement.INTEGER;


            conditions.Add(condition1);

            List<GameGalacticToSaveEntity> element = await database.getElements<GameGalacticToSaveEntity>(conditions: conditions);

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


    //private methods

    void initValues() {
        about.text = viewModel.about;
        configuration.text = viewModel.configuration;
        loadGame.text = viewModel.loadGame;
        newGame.text = viewModel.newGame;
    }

    //public method
    public void clickGoToAbout()
    {
        viewModel.goToAbout();
    }

    public void clickGoToConfiguration()
    {
        viewModel.goToConfiguration();
    }

    public void clickGoToLoadGame()
    {
        viewModel.goToLoadGame();
    }

    public void clickGoToNewGame()
    {
        viewModel.goToNewGame();
    }

    // private methods
    private bool notExistsDelegate() {
        return myDelegate == null;
    }

    // delegate

    public void goToAbout()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToAbout();
    }

    public void goToConfiguration()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToConfiguration();
    }

    public void goToLoadGame()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToLoadGame();
    }

    public void goToNewGame()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToNewGame();
    }

    //set and gets

}
