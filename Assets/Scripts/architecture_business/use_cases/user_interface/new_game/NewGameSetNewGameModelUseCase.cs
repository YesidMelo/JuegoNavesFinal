using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameSetNewGameModelUseCase {
    Task<bool> invoke(NewGameModel newGame);
}
public class NewGameSetNewGameModelUseCaseImpl : NewGameSetNewGameModelUseCase
{

    private NewGameRepository newGameRepository = new NewGameRepositoryImpl();

    public async Task<bool> invoke(NewGameModel newGame) {
        return await Task.Run(async ()=>{
            return await newGameRepository.setNewGameModel(newGameModel: newGame);
        });
    }
}