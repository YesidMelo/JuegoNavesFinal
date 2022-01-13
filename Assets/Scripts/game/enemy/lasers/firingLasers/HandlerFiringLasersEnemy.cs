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
    public GameObject currentPlayer;

    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();

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
        if (!iCanStartFiring()) {
            
            return;
        }
        isFiring = true;
        StartCoroutine(generateLaser());
    }

    private bool iCanStartFiring()
    {
        if (spacecraft == null)
        {
            isFiring = false;
            return false;
        }
        if (handlerLaser == null)
        {
            isFiring = false;
            return false;
        }
        if (handlerRadarEnemy == null) {
            isFiring = false;
            return false; 
        }
        if (handlerRadarEnemy.currentListInRadar == null)
        {
            isFiring = false;
            return false;
        }
        if (handlerRadarEnemy.currentListInRadar.Count == 0) {
            isFiring = false;
            return false; 
        }
        return true;
    }

    //ui methods

    //IEnumerators
    IEnumerator generateLaser() {
        while (isFiring) {
            if (!isGameInPauseUseCase.invoke())
            {
                GameObject laser = Instantiate(prefabAmmounitionLaser);
                laser.transform.position = transform.position;
                laser.transform.eulerAngles = transform.eulerAngles - new Vector3(0, 0, -90);
                HandlerAmmounitionLaserEnemy handler = laser.transform.GetComponent<HandlerAmmounitionLaserEnemy>();
                if (handler == null) break;
                DetailLaserEnemy detailLaser = new DetailLaserEnemy();
                detailLaser.impactDamage = handlerLaser.currentImpact;
                detailLaser.nameParent = spacecraft.name;
                detailLaser.parent = spacecraft;
                handler.updateDetailLaser(detailLaser);
                yield return new WaitForSeconds(Constants.speedFiring);
                if (!iCanStartFiring()) yield return null;
            }
            else {
                yield return new WaitForSeconds(Constants.speedFiring);
                if (!iCanStartFiring()) yield return null;
            }
        }
        isFiring = false;
        yield return null;
    }

    //delegates
}
