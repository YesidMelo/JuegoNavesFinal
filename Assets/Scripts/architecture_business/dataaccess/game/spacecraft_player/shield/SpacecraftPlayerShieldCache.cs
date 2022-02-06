using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerShieldCache { 

    ShieldPlayer currentShield { get; }
    ShieldModel currentShieldModel { get; }
    void setShield(ShieldPlayer shield);
    void setCurrentShieldModel(ShieldModel shieldModel);
    bool loadShield();
    public void clearCache();

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

    public static void destroyInstance() => _instance = null;

    private ShieldPlayer _currentShield;
    private ShieldModel _currentShieldModel = new ShieldModel();

    public ShieldPlayer currentShield => _currentShield;

    public ShieldModel currentShieldModel => _currentShieldModel;

    public void clearCache()
    {
        _currentShield = ShieldPlayer.TYPE_1;
        _currentShieldModel = new ShieldModel();
    }

    public void setShield(ShieldPlayer shield) { 
        _currentShield = shield;
        _currentShieldModel.currentShield = _currentShield;
    }

    public bool loadShield()
    {
        if (_currentShield == null) {
            _currentShield = ShieldPlayer.TYPE_1;
        }
        _currentShieldModel.currentShield = _currentShield;
        return true;
    }

    public void setCurrentShieldModel(ShieldModel shieldModel)
    {
        _currentShieldModel = shieldModel;
        _currentShield = shieldModel.currentShield;
    }

}
