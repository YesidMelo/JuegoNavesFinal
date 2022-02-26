using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperLevelExtentionsMaterial_Level1Section1 : HelperLevelExtentionsMaterialBase
{
    public HelperLevelExtentionsMaterial_Level1Section1(Level level, Material material) : base(level, material){}

    public override int getMaxMaterial()
    {
        switch (material) {
            case Material.MATERIAL_1:
                return 1;
            default:
                return 0;
        }
    }
}