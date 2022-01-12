using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRotationPlayer : MonoBehaviour, HandlerRotationPlayerViewModelDelegate
{
    public Action currentAction;
    public GameObject structure;
    public GameObject laser;

    public List<GameObject> currentListElementsInRadar = new List<GameObject>();
    public GameObject currentEnemy;

    private HandlerRotationPlayerViewModel viewModel = new HandlerRotationPlayerViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (viewModel.isGameInPause()) return;
        checkCurrentAction();
        checkCurrentListElementsInRadar();
        checkCurrentEnemy();
        rotateStructure();
    }

    //private methods
    void checkCurrentAction() {
        if (viewModel == null) return;
        currentAction = viewModel.currentAction;
    }

    void rotateStructure() {
        switch (currentAction) {
            case Action.ATTACK:
                rotateToEnemy();
                return;
            default:
                originalRotation();
                return;
        }
    }

    void originalRotation() {
        restoreRotation(structure);
        restoreRotation(laser);
    }

    void rotateToEnemy() {
        if (currentEnemy == null)
        {
            originalRotation();
            return;
        }
        pointToEnemy(structure);
        pointToEnemy(laser);
    }

    void checkCurrentListElementsInRadar() {
        if (viewModel == null) return;
        currentListElementsInRadar = viewModel.getListElementsInRadar;
    }

    void checkCurrentEnemy() {
        if (viewModel == null) return;
        currentEnemy = viewModel.currentEnemy;
    }

    private void pointToEnemy(GameObject gameObject)
    {
        if (currentEnemy == null) return;
        Vector2 positionSpacecraft = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 positionEnemy = new Vector2(currentEnemy.transform.position.x, currentEnemy.transform.position.y);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Functions.getAngleLookAt(positionSpacecraft, positionEnemy));
    }

    private void restoreRotation(GameObject gameObject) {
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
