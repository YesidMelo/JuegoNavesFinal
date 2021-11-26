using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanlderLifeShieldEnemy : MonoBehaviour, 
    HandlerLifeShieldEnemyViewModelDelegate,
    ListenerShieldEnemyDelegate
{
    public HandlerShieldEnemy handlerShieldEnemy;
    public float currentLife;
    public List<ListenerShieldEnemy> formShieldsAvailables;


    private HandlerLifeShieldEnemyViewModel viewModel = new HandlerLifeShieldEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
        setCurrentSpacecraftInformShieldAvailables();
    }

    void Update()
    {
        checkCurrentLife();
    }

    //public methods
    //private methods
    private void setCurrentSpacecraftInformShieldAvailables()
    {
        if (formShieldsAvailables == null || formShieldsAvailables.Count == 0) return;

        foreach (ListenerShieldEnemy load in formShieldsAvailables) {
            load.spacecraftEnemy = viewModel.currentSpacecraft(handlerShieldEnemy.identificator);
            load.myDelegate = this;
        }
    }

    private void checkCurrentLife() {
        if (handlerShieldEnemy == null) return;
        currentLife = viewModel.currentLife(handlerShieldEnemy.identificator);
    }

    private void manageLaserPlayer(Collider2D collision) {
        if (viewModel == null) return;
        if (!collision.name.Contains(Constants.nameAmmunitionLaserPlayer)) return;
        removeLife(collision);
        Destroy(collision.gameObject);
    }

    private void removeLife(Collider2D collision) {
        HandlerAmmountLaserPlayer handler = collision.transform.GetComponent<HandlerAmmountLaserPlayer>();
        if (handler == null) return;
        viewModel.removeLife(handler.detailLaser, handlerShieldEnemy.identificator);
    }

    //ui methods
    //delegate
    public void OnTriggerEnter2DDelegate(Collider2D collision)
    {
        manageLaserPlayer(collision: collision);
    }

    public void OnTriggerExit2DDelegate(Collider2D collision)
    {
        
    }
}
