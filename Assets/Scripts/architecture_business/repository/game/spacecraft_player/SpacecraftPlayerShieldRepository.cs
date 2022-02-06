using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerShieldRepository {
    ShieldPlayer currentShield { get; }
    ShieldModel currentShieldModel { get; }
    void setShield(ShieldPlayer shield);
    void setCurrentShield(ShieldModel shieldModel);
    bool loadShield();
    public void clearCache();
}

public class SpacecraftPlayerShieldRepositoryImpl : SpacecraftPlayerShieldRepository
{
    
    private SpacecraftPlayerShieldCache cache = SpacecraftPlayerShieldCacheImpl.getInstance();

    public ShieldPlayer currentShield => cache.currentShield;

    public ShieldModel currentShieldModel => cache.currentShieldModel;
    public void clearCache() => SpacecraftPlayerShieldCacheImpl.destroyInstance();
    public bool loadShield() => cache.loadShield();
    public void setCurrentShield(ShieldModel shieldModel) => cache.setCurrentShieldModel(shieldModel: shieldModel);
    public void setShield(ShieldPlayer shield) => cache.setShield(shield);
}