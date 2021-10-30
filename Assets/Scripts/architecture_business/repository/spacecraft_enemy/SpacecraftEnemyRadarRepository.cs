using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRadarRepository {
    int radiusRadar(IdentificatorModel identificator);
    RadarEnemy currentRada(IdentificatorModel identificator);
    bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeRadar(IdentificatorModel identificator);
}
public class SpacecraftEnemyRadarRepositoryImpl : SpacecraftEnemyRadarRepository
{
    private SpacecraftEnemyRadarCache cache = SpacecraftEnemyRadarCacheImpl.getInstance();

    public RadarEnemy currentRada(IdentificatorModel identificator) => cache.currentRada(identificator);

    public bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadRadar(identificator, spacecraft);

    public int radiusRadar(IdentificatorModel identificator) => cache.radiusRadar(identificator);

    public void removeRadar(IdentificatorModel identificator) => cache.removeRadar(identificator);
}