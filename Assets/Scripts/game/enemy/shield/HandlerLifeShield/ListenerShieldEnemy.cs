using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ListenerShieldEnemyDelegate {
    void OnTriggerEnter2DDelegate(Collider2D collision);
    void OnTriggerExit2DDelegate(Collider2D collision);
}

public class ListenerShieldEnemy : MonoBehaviour
{
    public ListenerShieldEnemyDelegate myDelegate;
    public SpacecraftEnemy spacecraftEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myDelegate == null) return;
        myDelegate.OnTriggerEnter2DDelegate(collision: collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (myDelegate == null) return;
        myDelegate.OnTriggerExit2DDelegate(collision: collision);
    }
}
