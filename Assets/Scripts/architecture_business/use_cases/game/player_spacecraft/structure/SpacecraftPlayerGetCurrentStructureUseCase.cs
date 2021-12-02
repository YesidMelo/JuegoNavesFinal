using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetCurrentStructureUseCase {
    StructurePlayer invoke();
}

public class SpacecraftPlayerGetCurrentStructureUseCaseImpl : SpacecraftPlayerGetCurrentStructureUseCase
{
    private SpacecraftPlayerStructureRepository repo = new SpacecraftPlayerStructureRepositoryImpl();

    public StructurePlayer invoke() => repo.currentStructure;
}