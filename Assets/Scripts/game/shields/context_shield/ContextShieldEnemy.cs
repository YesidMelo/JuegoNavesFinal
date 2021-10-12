using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextShieldEnemy : BaseContextShield
{

    private SpacecraftEnemyQuitLifeUseCase quitLifeUseCase = new SpacecraftEnemyQuitLifeUseCaseImpl();
    private SpacecraftEnemySetMaxLifeUseCase setMaxLifeUseCase = new SpacecraftEnemySetMaxLifeUseCaseImpl();
    
    public ContextShieldEnemy(
        List<Shield> listShields,
        HanderShieldDelegate myDelegate,
        BaseContextShieldDelegate baseContextShieldDelegate
        ) : base(
            listShields, 
            myDelegate,
            baseContextShieldDelegate
        ){
        notifyIdentificator();
        setMaxLifeUseCase.invoke(400, identificator);
    }

    public override void fillShieldsByDefault()
    {
        listShieldsDefault.Clear();
        foreach (Shield currentShield in _listShields)
        {
            listShieldsDefault.Add((new ShieldFactory()).getShield(currentShield));
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (_handlerShieldDelegate == null) return;
        _handlerShieldDelegate.impactIncomeShield(collision: collision);
        checkLasers(collision: collision);
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (_handlerShieldDelegate == null) return;
        _handlerShieldDelegate.impactGoneShield(collision);
    }

    public override void updateListShields(List<Shield> listShields)
    {
        _listShields = listShields;
        fillShieldsByDefault();
    }

    //private methods
    private void checkLasers(Collider2D collision)
    {
        if (!collision.transform.name.Contains(Constants.nameLaserWeapon)) return;
        Transform laser = collision.transform;
        Transform parentLaser = laser.transform.parent.transform;
        if (parentLaser == null) return;
        HandlerAmmunitionLaser handlerAmmunitionLaser = laser.gameObject.GetComponent<HandlerAmmunitionLaser>();
        if (laserIsFromEnemy(handlerAmmunitionLaser)) return;
        if (_baseContextShieldDelegate == null) return;
        _baseContextShieldDelegate.deleteLaser(parentLaser.gameObject);
        quitLifeUseCase.invoke(handlerAmmunitionLaser.finalLaser.impactDamage, identificator);
    }

    private bool laserIsFromEnemy(HandlerAmmunitionLaser handlerAmmunitionLaser)
    {
        if (handlerAmmunitionLaser == null) return false;
        if (handlerAmmunitionLaser.finalLaser == null) return false;
        if (handlerAmmunitionLaser.finalLaser.nameParent == null) return false;
        return handlerAmmunitionLaser.finalLaser.nameParent.Contains(Constants.nameEnemy);
    }

    private void notifyIdentificator() {
        if (_baseContextShieldDelegate == null) return;
        _baseContextShieldDelegate.listenerIdentificatorShield(identificator);        
    }
}
