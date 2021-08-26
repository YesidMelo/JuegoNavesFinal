using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarDelegate {
    void enterGameObject(Collider2D collision);
    void exitGameObject(Collider2D collision);
}

public class HandlerRadar : MonoBehaviour
{
    private HandlerRadarDelegate _myDelegate;
    public HandlerRadarDelegate myDelegate { set { _myDelegate = value; } }
    public Radar currentRadar = Radar.TYPE_1;
    public AbstractRadar radar;

    public List<GameObject> enemy = new List<GameObject>();
    public GameObject currentEnemy;

    private string _currentSideGameObject;

    private void Start()
    {
        _currentSideGameObject = transform.parent.parent.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_myDelegate == null) {
            return;
        }
        addSideEnemy(collision);
        _myDelegate.enterGameObject(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_myDelegate == null)
        {
            return;
        }
        if (enemy.Contains(collision.gameObject))
        {
            enemy.Remove(collision.gameObject);
        }
        if (collision.gameObject == currentEnemy) {
            currentEnemy = null;
        }
        _myDelegate.enterGameObject(collision);
    }

    private void addSideEnemy(Collider2D collision) {
        if (_currentSideGameObject == Constants.namePlayer) {
            captureEnemyFromPlayer(collision);
            return;
        }
        captureEnemyFromCPU(collision);
        
    }

    private void captureEnemyFromPlayer(Collider2D collision) {
        if (collision.transform.parent.parent.name.Contains(Constants.namePlayer)) {
            return;
        }
        if (!enemy.Contains(collision.gameObject))
        {
            enemy.Add(collision.gameObject);
        }
    }

    private void captureEnemyFromCPU(Collider2D collision)
    {
        if (collision.transform.parent.parent.name.Contains(Constants.nameEnemy))
        {
            return;
        }
        if (!enemy.Contains(collision.gameObject))
        {
            enemy.Add(collision.gameObject);
        }
    }
}
