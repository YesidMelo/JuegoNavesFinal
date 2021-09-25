using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizationLimit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        deleteLasers(collision);
    }

    private void deleteLasers(Collider2D collision) {
        if (!collision.name.Contains(Constants.nameLaserWeapon)) { return; }
        GameObject parent = collision.gameObject.transform.parent.gameObject;
        HandlerAmmunitionLaser handler = collision.transform.gameObject.GetComponent<HandlerAmmunitionLaser>();
        GameObject parentLaser = handler.finalLaser.parent.transform.parent.gameObject;
        GameObject parentSpacecraft = transform.parent.transform.parent.gameObject;
        if (parentLaser != parentSpacecraft)  return; 
        Destroy(parent);
    }
}
