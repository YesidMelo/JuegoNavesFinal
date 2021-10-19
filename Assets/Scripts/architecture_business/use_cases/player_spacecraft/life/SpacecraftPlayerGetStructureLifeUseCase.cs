using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetStructureLifeUseCase {
    StructurePlayer invoke();
}

public class SpacecraftPlayerGetStructureLifeUseCaseImpl : SpacecraftPlayerGetStructureLifeUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();
    public StructurePlayer invoke() => repo.currentStructure;
}