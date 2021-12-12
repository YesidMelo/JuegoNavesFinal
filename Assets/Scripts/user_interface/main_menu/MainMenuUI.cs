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

    //TODO: Eliminar esta linea
    private DatabaseManager database = DatabaseManagerImpl.getInstance();

    void Start() {
        viewModel.myDelegate = this;
        initValues();

        Task.Run(async () => {

            List<Type> clases = new List<Type>() {
                typeof(GameGalacticToSaveEntity)
            };

            bool createdTables = await database.createTables(entities: clases);
            //bool deleteTables = await database.deleteTables(entities: clases);

            #region leer tabla
            List<Condition> conditions = new List<Condition>();

            Condition condition1 = new Condition();
            condition1.columnName = "id";
            condition1.clausure = Clause.EQUALS;
            condition1.valueInt = 1;
            condition1.type = TypeElement.INTEGER;

            Condition condition2 = new Condition();
            condition2.columnName = "element";
            condition2.clausure = Clause.EQUALS;
            condition2.valueString = "mola";
            condition2.type = TypeElement.TEXT;

            Condition condition3 = new Condition();
            condition3.columnName = "price";
            condition3.clausure = Clause.GREATER_THAN_OR_EQUAL_TO;
            condition3.valueFloat= 1.0f;
            condition3.type = TypeElement.FLOAT;

            Condition condition4 = new Condition();
            condition4.columnName = "payed";
            condition4.clausure = Clause.EQUALS;
            condition4.valueBool= true;
            condition4.type = TypeElement.BOOL;

           /*
           conditions.Add(condition1);
           conditions.Add(condition2);
           conditions.Add(condition3);
           conditions.Add(condition4);
           */
            List<GameGalacticToSaveEntity> element = await database.getElements<GameGalacticToSaveEntity>(conditions: conditions);

            #endregion

            #region insertar
            GameGalacticToSaveEntity gameGalacticToSave = new GameGalacticToSaveEntity();
            //gameGalacticToSave.id = 10;
            gameGalacticToSave.name = "Mola un monton";
            gameGalacticToSave.dateTime = DateTime.Now;
            gameGalacticToSave.ejem = true;
            List<GameGalacticToSaveEntity> list = new List<GameGalacticToSaveEntity>();
            list.Add(gameGalacticToSave);
            list.Add(gameGalacticToSave);
            list.Add(gameGalacticToSave);
            await database.insertAll(list);
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
