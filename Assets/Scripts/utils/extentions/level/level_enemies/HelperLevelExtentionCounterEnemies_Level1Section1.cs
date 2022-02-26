using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperLevelExtentionCounterEnemies_Level1Section1 : HelperLevelExtentionCounterEnemiesBase
{
    public HelperLevelExtentionCounterEnemies_Level1Section1
        (Level level, SpacecraftEnemy spacecraftEnemy) 
        : base(level, spacecraftEnemy){}

    public override int maxEnemies()
    {
        int currentEnemies;
        switch (currentSpacecraftEnemy)
        {
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
                currentEnemies = 0;
                break;
            case SpacecraftEnemy.LIEUTENENTS:
                currentEnemies = 1;
                break;
            default:
                currentEnemies = 0;
                break;
        }
        return currentEnemies;
    }
}