using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyMotorRepository {
    float currentSpeed(IdentificatorModel identificator);
    MotorEnemy currentMotor(IdentificatorModel identificator);
    bool loadMotor(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeMotor(IdentificatorModel identificator);
    void clearCache();
}
public class SpacecraftEnemyMotorRepositoryImpl: SpacecraftEnemyMotorRepository {

    private SpacecraftEnemyMotorCache cache = SpacecraftEnemyMotorCacheImpl.getInstance();

    public void clearCache() => SpacecraftEnemyMotorCacheImpl.destroyInstance();

    public MotorEnemy currentMotor(IdentificatorModel identificator) => cache.currentMotor(identificator);

    public float currentSpeed(IdentificatorModel identificator) => cache.currentSpeed(identificator);

    public bool loadMotor(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadMotor(identificator, spacecraft);

    public void removeMotor(IdentificatorModel identificator) => cache.removeMotor(identificator);
}