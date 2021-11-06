using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyDestroySpacecraftUseCase {
    void invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyDestroySpacecraftUseCaseImpl : SpacecraftEnemyDestroySpacecraftUseCase
{
    private SpacecraftEnemyDeleteLaserUseCase deleteLaserUseCase = new SpacecraftEnemyDeleteLaserUseCaseImpl();
    private StructureEnemyDeleteStructureUseCase deleteStructureUseCase = new StructureEnemyDeleteStructureUseCaseImpl();
    private SpacecraftEnemyRemoveLifeUseCase removeLifeUseCase = new SpacecraftEnemyRemoveLifeUseCaseImpl();
    private SpacecraftEnemyRemoveMotorUseCase removeMotorUseCase = new SpacecraftEnemyRemoveMotorUseCaseImpl();
    private SpacecraftEnemyRemoveRadarUseCase removeRadarUseCase = new SpacecraftEnemyRemoveRadarUseCaseImpl();
    private SpacecraftEnemyRemoveShieldUseCase removeShieldUseCase = new SpacecraftEnemyRemoveShieldUseCaseImpl();
    private SpacecraftEnemyRemoveStorageUseCase removeStorageUseCase = new SpacecraftEnemyRemoveStorageUseCaseImpl();

    public void invoke(IdentificatorModel identificator)
    {
        deleteLaserUseCase.invoke(identificator);
        deleteStructureUseCase.invoke(identificator);
        removeLifeUseCase.invoke(identificator);
        removeMotorUseCase.invoke(identificator);
        removeRadarUseCase.invoke(identificator);
        removeShieldUseCase.invoke(identificator);
        removeStorageUseCase.invoke(identificator);
    }
}