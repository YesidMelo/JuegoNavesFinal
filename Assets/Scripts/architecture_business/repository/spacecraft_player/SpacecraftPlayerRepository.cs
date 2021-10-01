using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRepository 
{
    public float life { get; }

    public void setLife(float life);

    public void addLife(float life);

    public void quitLife(float life);
}

public class SpacecraftPlayerRepositoryImpl : SpacecraftPlayerRepository {

    private SpacecraftPlayerLifeCache spacecraftPlayerCache = SpacecraftPlayerLifeCacheImpl.getInstance();

    public float life => spacecraftPlayerCache.life;

    public void addLife(float life) => spacecraftPlayerCache.addLife(life);

    public void quitLife(float life) => spacecraftPlayerCache.quitLife(life);

    public void setLife(float life) => spacecraftPlayerCache.setMaxLife(life: life);
}
