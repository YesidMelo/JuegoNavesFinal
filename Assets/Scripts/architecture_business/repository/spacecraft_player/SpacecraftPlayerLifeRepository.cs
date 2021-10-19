using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeRepository 
{
    public float life { get; }
    public float maxLife { get; }
    public StructurePlayer currentStructure { get; }
    public void addLife(int life);
    public void addStructureLife(StructurePlayer structure);
    public bool loadLife();
    public void quitLife(int life);
    public void updateCurrentLife(int life);
}

public class SpacecraftPlayerLifeRepositoryImpl : SpacecraftPlayerLifeRepository {

    private SpacecraftPlayerLifeCache cache = SpacecraftPlayerLifeCacheImpl.getInstance();
    public float life => cache.life;
    public float maxLife => cache.maxLife;
    public StructurePlayer currentStructure => cache.currentStructure;

    public void addLife(int life) => cache.addLife(life);
    public void addStructureLife(StructurePlayer structure) => cache.addStructureLife(structure);
    public bool loadLife() => cache.loadLife();
    public void quitLife(int life) => cache.quitLife(life);
    public void updateCurrentLife(int life) => cache.updateCurrentLife(life);
}
