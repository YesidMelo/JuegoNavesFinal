using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StructurePlayerEnumExtentions {

    public static long getIdDB(this StructurePlayer currentStructure) {
        switch (currentStructure) {
            case StructurePlayer.TYPE_2:
                return 2;
            case StructurePlayer.TYPE_3:
                return 3;
            case StructurePlayer.TYPE_4:
                return 4;
            case StructurePlayer.TYPE_5:
                return 5;
            default:
                return 1;
        }
    }
}