using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StructureEnemyEnumExtentions {

    public static Sprite getCurrentSprite(
        this StructureEnemy structureEnemy,
        SpacecraftEnemy spacecraftEnemy,
        Level level, 
        List<Sprite> listSprite) {
        if (listSprite == null || listSprite.Count == 0) return null;
        if (listSprite.Count == 1) return listSprite[0];
        return getSpriteByLevel(level: level, spacecraftEnemy: spacecraftEnemy, listSprites: listSprite);
    }

    //private methods
    private static Sprite getSpriteByLevel(Level level, SpacecraftEnemy spacecraftEnemy, List<Sprite> listSprites) {
        switch (level) {
            case Level.LEVEL1_SECTION2:
                return getSpriteBySpacecraftEnemyLevel1Section2(spacecraftEnemy: spacecraftEnemy, listSprites: listSprites);
            default:
                return getSpriteBySpacecraftEnemyLevel1Section1(spacecraftEnemy: spacecraftEnemy, listSprites: listSprites);
        }
    }

    private static Sprite getSpriteBySpacecraftEnemyLevel1Section1(SpacecraftEnemy spacecraftEnemy, List<Sprite> listSprites) {
        string baseNameSprite = "test_spacecraft_enemy_";
        switch (spacecraftEnemy) {
            case SpacecraftEnemy.LIEUTENENTS:
                return getSpriteByName(nameSprite: $"{baseNameSprite}1", listSprites: listSprites);
            default:
                return getSpriteByName(nameSprite: $"{baseNameSprite}0", listSprites: listSprites);
        }
    }
    
    private static Sprite getSpriteBySpacecraftEnemyLevel1Section2(SpacecraftEnemy spacecraftEnemy, List<Sprite> listSprites) {
        string baseNameSprite = "test_spacecraft_enemy_";
        switch (spacecraftEnemy) {
            case SpacecraftEnemy.BRIGADUERGENERAL:
                return getSpriteByName(nameSprite: $"{baseNameSprite}3", listSprites: listSprites);
            default:
                return getSpriteByName(nameSprite: $"{baseNameSprite}4", listSprites: listSprites);
        }
    }

    private static Sprite getSpriteByName(string nameSprite, List<Sprite> listSprites) {
        foreach (Sprite currentSprite in listSprites) {
            if (!currentSprite.name.Contains(nameSprite)) continue;
            return currentSprite;
        }
        return listSprites[0];
    }
}