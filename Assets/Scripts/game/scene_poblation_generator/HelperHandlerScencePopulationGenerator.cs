using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public interface HelperHandlerScencePopulationGenerator {

    public delegate Task createEnemy(SpacecraftEnemy spacecraftEnemy, int missing);

    void startCheckPopulation(createEnemy create);
    void stopCheckCurrentStatusGame();
    List<GameObject> listAllEnemies { get;  }
}

public class HelperHandlerScencePopulationGeneratorImpl : HelperHandlerScencePopulationGenerator
{

    private StatusGameGetCurrentStatusUseCase getCurrentStatusUseCase = new StatusGameGetCurrentStatusUseCaseImpl();
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();
    private StagePopulationIsAllPoblationUseCase stagePopulationIsAllPoblationUseCase = new StagePopulationIsAllPoblationUseCaseImpl();
    private StagePopulationGetEnemiesMissingInThePopulationUseCase getEnemiesMissingInThePopulationUseCase = new StagePopulationGetEnemiesMissingInThePopulationUseCaseImpl();
    private GetAllEnemiesUseCase getAllEnemiesUseCase = new GetAllEnemiesUseCaseImpl();

    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();

    private HelperHandlerScencePopulationGenerator.createEnemy create;
    private bool continueCheckStatusGame = false;
    private StatusSpawmerPopulation statusSpawmerPopulation = StatusSpawmerPopulation.STOP;

    public HelperHandlerScencePopulationGeneratorImpl() {
        continueCheckStatusGame = true;
        checkStatusGame();
    }

    List<GameObject> HelperHandlerScencePopulationGenerator.listAllEnemies => getAllEnemiesUseCase.invoke();

    public void restartCheckPopulation()
    {
        if (create == null) return;

        Task.Run(
            () => {
                startCheckPopulation(create: create);
            } 
        );
    }

    public void startCheckPopulation(
        HelperHandlerScencePopulationGenerator.createEnemy create
    )
    {
        if (create != null) this.create = create;

        statusSpawmerPopulation = StatusSpawmerPopulation.START;
        Task.Run(async () => {

            statusSpawmerPopulation = StatusSpawmerPopulation.CHECK;
            while (isRunCheckCurrentStatus()) {

                await Task.Delay(Constants.timeAwaitCreateNewPrefab);
                if (isGameInPauseUseCase.invoke()) continue;
                if (stagePopulationIsAllPoblationUseCase.invoke()) continue;
                await createSpacecraftsMissing();
            }
        });
    }

    public void stopCheckCurrentStatusGame() => continueCheckStatusGame = false;

    //private methods

    private void checkStatusGame() {
        Task.Run(async () => {
            while (continueCheckStatusGame) {
                await Task.Delay(Constants.timeAwaitCheckStatusGame);
                if (!stopCheckStatusGame()) continue;
                break;
            }
            statusSpawmerPopulation = StatusSpawmerPopulation.STOP;
        });
    }

    private bool stopCheckStatusGame() {
        StatusGame currentStatus = getCurrentStatusUseCase.invoke();
        return currentStatus == StatusGame.MAIN_MENU;
    }

    private bool isRunCheckCurrentStatus() {
        return statusSpawmerPopulation == StatusSpawmerPopulation.START || statusSpawmerPopulation == StatusSpawmerPopulation.CHECK;
    }

    private async Task createSpacecraftsMissing() {
        
        StringBuilder builder = new StringBuilder();
        builder.Append($"currentLevel : {getCurrentLevelUseCase.invoke()}\n");
        try
        {
            foreach (SpacecraftEnemy spacecraftEnemy in Enum.GetValues(typeof(SpacecraftEnemy))) {

                int maxInLevel = getCurrentLevelUseCase.invoke().getMaxEnemies(currentEspacecraft: spacecraftEnemy);
                int currentInScene = getEnemiesMissingInThePopulationUseCase.invoke(enemy: spacecraftEnemy);

                builder.Append($" key: {spacecraftEnemy} value: {currentInScene} maxInLevel: {maxInLevel}\n");
                if (create == null) continue;
                if (maxInLevel == 0) continue;
                if (currentInScene >= maxInLevel) continue;

                int missing = maxInLevel - currentInScene;
                builder.Append($"current missing: {missing} currentValue: {spacecraftEnemy}\n");
                await create(spacecraftEnemy: spacecraftEnemy, missing: missing);
                
            }
        }catch (Exception e) {
            Debug.Log($"error: {e.Message}");
        }

        Debug.Log(builder.ToString());
    }

}

enum StatusSpawmerPopulation { 
    START,
    CHECK,
    STOP,
}
