using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HelperLevelExtentionCounterEnemiesBase {

    //static methods
    public static HelperLevelExtentionCounterEnemiesBase getCheckerEnemiesByLevel(Level level, SpacecraftEnemy spacecraftEnemy) {
        if (level == Level.LEVEL1_SECTION2) {
            return new HelperLevelExtentionCounterEnemies_Level1Section2(level, spacecraftEnemy);
        }
        return new HelperLevelExtentionCounterEnemies_Level1Section1(level, spacecraftEnemy);
    }

    //variables
    protected Level currentLevel;
    protected SpacecraftEnemy currentSpacecraftEnemy;

    protected HelperLevelExtentionCounterEnemiesBase(
        Level level,
        SpacecraftEnemy spacecraftEnemy
    ) {
        this.currentLevel = level;
        this.currentSpacecraftEnemy = spacecraftEnemy;
    }

    public abstract int maxEnemies();
}