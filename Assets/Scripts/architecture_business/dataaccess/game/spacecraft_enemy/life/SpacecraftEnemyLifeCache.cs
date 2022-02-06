using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLifeCache {

    float currentLife(IdentificatorModel identificator);
    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);
    float maxLife(IdentificatorModel identificator);

    void addLife(IdentificatorModel identificator, float life);
    void quitLife(IdentificatorModel identificator, float life);

    bool loadLife(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeLife(IdentificatorModel identificator);
    void clearCache();
}
public class SpacecraftEnemyLifeCacheImpl : SpacecraftEnemyLifeCache
{

    //static variables
    private static SpacecraftEnemyLifeCacheImpl instance;

    //static methods
    public static SpacecraftEnemyLifeCacheImpl getInstance()
    {
        if (instance == null)
        {
            instance = new SpacecraftEnemyLifeCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private Dictionary<IdentificatorModel, float> _dictionaryCurrentLife = new Dictionary<IdentificatorModel, float>();
    private Dictionary<IdentificatorModel, float> _dictionorayMaxLife = new Dictionary<IdentificatorModel, float>();
    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecraft = new Dictionary<IdentificatorModel, SpacecraftEnemy>();


    public void addLife(IdentificatorModel identificator, float life)
    {
        if (notIsLifeInDictionaries(identificator)) return;

        float currentMaxLife = _dictionaryCurrentLife[identificator];
        float currentLife = _dictionaryCurrentLife[identificator];

        currentLife = currentLife + life;
        if (currentLife >= currentMaxLife)
        {
            currentLife = currentMaxLife;
            _dictionaryCurrentLife[identificator] = currentLife;
            return;
        }
        _dictionaryCurrentLife[identificator] = currentLife;
    }

    public float currentLife(IdentificatorModel identificator) => _dictionaryCurrentLife[identificator];

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => _dictionarySpacecraft[identificator];

    public bool loadLife(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        _dictionarySpacecraft[identificator] = spacecraft;
        float finalMaxLife = spacecraft.getLife();
        _dictionaryCurrentLife[identificator] = finalMaxLife;
        _dictionorayMaxLife[identificator] = finalMaxLife;
        return true;
    }

    public float maxLife(IdentificatorModel identificator) => _dictionorayMaxLife[identificator];

    public void quitLife(IdentificatorModel identificator, float life)
    {
        if (notIsLifeInDictionaries(identificator)) return;

        float currentLife = _dictionaryCurrentLife[identificator];

        currentLife = currentLife - life;
        if (currentLife <= 0)
        {
            currentLife = 0;
            _dictionaryCurrentLife[identificator] = currentLife;
            return;
        }
        _dictionaryCurrentLife[identificator] = currentLife;
    }

    public void removeLife(IdentificatorModel identificator)
    {
        if (notIsLifeInDictionaries(identificator)) return;
        _dictionorayMaxLife.Remove(identificator);
        _dictionaryCurrentLife.Remove(identificator);
        _dictionarySpacecraft.Remove(identificator);
    }

    public void clearCache()
    {
        _dictionaryCurrentLife.Clear();
        _dictionarySpacecraft.Clear();
        _dictionorayMaxLife.Clear();
    }

    //private methods
    private bool notIsLifeInDictionaries(IdentificatorModel identificator)
    {
        return !_dictionorayMaxLife.ContainsKey(identificator) || !_dictionaryCurrentLife.ContainsKey(identificator);
    }

    
}