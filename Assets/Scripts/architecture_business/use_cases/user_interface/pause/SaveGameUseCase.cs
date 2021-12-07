using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SaveGameUseCase {
    Task<bool> invoke();
}

public class SaveGameUseCaseImpl : SaveGameUseCase
{
    private NewGameRepository newGameRepository = new NewGameRepositoryImpl();
    private SpacecraftPlayerLaserRepository repoLaserPlayer = new SpacecraftPlayerLaserRepositoryImpl();
    private SpacecraftPlayerLifeRepository repoLifePlayer = new SpacecraftPlayerLifeRepositoryImpl();
    private SpacecraftPlayerMotorRepository repoMotorPlayer = new SpacecraftPlayerMotorRepositoryImpl();
    private SpacecraftPlayerRadarRepository repoRadar = new SpacecraftPlayerRadarRepositoryImpl();
    private SpacecraftPlayerShieldRepository repoShield = new SpacecraftPlayerShieldRepositoryImpl();
    private SpacecraftPlayerStorageRepository repoStorage = new SpacecraftPlayerStorageRepositoryImpl();
    private SpacecraftPlayerStructureRepository repoStructure = new SpacecraftPlayerStructureRepositoryImpl();

    public async Task<bool> invoke() => await newGameRepository.saveGame();
    
}