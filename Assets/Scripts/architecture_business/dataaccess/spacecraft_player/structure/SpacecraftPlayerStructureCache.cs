using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStructureCache { 
    StructurePlayer currentStructure { get; }
    bool loadStructure();
    void updateStructure(StructurePlayer structure);
}
public class SpacecraftPlayerStructureCacheImpl : SpacecraftPlayerStructureCache
{
    //static variables
    private static SpacecraftPlayerStructureCacheImpl instance;

    //static methods
    public static SpacecraftPlayerStructureCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerStructureCacheImpl();
        }
        return instance;
    }

    // variables
    private StructurePlayer _currentStructure = StructurePlayer.TYPE_1;

    private SpacecraftPlayerStructureCacheImpl() { }


    public StructurePlayer currentStructure => _currentStructure;

    public void updateStructure(StructurePlayer structure) => _currentStructure = structure;

    public bool loadStructure()
    {
        return true;
    }
}
