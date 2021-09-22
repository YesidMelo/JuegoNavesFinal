using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRadar {

    public List<GameObject> listEnemy = new List<GameObject>();
    public GameObject currentEnemy;

    private string _currentSideGameObject;
    public string currentSideGameObject { 
        set {
            _currentSideGameObject = value;
        } 
    }

    public void changeEnemy() {
        if (listEnemy.Count == 0) return;
        if (listEnemy.Count == 1) {
            currentEnemy = listEnemy[0];
            return;
        }
        GameObject toChange = currentEnemy;
        listEnemy.Remove(toChange);
        currentEnemy = listEnemy[0];
        listEnemy.Add(toChange);
    }

    public void addSideEnemy(Collider2D collision)
    {
        if (_currentSideGameObject == Constants.namePlayer)
        {
            captureEnemyFromPlayer(collision);
            return;
        }
        captureEnemyFromCPU(collision);

    }

    public void removeEnemy(GameObject enemy) {
        if (listEnemy.Contains(enemy)) { listEnemy.Remove(enemy); }
        if (enemy == currentEnemy && listEnemy.Count == 0) { 
            currentEnemy = null;
            return;
        }
        if (listEnemy.Count == 0) return;
        currentEnemy = listEnemy[0];

    }

    private void captureEnemyFromPlayer(Collider2D collision)
    {
        if (collision.transform.parent.parent.name.Contains(Constants.namePlayer)) return;
        if (listEnemy.Contains(collision.gameObject)) return;
        listEnemy.Add(collision.gameObject);
    }

    private void captureEnemyFromCPU(Collider2D collision)
    {
        if (collision.transform.parent.parent.name.Contains(Constants.nameEnemy))
        {
            return;
        }
        if (!listEnemy.Contains(collision.gameObject))
        {
            listEnemy.Add(collision.gameObject);
        }
        if (currentEnemy == null && listEnemy.Count > 0)
        {
            currentEnemy = listEnemy[0];
        }
    }
}