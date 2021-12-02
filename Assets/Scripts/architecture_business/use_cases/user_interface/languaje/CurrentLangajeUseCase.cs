using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CurrentLangajeUseCase {
    AbstractLanguage invoke();
}

public class CurrentLangajeUseCaseImpl : CurrentLangajeUseCase
{
    private LanguajeRepository languajeRepository = new LanguajeRepositoryImpl();

    public AbstractLanguage invoke() => languajeRepository.currentLanguaje;
}
