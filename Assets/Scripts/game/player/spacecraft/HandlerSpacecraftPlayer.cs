using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftPlayer : 
    MonoBehaviour, 
    HandlerSpacecraftPlayerViewModelDelegate
{
    public HandlerLaserPlayer handlerLaserPlayer;
    public HandlerLifePlayer handlerLifePlayer;
    public HandlerMotorPlayer handlerMotorPlayer;
    public HandlerPositionBarLifePlayer handlerPositionBarLifePlayer;
    public HandlerRadarPlayer handlerRadarPlayer;
    public HandlerStoragePlayer handlerStoragePlayer;
    public HandlerStructurePlayer handlerStructurePlayer;

    private HandlerSpacecraftPlayerViewModel viewModel = new HandlerSpacecraftPlayerViewModelImpl();
    
    void Start()
    {
        viewModel.myDelegate = this;
        initParts();
    }


    //Private methods

    private void initParts() {
        initLaser();
        initLife();
        initMotor();
        initRadar();
        initStorage();
        initStructure();
    }

    private void initMotor() {
        handlerMotorPlayer.parent = transform.gameObject;
    }

    private void initLaser() {
        handlerLaserPlayer.parent = transform.gameObject;
    }

    private void initLife() {
        handlerLifePlayer.parent = transform.gameObject;
        handlerPositionBarLifePlayer.parent = transform.gameObject;
    }

    private void initRadar() {
        handlerRadarPlayer.parent = transform.gameObject;
    }

    private void initStorage() {
        handlerStoragePlayer.parent = transform.gameObject;
    }

    private void initStructure() {
        handlerStructurePlayer.parent = transform.gameObject;
    }

    //UI Unity
    

    //Delegates viewModel
    public void notifiesLoadSpacecraft()
    {

    }

}
