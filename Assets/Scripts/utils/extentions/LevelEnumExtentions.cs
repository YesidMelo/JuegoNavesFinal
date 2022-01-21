using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelEnumExtentions{

    //public methods
    public static int getMaxEnemies(this Level currentLevel, SpacecraftEnemy currentEspacecraft) {
        int currentEnemies;
        switch (currentLevel) {
            case Level.LEVEL1_SECTION2:
                currentEnemies = currentEnemiesLevel1Section2(currentEspacecraft);
                break;
            default:
                currentEnemies = currentEnemiesLevel1Section1(currentEspacecraft);
                break;
        }
        return currentEnemies;
    }

    public static Sprite getCurrentBackground(this Level currentLevel, List<Sprite> listSprites) {
        if (listSprites == null || listSprites.Count == 0) return null;
        foreach (Sprite currentSprite in listSprites) {
            if (currentSprite.name != currentLevel.getNameSpriteBackground()) continue;
            return currentSprite;
        }
        return null;
    }

    public static string getNameSpriteBackground(this Level level)
    {
        string nameSprite = null;

        switch (level) {
            case Level.LEVEL1_SECTION2:
                nameSprite = Constants.nameSpriteBackgroundLevel1Section2;
                break;
            case Level.LEVEL1_SECTION1:
                nameSprite = Constants.nameSpriteBackgroundLevel1Section1;
                break;
            default:
                nameSprite = Constants.nameSpriteBackgroundDefault;
                break;
        }

        return nameSprite;
    }

    //private methods

    private static int currentEnemiesLevel1Section1(SpacecraftEnemy spacecraft) {
        int currentEnemies;
        switch (spacecraft) {
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
                currentEnemies = 1;
                break;
            default:
                currentEnemies = 0;
                break;
        }
        return currentEnemies;
    }

    private static int currentEnemiesLevel1Section2(SpacecraftEnemy spacecraft) {
        int currentEnemies;
        switch (spacecraft) {
            case SpacecraftEnemy.BRIGADUERGENERAL:
                currentEnemies = 1;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
                currentEnemies = 0;
                break;
            default:
                currentEnemies = 0;
                break;
        }
        return currentEnemies;
    }

}
