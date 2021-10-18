using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateStructureUseCase {
    void invoke(StructurePlayer structurePlayer);
}
public class SpacecraftPlayerUpdateStructureUseCaseImpl : SpacecraftPlayerUpdateStructureUseCase
{
    private SpacecraftPlayerStructureRepository repo = new SpacecraftPlayerStructureRepositoryImpl();

    public void invoke(StructurePlayer structurePlayer) => repo.updateStructure(structurePlayer);
}
