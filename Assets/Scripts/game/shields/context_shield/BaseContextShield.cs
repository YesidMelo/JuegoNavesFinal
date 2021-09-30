using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseContextShieldDelegate {
    public void deleteLaser(GameObject ammounitionLaser);
}

public abstract class BaseContextShield 
{
    protected List<Shield> _listShields = new List<Shield>();
    protected List<AbstractShield> _listShieldsDefault = new List<AbstractShield>();
    protected HanderShieldDelegate _handlerShieldDelegate;
    protected BaseContextShieldDelegate _baseContextShieldDelegate;

    public BaseContextShield(
        List<Shield> listShields,
        HanderShieldDelegate handlerShieldDelegate,
        BaseContextShieldDelegate baseContextShieldDelegate
    ) {
        this._listShields = listShields;
        this._handlerShieldDelegate = handlerShieldDelegate;
        this._baseContextShieldDelegate = baseContextShieldDelegate;
        fillShieldsByDefault();
    }

    // Abstract Methods
    public abstract void fillShieldsByDefault();

    public abstract void OnTriggerEnter2D(Collider2D collision);

    public abstract void OnTriggerExit2D(Collider2D collision);
    public abstract void updateListShields(List<Shield> listShields);
    
    // get and sets

    public List<Shield> listShields {
        get => _listShields;
    }

    public List<AbstractShield> listShieldsDefault {
        get => _listShieldsDefault;
    }
}
