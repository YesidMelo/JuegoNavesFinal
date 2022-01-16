using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelEnumExtentions{

    //public methods
    public static int getMaxEnemies(this Level currentLevel, SpacecraftEnemy currentEspacecraft) {
        int currentEnemies;
        switch (currentLevel) {
            default:
                currentEnemies = currentEnemiesLevel1(currentEspacecraft);
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

            default:
                nameSprite = Constants.nameSpriteDefault;
                break;
        }

        return nameSprite;
    }

    //private methods

    private static int currentEnemiesLevel1(SpacecraftEnemy spacecraft) {
        int currentEnemies;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
                currentEnemies = 1;
                break;
            default:
                currentEnemies = 0;
                break;
        }
        return currentEnemies;
    }

}
