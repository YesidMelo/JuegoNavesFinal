using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerFiringLasersEnemy : MonoBehaviour
{
    public GameObject prefabAmmounitionLaser;
    public HandlerLaserEnemy handlerLaser;
    public HandlerRadarEnemy handlerRadarEnemy;
    public GameObject spacecraft;
    public bool isFiring = false;

    void Update()
    {
        startFiring();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.name.Contains(Constants.nameAmmunitionLaserEnemy)) return;
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //public methods
    //private methods
    private void startFiring()
    {
        if (isFiring) return;
        if (spacecraft == null) return;
        if (handlerLaser == null) return;
        if (handlerRadarEnemy == null) return;
        if (handlerRadarEnemy.currentListInRadar == null) return;
        if (handlerRadarEnemy.currentListInRadar.Count == 0) return;

        isFiring = true;
        StartCoroutine(generateLaser());
    }
    //ui methods

    //IEnumerators
    IEnumerator generateLaser() {
        while (isFiring) {
            GameObject laser = Instantiate(prefabAmmounitionLaser);
            laser.transform.position = transform.position;
            laser.transform.eulerAngles = transform.eulerAngles - new Vector3(0,0,-90);
            HandlerAmmounitionLaserEnemy handler = laser.transform.GetComponent<HandlerAmmounitionLaserEnemy>();
            if (handler == null) break;
            DetailLaserEnemy detailLaser = new DetailLaserEnemy();
            detailLaser.impactDamage = handlerLaser.currentImpact;
            detailLaser.nameParent = spacecraft.name;
            detailLaser.parent = spacecraft;
            handler.updateDetailLaser(detailLaser);
            yield return new WaitForSeconds(Constants.speedFiring);
        }
        isFiring = false;
        yield return null;
    }

    //delegates
}
