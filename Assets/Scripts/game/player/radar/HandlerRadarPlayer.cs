using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarPlayer : MonoBehaviour, HandlerRadarPlayerViewModelDelegate
{
    public bool loadRadarFromUI = false;
    public List<GameObject> listObjectsInRadar = new List<GameObject>();

    private HandlerRadarPlayerViewModel viewModel = new HandlerRadarPlayerViewModelImpl();
    private bool loadRadar = false;

    
    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadRadar();
    }

    void Update()
    {
        checkCurrentObjects();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (viewModel == null) return;
        viewModel.addElementToRadar(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (viewModel == null) return;
        viewModel.removeElementFromRadar(collision.gameObject);
    }

    //private methods
    private void checkCurrentObjects() {
        if (viewModel == null) return;
        listObjectsInRadar = viewModel.listObjects;
    }
    //delegates
    public void notifyLoadRadar()
    {
        loadRadar = true;
    }

}
