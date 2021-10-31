using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyMotorCache {
    float currentSpeed(IdentificatorModel identificator);
    MotorEnemy currentMotor(IdentificatorModel identificator);
    bool loadMotor(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeMotor(IdentificatorModel identificator);
}
public class SpacecraftEnemyMotorCacheImpl : SpacecraftEnemyMotorCache
{
    //static variables
    private static SpacecraftEnemyMotorCacheImpl instance;

    //static methods
    public static SpacecraftEnemyMotorCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyMotorCacheImpl();
        }
        return instance;
    }

    private Dictionary<IdentificatorModel, float> _dictionarySpeed = new Dictionary<IdentificatorModel, float>();
    private Dictionary<IdentificatorModel, MotorEnemy> _dictionaryMotors = new Dictionary<IdentificatorModel, MotorEnemy>();
    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecraft = new Dictionary<IdentificatorModel, SpacecraftEnemy>();

    public MotorEnemy currentMotor(IdentificatorModel identificator) => _dictionaryMotors[identificator];

    public float currentSpeed(IdentificatorModel identificator) => _dictionarySpeed[identificator];

    public bool loadMotor(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        _dictionarySpacecraft[identificator] = spacecraft;
        _dictionaryMotors[identificator] = currentMotor(spacecraft);
        _dictionarySpeed[identificator] = currentSpeed(spacecraft);
        return true;
    }

    public void removeMotor(IdentificatorModel identificator)
    {
        removeFromDictionary(identificator,_dictionaryMotors);
        removeFromDictionary(identificator,_dictionarySpacecraft);
        removeFromDictionary(identificator,_dictionarySpeed);
    }

    //private methods
    private float currentSpeed(SpacecraftEnemy spacecraft) {
        float finalSpeed = 0;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalSpeed = Constants.speedMotorEnemyType2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalSpeed = Constants.speedMotorEnemyType3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalSpeed = Constants.speedMotorEnemyType4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalSpeed = Constants.speedMotorEnemyType5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalSpeed = Constants.speedMotorEnemyType1;
                break;
        }
        return finalSpeed;
    }

    private MotorEnemy currentMotor(SpacecraftEnemy spacecraft) {
        MotorEnemy finalMotor;
        switch (spacecraft)
        {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalMotor = MotorEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalMotor = MotorEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalMotor = MotorEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalMotor = MotorEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalMotor = MotorEnemy.TYPE_1;
                break;
        }
        return finalMotor;
    }

    private void removeFromDictionary<T>(IdentificatorModel identificator, Dictionary<IdentificatorModel, T> dictionary)
    {
        if (!dictionary.ContainsKey(identificator)) return;
        dictionary.Remove(identificator);
    }
}