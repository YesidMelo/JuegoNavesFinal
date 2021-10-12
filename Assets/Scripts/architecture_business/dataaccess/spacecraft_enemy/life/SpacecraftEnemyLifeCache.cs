using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLifeCache {

    public void addLife(float life, IdentificatorModel identificatorModel);
    public void deleteLife(IdentificatorModel identificatorModel);
    public float life(IdentificatorModel identificatorModel);
    public float maxLife(IdentificatorModel identificatorModel);
    public void quitLife(float life, IdentificatorModel identificatorModel);
    public void setMaxLife(float life, IdentificatorModel identificatorModel);

}

public class SpacecraftEnemyLifeCacheImpl : SpacecraftEnemyLifeCache
{
    private static SpacecraftEnemyLifeCacheImpl _instance;

    public static SpacecraftEnemyLifeCacheImpl getInstance() {
        if (_instance == null) {
            _instance = new SpacecraftEnemyLifeCacheImpl();
        }
        return _instance;
    }

    private Dictionary<IdentificatorModel, float> _allLifes = new Dictionary<IdentificatorModel, float>();
    private Dictionary<IdentificatorModel, float> _allMaxLifes = new Dictionary<IdentificatorModel, float>();

    private SpacecraftEnemyLifeCacheImpl() { }

    public void addLife(float life, IdentificatorModel identificatorModel)
    {
        if (!_allLifes.ContainsKey(identificatorModel)) return;
        if (!_allMaxLifes.ContainsKey(identificatorModel)) return;
        if (_allMaxLifes[identificatorModel] == _allLifes[identificatorModel]) return;

        float finalLife = _allLifes[identificatorModel] + life;

        if (finalLife >= _allMaxLifes[identificatorModel]) {
            _allLifes[identificatorModel] = _allMaxLifes[identificatorModel];
            return;
        }
        _allLifes[identificatorModel] = finalLife;
    }

    public void deleteLife(IdentificatorModel identificatorModel)
    {
        deleteItemFromDictionary(_allLifes, identificatorModel);
        deleteItemFromDictionary(_allMaxLifes, identificatorModel);
    }

    public float life(IdentificatorModel identificatorModel)
    {
        if (_allLifes.ContainsKey(identificatorModel)) {
            return _allLifes[identificatorModel];
        }
        return 0;
    }

    public float maxLife(IdentificatorModel identificatorModel)
    {
        if (_allMaxLifes.ContainsKey(identificatorModel)) {
            return _allMaxLifes[identificatorModel];
        }
        return 0;
    }

    public void quitLife(float life, IdentificatorModel identificatorModel)
    {
        if (!_allLifes.ContainsKey(identificatorModel)) return;
        if (!_allMaxLifes.ContainsKey(identificatorModel)) return;
        if (_allLifes[identificatorModel] == 0) return;

        float finalLife = _allLifes[identificatorModel] - life;

        if (finalLife <= 0) {
            _allLifes[identificatorModel] = 0;
            return;
        }

        _allLifes[identificatorModel] = finalLife;

    }

    public void setMaxLife(float life, IdentificatorModel identificatorModel)
    {
        if (_allMaxLifes.ContainsKey(identificatorModel)) return;
        _allMaxLifes.Add(identificatorModel, life);

        if (_allLifes.ContainsKey(identificatorModel)) return;
        _allLifes.Add(identificatorModel, life);
    }

    //Private methods
    void deleteItemFromDictionary<T>(Dictionary<IdentificatorModel, T> dictionary, IdentificatorModel identificator) {
        if (!dictionary.ContainsKey(identificator)) return;
        dictionary.Remove(identificator);
    }
}