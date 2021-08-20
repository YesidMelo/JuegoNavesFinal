using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HanderShieldDelegate {
    void impactIncomeShield(Collider2D collision);
    void impactGoneShield(Collider2D collision);
}

public class HanderShield : MonoBehaviour
{
    [Range(1, 5)]
    public int maxShield = 1;

    [Range(1, 5)]
    public int minShield = 1;
    public List<Shield> shields = new List<Shield>();
    public List<AbstractShield> listShieldsDefault = new List<AbstractShield>();
    public HanderShieldDelegate myDelegate { set { _myDelegate = value; } }

    private HanderShieldDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        fillShieldsByDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Private Methods
    void fillShieldsByDefault() {
        listShieldsDefault.Clear();
        foreach(Shield currentShield in shields) {
            listShieldsDefault.Add((new ShieldFactory()).getShield(currentShield));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_myDelegate == null) { return; }
        _myDelegate.impactIncomeShield(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_myDelegate == null) { return; }
        _myDelegate.impactGoneShield(collision);
    }
}
