using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStructureRepository {
    StructurePlayer currentStructure { get; }
    StructureModel currentStructureModel { get; }
    bool loadStructure();
    void setCurrentStructureModel(StructureModel structureModel);
    void updateStructure(StructurePlayer structure);
    public void clearCache();
}

public class SpacecraftPlayerStructureRepositoryImpl : SpacecraftPlayerStructureRepository {

    private SpacecraftPlayerStructureCache cache = SpacecraftPlayerStructureCacheImpl.getInstance();

    public StructurePlayer currentStructure => cache.currentStructure;

    public StructureModel currentStructureModel => cache.currentStructureModel;

    public void clearCache() => cache.clearCache();
    public bool loadStructure() => cache.loadStructure();
    public void setCurrentStructureModel(StructureModel structureModel) => cache.setCurrentStructureModel(structureModel: structureModel);
    public void updateStructure(StructurePlayer structure) => cache.updateStructure(structure);
}