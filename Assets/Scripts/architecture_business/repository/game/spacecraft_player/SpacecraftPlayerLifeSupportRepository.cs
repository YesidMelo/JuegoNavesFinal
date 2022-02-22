using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeSupportRepository {
    LifeSupportModel currentLifeSupportModel { get; }
    LifeSupportPlayer getCurrentLifeSupport();
    void setCurrentLifeSupportModel(LifeSupportModel lifeSupportModel);
    void clearCache();
    bool playerIsUnderAttack();
    void updatePlayerIsUnderAttack(bool playerIsUnderAttack);
}

public class SpacecraftPlayerLifeSupportRepositoryImpl : SpacecraftPlayerLifeSupportRepository {

    private LifeSupportPlayerCache cache = LifeSupportPlayerCacheImpl.getInstance();

    public LifeSupportModel currentLifeSupportModel => cache.currentLifeSupportModel;

    public void clearCache() => LifeSupportPlayerCacheImpl.destroyInstance();

    public LifeSupportPlayer getCurrentLifeSupport() => cache.getCurrentLifeSupport();

    public bool playerIsUnderAttack() => cache.playerIsUnderAttack();

    public void setCurrentLifeSupportModel(LifeSupportModel lifeSupportModel) => cache.setCurrentLifeSupportModel(lifeSupportModel: lifeSupportModel);

    public void updatePlayerIsUnderAttack(bool playerIsUnderAttack) => cache.updatePlayerIsUnderAttack(playerIsUnderAttack: playerIsUnderAttack);
}