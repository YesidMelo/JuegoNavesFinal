using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SplashLoadElementsUseCase {
    string getNameGame { get; }
    Task<bool> invoke();
}

public class SplashLoadElementsUseCaseImpl : SplashLoadElementsUseCase
{
    private CurrentLangajeUseCase langajeUseCase = new CurrentLangajeUseCaseImpl();

    private SplashRepository repository = new SplashRepositoryImpl();
    private AbstractLanguage _currentLanguaje;

    public SplashLoadElementsUseCaseImpl() {
        _currentLanguaje = langajeUseCase.invoke();
    }

    public string getNameGame => _currentLanguaje.getNameTag(NameTagLanguage.NAME_GAME);

    public async Task<bool> invoke() {
        return await Task.Run<bool>(async () => {
            return await repository.loadElementsGame();
        });
    }
}