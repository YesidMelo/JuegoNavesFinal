using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelEnumExtentions{

    //public methods
    public static int getMaxEnemies(this Level currentLevel, SpacecraftEnemy currentEspacecraft) {
        return HelperLevelExtentionCounterEnemiesBase
            .getCheckerEnemiesByLevel(level: currentLevel, spacecraftEnemy: currentEspacecraft)
            .maxEnemies();
    }

    public static int getMaxMaterial(this Level currentLevel, Material material) {
        return HelperLevelExtentionsMaterialBase
            .getCounterMaterial(level: currentLevel, material: material)
            .getMaxMaterial();
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

}
