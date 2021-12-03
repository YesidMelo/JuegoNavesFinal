using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameGetCurrentNewGameModelUseCase {
    Task<NewGameModel> invoke();
}
public class NewGameGetCurrentNewGameModelUseCaseImpl : NewGameGetCurrentNewGameModelUseCase
{
    private NewGameRepository newGameRepository = new NewGameRepositoryImpl();

    public async Task<NewGameModel> invoke() { 
        return await newGameRepository.getCurrentNewGameModel();
    }
}