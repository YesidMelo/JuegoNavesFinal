using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelEnumExtentions{
    public static int getMaxEnemies(this Level currentLevel, SpacecraftEnemy currentEspacecraft) {
        int currentEnemies;
        switch (currentLevel) {
            default:
                currentEnemies = currentEnemiesLevel1(currentEspacecraft);
                break;
        }
        return currentEnemies;
    }

    private static int currentEnemiesLevel1(SpacecraftEnemy spacecraft) {
        int currentEnemies;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
                currentEnemies = 3;
                break;
            default:
                currentEnemies = 0;
                break;
        }
        return currentEnemies;
    }
}
