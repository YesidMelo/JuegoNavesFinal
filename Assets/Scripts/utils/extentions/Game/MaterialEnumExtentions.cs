using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialEnumExtentions 
{
    public static long getSpeedRefination(this Material currentMaterial) {
        switch (currentMaterial) {
            default:
                return 0;
        }
    }

    public static long getIdDB(this Material currentMaterial) {
        switch (currentMaterial) {
            case Material.MATERIAL_1: return 1;
            case Material.MATERIAL_2: return 2;
            case Material.MATERIAL_3: return 3;
            case Material.MATERIAL_4: return 4;
            case Material.MATERIAL_5: return 5;
            case Material.MATERIAL_6: return 6;
            case Material.MATERIAL_7: return 7;
            case Material.MATERIAL_8: return 8;
            case Material.MATERIAL_9: return 9;
            default:
                return 0;
        }
    }

    public static Sprite getSpriteByMaterial(this Material material, List<Sprite> listSpriteMaterials) {
        if (listSpriteMaterials.Count == 0) return null;
        foreach (Sprite currentSprite in listSpriteMaterials) {
            string nameSpriteCheck = string.Format(Constants.nameMaterialSprite, material.getIdDB());
            if (!currentSprite.name.Contains(nameSpriteCheck)) continue;
            return currentSprite;
        }
        return listSpriteMaterials[0];
    }

}
