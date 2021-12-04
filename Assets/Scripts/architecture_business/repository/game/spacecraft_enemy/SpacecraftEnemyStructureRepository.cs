using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyStructureRepository {
    StructureEnemy currentStructure(IdentificatorModel identificator);
    void deleteStructure(IdentificatorModel identificator);
    bool loadStructure(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
}
public class SpacecraftEnemyStructureRepositoryImpl : SpacecraftEnemyStructureRepository {

    private SpacecraftEnemyStructureCache cache = SpacecraftEnemyStructureCacheImpl.getInstance();

    public StructureEnemy currentStructure(IdentificatorModel identificator) => cache.currentStructure(identificator);

    public void deleteStructure(IdentificatorModel identificator) => cache.deleteStructure(identificator);

    public bool loadStructure(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadStructure(identificator, spacecraft);

}