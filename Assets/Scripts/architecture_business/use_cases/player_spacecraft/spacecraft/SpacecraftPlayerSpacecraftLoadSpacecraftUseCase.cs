using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerSpacecraftLoadSpacecraftUseCase {
    IEnumerator invoke();
}

public class SpacecraftPlayerSpacecraftLoadSpacecraftUseCaseImpl : SpacecraftPlayerSpacecraftLoadSpacecraftUseCase
{
    private SpacecraftPlayerRepository repository = new SpacecraftPlayerRepositoryImpl();

    public IEnumerator invoke() => repository.loadSpacecraft();
}