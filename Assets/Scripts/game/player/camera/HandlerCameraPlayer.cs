using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerCameraPlayer : MonoBehaviour, HandlerCameraPlayerViewModelDelegate
{
    public GameObject currentPlayer;

    private HandlerCameraPlayerViewModel viewModel = new HandlerCameraPlayerViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    //private methods
    private void updatePosition() {
        if (currentPlayer == null) {
            currentPlayer = viewModel.currentPlayer;
            return;
        }
        transform.position = new Vector3(
            currentPlayer.transform.position.x, 
            currentPlayer.transform.position.y, 
            transform.position.z
        );
    }
}
