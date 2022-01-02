using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ScrollViewListGamesSaved : MonoBehaviour
{
    public GameObject contentScrollView;
    public GameObject prefabItemListGameSaved;
    private ListViewAdapterGamesSaved listViewAdapterGamesSaved = new ListViewAdapterGamesSaved();
    private SynchronizationContext syncContext = SynchronizationContext.Current;

    //default
    public void Start()
    {
        List<GameModel> listGamesSaved = new List<GameModel>();
        int numberGameModel = 0;
        for (int index = 0; index < numberGameModel; index++) {
            listGamesSaved.Add(new GameModel());
        }
        updateListGamesSaved(listGameModel: listGamesSaved);
    }

    //public methods
    public void updateListGamesSaved(List<GameModel> listGameModel) {
        listViewAdapterGamesSaved.setListGamesSaved(listItemGameSaved: listGameSaved(listGameModel: listGameModel));
        Vector2 currentSize = new Vector2(listViewAdapterGamesSaved.width(), listViewAdapterGamesSaved.heigth());
        getRectTransformContentScroll().sizeDelta = currentSize;
    }

    //private methods
    private RectTransform getRectTransformContentScroll() {
        return contentScrollView.GetComponent<RectTransform>();
    }
    private List<ItemListViewGameSaved> listGameSaved(List<GameModel> listGameModel) {
        List<ItemListViewGameSaved> listViewGameSaveds = new List<ItemListViewGameSaved>();
        float currentPositionY = 0f;
        foreach (GameModel currentGameModel in listGameModel) {
            GameObject currentItem = createItemFromGameObject();
            currentPositionY = addItemToList(
                currentGameObject: currentItem, 
                listViewGameSaveds: listViewGameSaveds,
                itemGameModel: currentGameModel,
                currentPosition: currentPositionY
            );
        }
        return listViewGameSaveds;
    }

    private GameObject createItemFromGameObject() {
        GameObject currentItem = Instantiate(prefabItemListGameSaved);
        currentItem.transform.parent = contentScrollView.transform;
        return currentItem;
    }

    private float addItemToList(
        GameObject currentGameObject, 
        List<ItemListViewGameSaved> listViewGameSaveds,
        GameModel itemGameModel,
        float currentPosition
    )
    {
        ItemListViewGameSaved item = currentGameObject.GetComponent<ItemListViewGameSaved>();
        if (item == null) return currentPosition;
        item.setCurrentGameSaved(gameModel: itemGameModel);
        listViewGameSaveds.Add(item);

        currentGameObject.transform.localPosition = new Vector3(0f, currentPosition, 0f);
        currentPosition -= item.heigth();
        return currentPosition;
    }
}
