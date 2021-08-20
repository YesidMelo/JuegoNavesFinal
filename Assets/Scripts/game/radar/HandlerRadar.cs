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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_myDelegate == null) {
            return;
        }
        _myDelegate.enterGameObject(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_myDelegate == null)
        {
            return;
        }
        _myDelegate.enterGameObject(collision);
    }
}
