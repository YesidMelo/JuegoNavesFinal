using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeSupportRepository {
    LifeSupportModel currentLifeSupportModel { get; }
    LifeSupportPlayer getCurrentLifeSupport();
    void clearCache();
}

public class SpacecraftPlayerLifeSupportRepositoryImpl : SpacecraftPlayerLifeSupportRepository {

    private LifeSupportPlayerCache cache = LifeSupportPlayerCacheImpl.getInstance();

    public LifeSupportModel currentLifeSupportModel => cache.currentLifeSupportModel;

    public void clearCache() => LifeSupportPlayerCacheImpl.destroyInstance();

    public LifeSupportPlayer getCurrentLifeSupport() => cache.getCurrentLifeSupport();

}