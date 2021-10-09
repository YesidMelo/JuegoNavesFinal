using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeRepository 
{
    public float life { get; }
    public float maxLife { get; }
    public void addLife(float life);
    public void quitLife(float life);
    public void setMaxLife(float life);
}

public class SpacecraftPlayerLifeRepositoryImpl : SpacecraftPlayerLifeRepository {

    private SpacecraftPlayerLifeCache cache = SpacecraftPlayerLifeCacheImpl.getInstance();
    public float life => cache.life;
    public float maxLife => cache.maxLife;
    public void addLife(float life) => cache.addLife(life);
    public void quitLife(float life) => cache.quitLife(life);
    public void setMaxLife(float life) => cache.setMaxLife(life: life);
}
