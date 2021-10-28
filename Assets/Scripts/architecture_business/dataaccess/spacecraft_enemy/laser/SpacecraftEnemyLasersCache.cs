using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLasersCache {

    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);
    void deleteLasers(IdentificatorModel identificator);
    int impactLaser(IdentificatorModel identificator);
    bool loadSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    LaserEnemy typeLaser(IdentificatorModel identificator);

}
public class SpacecraftEnemyLasersCacheImpl : SpacecraftEnemyLasersCache
{
    //static variables
    private static SpacecraftEnemyLasersCacheImpl instance;

    //static methods
    public static SpacecraftEnemyLasersCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyLasersCacheImpl();
        }
        return instance;
    }

    //variables

    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecraft = new Dictionary<IdentificatorModel, SpacecraftEnemy>();
    private Dictionary<IdentificatorModel, int> _dictionaryImpactLaser = new Dictionary<IdentificatorModel, int>();
    private Dictionary<IdentificatorModel, LaserEnemy> _dictionaryTypeLaser = new Dictionary<IdentificatorModel, LaserEnemy>();

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => _dictionarySpacecraft[identificator];

    public void deleteLasers(IdentificatorModel identificator)
    {
        clear(_dictionarySpacecraft, identificator);
        clear(_dictionaryImpactLaser, identificator);
        clear(_dictionaryTypeLaser, identificator);
    }

    public int impactLaser(IdentificatorModel identificator) => _dictionaryImpactLaser[identificator];

    public bool loadSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        insertElements(identificator, spacecraft);
        return true;
    }

    public LaserEnemy typeLaser(IdentificatorModel identificator) => _dictionaryTypeLaser[identificator];

    //private methods
    private void clear<T>(Dictionary<IdentificatorModel, T> dictionary, IdentificatorModel identificator) {
        if (!dictionary.ContainsKey(identificator)) return;
        dictionary.Remove(identificator);
    }

    private void insertElements(IdentificatorModel identificator, SpacecraftEnemy spacecraftEnemy) {
        insertSpacecraft(identificator,spacecraftEnemy);
        insertImpactLaser(identificator,spacecraftEnemy);
        insertTypeLaser(identificator,spacecraftEnemy);
    }

    private void insertSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraftEnemy) {
        _dictionarySpacecraft[identificator] = spacecraftEnemy;
    }

    private void insertImpactLaser(IdentificatorModel identificator, SpacecraftEnemy spacecraftEnemy) {
        int finalImpact = 0;
        switch (spacecraftEnemy) {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalImpact = Constants.laserEnemyType2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalImpact = Constants.laserEnemyType3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalImpact = Constants.laserEnemyType4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalImpact = Constants.laserEnemyType5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalImpact = Constants.laserEnemyType1;
                break;
        }
        _dictionaryImpactLaser[identificator] = finalImpact;
    }

    private void insertTypeLaser(IdentificatorModel identificator, SpacecraftEnemy spacecraftEnemy) {
        LaserEnemy type;
        switch (spacecraftEnemy)
        {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                type = LaserEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                type = LaserEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                type = LaserEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                type = LaserEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                type = LaserEnemy.TYPE_1;
                break;
        }
        _dictionaryTypeLaser[identificator] = type;
    }
}