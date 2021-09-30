using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextShieldEnemy : BaseContextShield
{
    public ContextShieldEnemy(
        List<Shield> listShields,
        HanderShieldDelegate myDelegate,
        BaseContextShieldDelegate baseContextShieldDelegate
        ) : base(
            listShields, 
            myDelegate,
            baseContextShieldDelegate
        ){}

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
        if (!collision.transform.name.Contains(Constants.namePlayer)) return;
        Transform laser = collision.transform;
        Transform parentLaser = laser.transform.parent.transform;
        if (parentLaser == null) return;
        if (_baseContextShieldDelegate == null) return;
        _baseContextShieldDelegate.deleteLaser(parentLaser.gameObject);
    }
}
