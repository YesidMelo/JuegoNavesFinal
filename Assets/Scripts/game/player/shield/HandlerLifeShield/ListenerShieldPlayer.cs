using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ListenerShieldPlayerDelegate {
    void OnTriggerEnter2DDelegate(Collider2D collision);
    void OnTriggerExit2DDelegate(Collider2D collision);
}

public class ListenerShieldPlayer : MonoBehaviour
{

    public ListenerShieldPlayerDelegate myDelegte;
    public StructurePlayer currentSpacecraft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myDelegte == null) return;
        myDelegte.OnTriggerEnter2DDelegate(collision: collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (myDelegte == null) return;
        myDelegte.OnTriggerEnter2DDelegate(collision: collision);
    }
}
