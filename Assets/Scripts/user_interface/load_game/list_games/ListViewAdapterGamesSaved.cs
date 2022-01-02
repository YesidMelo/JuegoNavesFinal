using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ListViewAdapterGamesSaved
{
    private List<ItemListViewGameSaved> listGamesSaved = new List<ItemListViewGameSaved>();
    private float _currentHeigth = 0f;
    private float _currentWidth = 0f;

    public float width() => _currentWidth;
    public float heigth() => _currentHeigth;

    //public methods

    public void setListGamesSaved(List<ItemListViewGameSaved> listItemGameSaved) {
        this.listGamesSaved = listItemGameSaved;
        calculateWidthAndHeigth();
    }

    //private methods
    private void calculateWidthAndHeigth() {
        foreach (ItemListViewGameSaved item in listGamesSaved) {
            _currentHeigth += item.heigth();
            _currentWidth += item.width();
        }
    }
}
