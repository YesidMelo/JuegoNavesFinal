using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyStructureCache {
    StructureEnemy currentStructure(IdentificatorModel identificator);
    void deleteStructure(IdentificatorModel identificator);
    bool loadStructure(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
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

    //private methods
    private StructureEnemy loadStructureByTypeSpacecraft(SpacecraftEnemy spacecraft) {
        StructureEnemy finalStructure;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalStructure = StructureEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalStructure = StructureEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalStructure = StructureEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalStructure = StructureEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalStructure = StructureEnemy.TYPE_1;
                break;
        }
        return finalStructure;
    }
}