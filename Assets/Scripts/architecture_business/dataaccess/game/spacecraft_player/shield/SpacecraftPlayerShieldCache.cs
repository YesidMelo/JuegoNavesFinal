using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerShieldCache { 

    ShieldPlayer currentShield { get; }
    void setShield(ShieldPlayer shield);
    bool loadShield();
}
public class SpacecraftPlayerShieldCacheImpl : SpacecraftPlayerShieldCache
{
    //static variables
    private static SpacecraftPlayerShieldCacheImpl _instance;

    //static methods
    public static SpacecraftPlayerShieldCacheImpl getInstance() {
        if (_instance == null) {
            _instance = new SpacecraftPlayerShieldCacheImpl();
        }
        return _instance;
    }

    private ShieldPlayer _currentShield;

    public ShieldPlayer currentShield => _currentShield;

    public void setShield(ShieldPlayer shield) => _currentShield = shield;

    public bool loadShield()
    {
        if (_currentShield == null) {
            _currentShield = ShieldPlayer.TYPE_1;
        }
        return true;
    }
}
