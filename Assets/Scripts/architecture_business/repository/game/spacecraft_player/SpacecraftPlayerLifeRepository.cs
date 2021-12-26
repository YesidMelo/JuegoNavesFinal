using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeRepository 
{
    public float life { get; }
    public float maxLife { get; }
    public LifeModel currentLifeModel { get; }
    public StructurePlayer currentStructure { get; }
    public void addLife(float life);
    public void addStructureLife(StructurePlayer structure);
    public bool loadLife();
    public void quitLife(float life);
    public void updateCurrentLife(float life);
}

public class SpacecraftPlayerLifeRepositoryImpl : SpacecraftPlayerLifeRepository {

    private SpacecraftPlayerLifeCache cache = SpacecraftPlayerLifeCacheImpl.getInstance();
    public float life => cache.life;
    public float maxLife => cache.maxLife;
    public StructurePlayer currentStructure => cache.currentStructure;

    public LifeModel currentLifeModel => cache.currentLifeModel;

    public void addLife(float life) => cache.addLife(life);
    public void addStructureLife(StructurePlayer structure) => cache.addStructureLife(structure);
    public bool loadLife() => cache.loadLife();
    public void quitLife(float life) => cache.quitLife(life);
    public void updateCurrentLife(float life) => cache.updateCurrentLife(life);
}
