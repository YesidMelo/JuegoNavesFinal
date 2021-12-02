using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SplashLoadElementsUseCase {
    Task<bool> invoke();
}

public class SplashLoadElementsUseCaseImpl : SplashLoadElementsUseCase
{
    private SplashRepository repository = new SplashRepositoryImpl();

    public async Task<bool> invoke() {
        return await Task.Run<bool>(async () => {
            return await repository.loadElementsGame();
        });
    }
}