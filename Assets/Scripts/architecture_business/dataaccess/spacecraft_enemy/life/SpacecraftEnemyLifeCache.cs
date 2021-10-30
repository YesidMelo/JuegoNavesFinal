using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLifeCache {

    int currentLife(IdentificatorModel identificator);
    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);
    int maxLife(IdentificatorModel identificator);

    void addLife(IdentificatorModel identificator, int life);
    void quitLife(IdentificatorModel identificator, int life);

    bool loadLife(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeLife(IdentificatorModel identificator);
}
public class SpacecraftEnemyLifeCacheImpl : SpacecraftEnemyLifeCache
{

    //static variables
    private static SpacecraftEnemyLifeCacheImpl instance;

    //static methods
    public static SpacecraftEnemyLifeCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyLifeCacheImpl();
        }
        return instance;
    }

    private Dictionary<IdentificatorModel, int> _dictionaryCurrentLife = new Dictionary<IdentificatorModel, int>();
    private Dictionary<IdentificatorModel, int> _dictionorayMaxLife = new Dictionary<IdentificatorModel, int>();
    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecraft = new Dictionary<IdentificatorModel, SpacecraftEnemy>();


    public void addLife(IdentificatorModel identificator, int life)
    {
        if (notIsLifeInDictionaries(identificator)) return;

        int currentMaxLife = _dictionaryCurrentLife[identificator];
        int currentLife = _dictionaryCurrentLife[identificator];

        currentLife = currentLife + life;
        if (currentLife >= currentMaxLife) {
            currentLife = currentMaxLife;
            _dictionaryCurrentLife[identificator] = currentLife;
            return;
        }
        _dictionaryCurrentLife[identificator] = currentLife;
    }

    public int currentLife(IdentificatorModel identificator) => _dictionaryCurrentLife[identificator];

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => _dictionarySpacecraft[identificator];

    public bool loadLife(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        _dictionarySpacecraft[identificator] = spacecraft;
        int finalMaxLife = selectCurrentLife(spacecraft);
        _dictionaryCurrentLife[identificator]= finalMaxLife;
        _dictionorayMaxLife[identificator] = finalMaxLife;
        return true;
    }

    public int maxLife(IdentificatorModel identificator) => _dictionorayMaxLife[identificator];

    public void quitLife(IdentificatorModel identificator, int life)
    {
        if (notIsLifeInDictionaries(identificator)) return;

        int currentLife = _dictionaryCurrentLife[identificator];

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

    //private methods
    private bool notIsLifeInDictionaries(IdentificatorModel  identificator) {
        return !_dictionorayMaxLife.ContainsKey(identificator) || !_dictionaryCurrentLife.ContainsKey(identificator);
    }

    private int selectCurrentLife(SpacecraftEnemy spacecraft) {
        int finalLife = 0;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalLife = Constants.lifeEnemyStructureType2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalLife = Constants.lifeEnemyStructureType3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalLife = Constants.lifeEnemyStructureType4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalLife = Constants.lifeEnemyStructureType5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalLife = Constants.lifeEnemyStructureType1;
                break;
        }
        return finalLife;
    }
}