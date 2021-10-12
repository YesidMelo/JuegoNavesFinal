using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerPositionBarInSpacecraft : MonoBehaviour
{
    public GameObject lifeBar;

    private BaseContextBar contextBar;
    private HandlerBar handlerBar;
    private AbstractSpacecraft currentSpacecraft;

    private IdentificatorModel _identificatorShield;

    void Start()
    {
        loadCurrentSpacecraft();
        selectContextBar();
        loadHandlerBar();
    }

    // Update is called once per frame
    void Update()
    {
        updateLife();
        updatePositionBar();
    }

    //Private methods

    void loadHandlerBar() {
        handlerBar = lifeBar.GetComponent<HandlerBar>();
    }

    void selectContextBar()
    {
        if (transform.name.Contains(Constants.namePlayer))
        {
            //contextBar = new ContextBarPlayer(this);
            return;
        }
        currentSpacecraft.listenerIdentificatorShield = (IdentificatorModel identificator) => {
            this.Invoke("initContextBarEnemy", identificator, 0f);
        };
    }

    void updateLife() {
        if (handlerBar == null) return;
        if (contextBar == null) return;
        handlerBar.maxBar = contextBar.maxLife;
        handlerBar.currentBar = contextBar.life;
    }

    void updatePositionBar() {
        lifeBar.transform.position = transform.position + Constants.distanceBetweenSpacecraftBarlife;
        lifeBar.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void loadCurrentSpacecraft()
    {
        HandlerSpacecraftMovement handlerSpacecraftMovement = transform.GetComponent<HandlerSpacecraftMovement>();
        currentSpacecraft = handlerSpacecraftMovement.spacecraft.GetComponent<AbstractSpacecraft>();
    }

    void initContextBarEnemy(IdentificatorModel identificator) {
        contextBar = new ContextBarEnemy(this, identificator);
    }
}
