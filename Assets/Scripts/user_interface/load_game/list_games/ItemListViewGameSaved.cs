using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemListViewGameSaved : MonoBehaviour
{
    public RectTransform currentRectTransform;
    public GameModel _currentGameSaved;
    public TextMeshProUGUI nameGame;
    public TextMeshProUGUI delete;

    private void Start()
    {
        configRectTransform();
    }

    //public methods


    public void setCurrentGameSaved(GameModel gameModel) { 
        _currentGameSaved = gameModel;
        nameGame.text = gameModel.namePlayer;
        delete.text = "Eliminar";
    }

    //private methods
    private void configRectTransform()
    {
        currentRectTransform.offsetMax = new Vector2(0f, currentRectTransform.offsetMax.y);
        /*
        rectTransform.offsetMin = new Vector2(0f, 0f);
        
        */
        ///*Left*/rectTransform.offsetMin.x;
        ///*Right*/rectTransform.offsetMax.x;
        ///*Top*/rectTransform.offsetMax.y;
        ///*Bottom*/rectTransform.offsetMin.y;
    }


    //sets and gets
    public float heigth() => currentRectTransform.rect.height;
    public float width() => currentRectTransform.rect.width;

}
