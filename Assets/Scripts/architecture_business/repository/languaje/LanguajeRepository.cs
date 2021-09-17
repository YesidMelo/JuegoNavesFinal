using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LanguajeRepository { 
    AbstractLanguage currentLanguaje { get; }
    void updateLanguaje(LaguageAvailable laguage);
}

public class LanguajeRepositoryImpl : LanguajeRepository
{
    private LaguajeCache laguajeCache = LaguageCacheImpl.getInstance();

    public AbstractLanguage currentLanguaje => laguajeCache.currentLangaje;

    public void updateLanguaje(LaguageAvailable laguaje) => laguajeCache.updateCurrentLanguaje(laguaje);
}
