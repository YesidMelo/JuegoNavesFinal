using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SaveGameClearCachesGameUseCase {
    Task invoke();
}

public class SaveGameClearCachesGameUseCaseImpl : SaveGameClearCachesGameUseCase
{
    private LevelRepository levelRepository = new LevelRepositoryImpl();

    //enemies
    private SpacecraftEnemyLaserRepository spacecraftEnemyLaserRepository = new SpacecraftEnemyLaserRepositoryImpl();
    private SpacecraftEnemyLifeRepository spacecraftEnemyLifeRepository = new SpacecraftEnemyLifeRepositoryImpl();
    private SpacecraftEnemyMotorRepository spacecraftEnemyMotorRepository = new SpacecraftEnemyMotorRepositoryImpl();
    private SpacecraftEnemyRadarRepository spacecraftEnemyRadarRepository = new SpacecraftEnemyRadarRepositoryImpl();
    private SpacecraftEnemyShieldRepository spacecraftEnemyShieldRepository = new SpacecraftEnemyShieldRepositoryImpl();
    private SpacecraftEnemyStorageRepository spacecraftEnemyStorageRepository = new SpacecraftEnemyStorageRepositoryImpl();
    private SpacecraftEnemyStructureRepository spacecraftEnemyStructureRepository = new SpacecraftEnemyStructureRepositoryImpl();

    //player
    private SpacecraftPlayerLaserRepository spacecraftPlayerLaserRepository = new SpacecraftPlayerLaserRepositoryImpl();
    private SpacecraftPlayerLifeRepository spacecraftPlayerLifeRepository = new SpacecraftPlayerLifeRepositoryImpl();
    private SpacecraftPlayerMotorRepository spacecraftPlayerMotorRepository = new SpacecraftPlayerMotorRepositoryImpl();
    private SpacecraftPlayerRadarRepository spacecraftPlayerRadarRepository = new SpacecraftPlayerRadarRepositoryImpl();
    private SpacecraftPlayerShieldRepository spacecraftPlayerShieldRepository = new SpacecraftPlayerShieldRepositoryImpl();
    private SpacecraftPlayerStorageRepository spacecraftPlayerStorageRepository = new SpacecraftPlayerStorageRepositoryImpl();
    private SpacecraftPlayerStructureRepository spacecraftPlayerStructureRepository = new SpacecraftPlayerStructureRepositoryImpl();

    public async Task invoke()
    {
        levelRepository.clearCache();
        clearEnemyCache();
        clearPlayerCache();
    }

    //private methods
    private void clearEnemyCache() {
        spacecraftEnemyLaserRepository.clearCache();
        spacecraftEnemyLifeRepository.clearCache();
        spacecraftEnemyMotorRepository.clearCache();
        spacecraftEnemyRadarRepository.clearCache();
        spacecraftEnemyShieldRepository.clearCache();
        spacecraftEnemyStorageRepository.clearCache();
        spacecraftEnemyStructureRepository.clearCache();
    }

    private void clearPlayerCache() {
        spacecraftPlayerLaserRepository.clearCache();
        spacecraftPlayerLifeRepository.clearCache();
        spacecraftPlayerMotorRepository.clearCache();
        spacecraftPlayerRadarRepository.clearCache();
        spacecraftPlayerShieldRepository.clearCache();
        spacecraftPlayerStorageRepository.clearCache();
        spacecraftPlayerStructureRepository.clearCache();
    }
}