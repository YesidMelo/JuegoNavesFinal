using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateMaxLifeStructureUseCase {
    public void invoke(StructurePlayer structure);
}

public class SpacecraftPlayerUpdateMaxLifeStructureUseCaseImpl : SpacecraftPlayerUpdateMaxLifeStructureUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();
    public void invoke(StructurePlayer structure) => repo.addStructureLife(structure);
}