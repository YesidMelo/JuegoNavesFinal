using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStructureRepository {
    StructurePlayer currentStructure { get; }
    bool loadStructure();
    void updateStructure(StructurePlayer structure);
}

public class SpacecraftPlayerStructureRepositoryImpl : SpacecraftPlayerStructureRepository {

    private SpacecraftPlayerStructureCache cache = SpacecraftPlayerStructureCacheImpl.getInstance();

    public StructurePlayer currentStructure => cache.currentStructure;

    public bool loadStructure() => cache.loadStructure();

    public void updateStructure(StructurePlayer structure) => cache.updateStructure(structure);
}