using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerShieldRepository {
    ShieldPlayer currentShield { get; }
    ShieldModel currentShieldModel { get; }
    void setShield(ShieldPlayer shield);
    bool loadShield();
}

public class SpacecraftPlayerShieldRepositoryImpl : SpacecraftPlayerShieldRepository
{
    
    private SpacecraftPlayerShieldCache cache = SpacecraftPlayerShieldCacheImpl.getInstance();

    public ShieldPlayer currentShield => cache.currentShield;

    public ShieldModel currentShieldModel => cache.currentShieldModel;

    public bool loadShield() => cache.loadShield();
    

    public void setShield(ShieldPlayer shield) => cache.setShield(shield);
}