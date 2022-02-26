using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HelperLevelExtentionsMaterialBase {

    //static methods
    public static HelperLevelExtentionsMaterialBase getCounterMaterial(Level level, Material material) {
        return new HelperLevelExtentionsMaterial_Level1Section1(level:level, material: material) ;
    }

    //variables
    protected Level level;
    protected Material material;


    protected HelperLevelExtentionsMaterialBase(Level level, Material material) {
        this.level = level;
        this.material = material;
    }

    //public methods
    public abstract int getMaxMaterial();
}