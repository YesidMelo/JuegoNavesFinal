using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerShieldListener : HanderShieldDelegate
{
    public delegate void listenerIdentificatorShield(IdentificatorModel identificatorModel);
    private listenerIdentificatorShield _notifyIdentificatorShield;
    private AbstractSpacecraft spacecraft;

    public HandlerShieldListener(
        AbstractSpacecraft spacecraft,
        listenerIdentificatorShield notifyIdentificatorShield
    ) {
        this.spacecraft = spacecraft;
        this._notifyIdentificatorShield = notifyIdentificatorShield;
    }

    public void impactGoneShield(Collider2D collision){}

    public void impactIncomeShield(Collider2D collision){}

    public void notifyIdentificatorShield(IdentificatorModel identificatorModel) {
        if (_notifyIdentificatorShield == null) return;
        _notifyIdentificatorShield(identificatorModel);
    }
}
