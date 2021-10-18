using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadStructureUseCase {
    bool invoke();
}
public class SpacecraftPlayerLoadStructureUseCaseImpl : SpacecraftPlayerLoadStructureUseCase
{
    private SpacecraftPlayerStructureRepository repo = new SpacecraftPlayerStructureRepositoryImpl();

    public bool invoke() => repo.loadStructure();
}