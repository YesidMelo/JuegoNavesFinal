using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRadarCache {
    int radiusRadar(IdentificatorModel identificator);
    RadarEnemy currentRada(IdentificatorModel identificator);
    bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeRadar(IdentificatorModel identificator);

}
public class SpacecraftEnemyRadarCacheImpl : SpacecraftEnemyRadarCache
{
    //static variables
    private static SpacecraftEnemyRadarCacheImpl instance;

    //static methods
    public static SpacecraftEnemyRadarCacheImpl getInstance() {
        if (instance == null){
            instance = new SpacecraftEnemyRadarCacheImpl();
        }
        return instance;
    }

    private Dictionary<IdentificatorModel, int> _dictionaryRadius = new Dictionary<IdentificatorModel, int>();
    private Dictionary<IdentificatorModel, RadarEnemy> _dictionaryRadar = new Dictionary<IdentificatorModel, RadarEnemy>();
    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecraft = new Dictionary<IdentificatorModel, SpacecraftEnemy>();


    public RadarEnemy currentRada(IdentificatorModel identificator) => _dictionaryRadar[identificator];

    public bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft) {
        _dictionarySpacecraft[identificator] = spacecraft;
        _dictionaryRadius[identificator] = loadRadiusRadar(spacecraft);
        _dictionaryRadar[identificator] = loadTypeRadar(spacecraft);
        return true;
    }

    public int radiusRadar(IdentificatorModel identificator) => _dictionaryRadius[identificator];

    public void removeRadar(IdentificatorModel identificator)
    {
        removeFromDictionary(identificator, _dictionaryRadar);
        removeFromDictionary(identificator, _dictionaryRadius);
        removeFromDictionary(identificator, _dictionarySpacecraft);
    }

    //private methods

    private int loadRadiusRadar(SpacecraftEnemy spacecraft) {
        int finalRadius = 0;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalRadius = Constants.radarEnemyRadiusRadarType2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalRadius = Constants.radarEnemyRadiusRadarType3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalRadius = Constants.radarEnemyRadiusRadarType4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalRadius = Constants.radarEnemyRadiusRadarType5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalRadius = Constants.radarEnemyRadiusRadarType1;
                break;
        }
        return finalRadius;
    }

    private RadarEnemy loadTypeRadar(SpacecraftEnemy spacecraft) {
        RadarEnemy typeRadar;
        switch (spacecraft)
        {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                typeRadar = RadarEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                typeRadar = RadarEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                typeRadar = RadarEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                typeRadar = RadarEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                typeRadar = RadarEnemy.TYPE_1;
                break;
        }
        return typeRadar;
    }

    private void removeFromDictionary<T>(IdentificatorModel identificator, Dictionary<IdentificatorModel, T> dictionary) {
        if (!dictionary.ContainsKey(identificator)) return;
        dictionary.Remove(identificator);
    }
}