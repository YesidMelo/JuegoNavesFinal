using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStructureCache { 
    StructurePlayer currentStructure { get; }
    StructureModel currentStructureModel { get; }
    bool loadStructure();
    void setCurrentStructureModel(StructureModel structureModel);
    void updateStructure(StructurePlayer structure);
    public void clearCache();

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

    public static void destroyInstance() => instance = null;

    // variables
    private StructurePlayer _currentStructure = StructurePlayer.TYPE_1;
    private StructureModel _currentStructureModel = new StructureModel();

    private SpacecraftPlayerStructureCacheImpl() { }


    public StructurePlayer currentStructure => _currentStructure;

    public StructureModel currentStructureModel => _currentStructureModel;

    public void clearCache()
    {
        _currentStructure = StructurePlayer.TYPE_1;
        _currentStructureModel = new StructureModel();
    }

    public void updateStructure(StructurePlayer structure) { 
        _currentStructure = structure;
        _currentStructureModel.currentStructure = _currentStructure;
    }

    public bool loadStructure()
    {
        _currentStructureModel.currentStructure = _currentStructure;
        return true;
    }

    public void setCurrentStructureModel(StructureModel structureModel)
    {
        _currentStructureModel = structureModel;
        _currentStructure = _currentStructureModel.currentStructure;
    }

}
