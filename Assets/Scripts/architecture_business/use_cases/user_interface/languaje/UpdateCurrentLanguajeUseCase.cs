using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UpdateCurrentLanguajeUseCase {
    void invoke(LaguageAvailable laguaje);
}

public class UpdateCurrentLanguajeUseCaseImpl : UpdateCurrentLanguajeUseCase
{
    private LanguajeRepository repository = new LanguajeRepositoryImpl();

    public void invoke(LaguageAvailable laguaje) => repository.updateLanguaje(laguaje);
}
