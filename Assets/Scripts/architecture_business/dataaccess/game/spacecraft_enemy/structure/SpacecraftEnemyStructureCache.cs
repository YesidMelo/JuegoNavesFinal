using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyStructureCache {
    StructureEnemy currentStructure(IdentificatorModel identificator);
    void deleteStructure(IdentificatorModel identificator);
    bool loadStructure(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void clearCache();
}

public class SpacecraftEnemyStructureCacheImpl : SpacecraftEnemyStructureCache
{
    //static variables
    private static SpacecraftEnemyStructureCacheImpl instance;

    //static methods
    public static SpacecraftEnemyStructureCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyStructureCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private Dictionary<IdentificatorModel, StructureEnemy> _dictionaryStructures = new Dictionary<IdentificatorModel, StructureEnemy>();

    public StructureEnemy currentStructure(IdentificatorModel identificator) => _dictionaryStructures[identificator];

    public void deleteStructure(IdentificatorModel identificator)
    {
        if (!_dictionaryStructures.ContainsKey(identificator)) return;
        _dictionaryStructures.Remove(identificator);
    }

    public bool loadStructure(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        _dictionaryStructures[identificator] = loadStructureByTypeSpacecraft(spacecraft);
        return true;
    }

    public void clearCache()
    {
        _dictionaryStructures.Clear();
    }

    //private methods
    private StructureEnemy loadStructureByTypeSpacecraft(SpacecraftEnemy spacecraft) {
        StructureEnemy finalStructure;
        switch (spacecraft) {
            case SpacecraftEnemy.LIEUTENENTS:
                finalStructure = StructureEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.MAJOR:
                finalStructure = StructureEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                finalStructure = StructureEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.COLONEL:
                finalStructure = StructureEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
            default:
                finalStructure = StructureEnemy.TYPE_1;
                break;
        }
        return finalStructure;
    }

}