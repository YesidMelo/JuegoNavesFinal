using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SaveGameClearCachesGameUseCase {
    Task invoke();
}

public class SaveGameClearCachesGameUseCaseImpl : SaveGameClearCachesGameUseCase
{
    private readonly LevelRepository levelRepository = new LevelRepositoryImpl();

    //enemies
    private readonly SpacecraftEnemyLaserRepository spacecraftEnemyLaserRepository = new SpacecraftEnemyLaserRepositoryImpl();
    private readonly SpacecraftEnemyLifeRepository spacecraftEnemyLifeRepository = new SpacecraftEnemyLifeRepositoryImpl();
    private readonly SpacecraftEnemyMotorRepository spacecraftEnemyMotorRepository = new SpacecraftEnemyMotorRepositoryImpl();
    private readonly SpacecraftEnemyRadarRepository spacecraftEnemyRadarRepository = new SpacecraftEnemyRadarRepositoryImpl();
    private readonly SpacecraftEnemyShieldRepository spacecraftEnemyShieldRepository = new SpacecraftEnemyShieldRepositoryImpl();
    private readonly SpacecraftEnemyStorageRepository spacecraftEnemyStorageRepository = new SpacecraftEnemyStorageRepositoryImpl();
    private readonly SpacecraftEnemyStructureRepository spacecraftEnemyStructureRepository = new SpacecraftEnemyStructureRepositoryImpl();

    //player
    private readonly SpacecraftPlayerLaserRepository spacecraftPlayerLaserRepository = new SpacecraftPlayerLaserRepositoryImpl();
    private readonly SpacecraftPlayerLifeRepository spacecraftPlayerLifeRepository = new SpacecraftPlayerLifeRepositoryImpl();
    private readonly SpacecraftPlayerMotorRepository spacecraftPlayerMotorRepository = new SpacecraftPlayerMotorRepositoryImpl();
    private readonly SpacecraftPlayerRadarRepository spacecraftPlayerRadarRepository = new SpacecraftPlayerRadarRepositoryImpl();
    private readonly SpacecraftPlayerShieldRepository spacecraftPlayerShieldRepository = new SpacecraftPlayerShieldRepositoryImpl();
    private readonly SpacecraftPlayerStorageRepository spacecraftPlayerStorageRepository = new SpacecraftPlayerStorageRepositoryImpl();
    private readonly SpacecraftPlayerStructureRepository spacecraftPlayerStructureRepository = new SpacecraftPlayerStructureRepositoryImpl();
    private readonly SpacecraftPlayerLifeSupportRepository spacecraftPlayerLifeSupportRepository = new SpacecraftPlayerLifeSupportRepositoryImpl();

    //portals
    private readonly PortalRepository portalRepository = new PortalRepositoryImpl();


    public async Task invoke()
    {
        levelRepository.clearCache();
        clearEnemyCache();
        clearPlayerCache();
        clearPortalCache();
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
        spacecraftPlayerLifeSupportRepository.clearCache();
    }

    private void clearPortalCache() {
        portalRepository.clearCache();
    }
}