using System;

public interface IHelperHandlerScencePopulationGeneratorDelegate {
    void generateSpacecraft(SpacecraftEnemy spacecraftEnemy, int missing);
}

public interface IHelperHandlerScencePopulationGenerator {
    IHelperHandlerScencePopulationGeneratorDelegate myDelegate { get; set; }
    void checkPopulationLevel();
}

public class HelperHandlerScencePopulationGeneratorImpl : IHelperHandlerScencePopulationGenerator
{
    private readonly StatusGameGetCurrentStatusUseCase getCurrentStatusUseCase = new StatusGameGetCurrentStatusUseCaseImpl();
    private readonly StatusGameIsGameInPauseUseCase gameIsGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();
    private readonly StagePopulationIsAllPoblationUseCase isAllPoblationUseCase = new StagePopulationIsAllPoblationUseCaseImpl();
    private readonly LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private readonly StagePopulationGetEnemiesMissingInThePopulationUseCase getEnemiesMissingInThePopulationUseCase = new StagePopulationGetEnemiesMissingInThePopulationUseCaseImpl();

    private IHelperHandlerScencePopulationGeneratorDelegate _myDelegate;
    private bool generateEnemies = false;

    public IHelperHandlerScencePopulationGeneratorDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    //public methods

    public void checkPopulationLevel()
    {
        if (!iCanGeneratePopulation()) return;
        generateEnemies = true;
        foreach (SpacecraftEnemy spacecraftEnemy in Enum.GetValues(typeof(SpacecraftEnemy))) {
            int maxInLevel = getCurrentLevelUseCase.invoke().getMaxEnemies(currentEspacecraft: spacecraftEnemy);
            int currentInScence = getEnemiesMissingInThePopulationUseCase.invoke(enemy: spacecraftEnemy);
            if (areAllTheShipsOfThisLevel(maxInLevel: maxInLevel, currentInScence: currentInScence)) continue;

            int missing = maxInLevel - currentInScence;
            _myDelegate.generateSpacecraft(spacecraftEnemy: spacecraftEnemy, missing: missing);
        }
        generateEnemies = false;
    }

    //private methods
    private bool iCanGeneratePopulation() {
        if (_myDelegate == null) return false;
        if (gameIsGameInPauseUseCase.invoke()) return false;
        if(getCurrentStatusUseCase.invoke() != StatusGame.IN_GAME) return false;
        if (isAllPoblationUseCase.invoke()) return false;
        if (generateEnemies) return false;
        return true;
    }

    private bool areAllTheShipsOfThisLevel(int maxInLevel, int currentInScence) {
        if (maxInLevel == 0) return true;
        if (currentInScence >= maxInLevel) return true;
        return false;
    }

}