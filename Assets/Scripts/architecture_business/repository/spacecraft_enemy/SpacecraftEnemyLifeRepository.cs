using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLifeRepository {
    public void addLife(float life, IdentificatorModel identificatorModel);
    public void deleteLife(IdentificatorModel identificatorModel);
    public float life(IdentificatorModel identificatorModel);
    public float maxLife(IdentificatorModel identificatorModel);
    public void quitLife(float life, IdentificatorModel identificatorModel);
    public void setMaxLife(float life, IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyLifeRepositoryImpl : SpacecraftEnemyLifeRepository
{
    private SpacecraftEnemyLifeCache cache = SpacecraftEnemyLifeCacheImpl.getInstance();

    public void addLife(float life, IdentificatorModel identificatorModel) => cache.addLife(life, identificatorModel);

    public void deleteLife(IdentificatorModel identificatorModel) => cache.deleteLife(identificatorModel);

    public float life(IdentificatorModel identificatorModel) => cache.life(identificatorModel);

    public float maxLife(IdentificatorModel identificatorModel) => cache.maxLife(identificatorModel);

    public void quitLife(float life, IdentificatorModel identificatorModel) => cache.quitLife(life, identificatorModel);

    public void setMaxLife(float life, IdentificatorModel identificatorModel) => cache.setMaxLife(life, identificatorModel);
}
