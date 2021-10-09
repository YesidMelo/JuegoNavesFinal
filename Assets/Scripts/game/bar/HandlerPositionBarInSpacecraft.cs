using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerPositionBarInSpacecraft : MonoBehaviour
{
    public GameObject lifeBar;

    private BaseContextBar contextBar;
    private HandlerBar handlerBar;

    void Start()
    {
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

    void selectContextBar() {
        if (transform.name.Contains(Constants.namePlayer)) {
            contextBar = new ContextBarPlayer(this);
            return;
        }
    }

    void updateLife() {
        if (handlerBar == null) return;
        handlerBar.maxBar = contextBar.maxLife;
        handlerBar.currentBar = contextBar.life;
    }

    void updatePositionBar() {
        lifeBar.transform.position = transform.position + Constants.distanceBetweenSpacecraftBarlife;
        lifeBar.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
