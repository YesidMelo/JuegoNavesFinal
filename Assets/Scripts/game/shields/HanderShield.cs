using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HanderShieldDelegate {
    void impactIncomeShield(Collider2D collision);
    void impactGoneShield(Collider2D collision);
}

public class HanderShield : MonoBehaviour, BaseContextShieldDelegate
{
    [Range(1, 5)]
    public int maxShield = 1;

    [Range(1, 5)]
    public int minShield = 1;
    public List<Shield> shields = new List<Shield>();
    
    public HanderShieldDelegate myDelegate { set { _myDelegate = value; } }

    private HanderShieldDelegate _myDelegate;
    private BaseContextShield contextShield;

    // Start is called before the first frame update
    void Start() => selectContext();

    // public methods
    public void updateListShields(List<Shield> listShields) {
        this.shields = listShields;
        if (contextShield == null) return;
        contextShield.updateListShields(listShields: listShields);
    }

    // Private Methods
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (contextShield == null) return;
        contextShield.OnTriggerEnter2D(collision: collision);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (contextShield == null) return;
        contextShield.OnTriggerEnter2D(collision: collision);
    }

    private void selectContext() {
        Transform parent = transform.parent;
        if (parent == null) return;
        Transform grandParent = parent.transform.parent;
        if (grandParent == null) return;
        if (grandParent.name.Contains(Constants.nameEnemy)) {
            contextShield = new ContextShieldEnemy(
                listShields: shields,
                myDelegate : _myDelegate,
                baseContextShieldDelegate: this
            );
            return;
        }
        contextShield = new ContextShieldPlayer(
            listShields: shields,
            myDelegate: _myDelegate,
            baseContextShieldDelegate: this
        );
    }

    public void deleteLaser(GameObject ammounitionLaser)
    {
        Destroy(ammounitionLaser);
    }

    // get and sets
}
