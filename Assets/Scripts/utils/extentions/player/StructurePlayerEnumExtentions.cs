using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StructurePlayerEnumExtentions {

    public static long getIdDB(this StructurePlayer currentStructure) {
        switch (currentStructure) {
            case StructurePlayer.TYPE_2:
                return Constants.structurePlayerIdDbTypeId2;
            case StructurePlayer.TYPE_3:
                return Constants.structurePlayerIdDbTypeId3;
            case StructurePlayer.TYPE_4:
                return Constants.structurePlayerIdDbTypeId4;
            case StructurePlayer.TYPE_5:
                return Constants.structurePlayerIdDbTypeId5;
            default:
                return Constants.structurePlayerIdDbTypeId1;
        }
    }

    public static StructurePlayer getStructurePlayerByIdDB(this StructurePlayer currentPlayer, long? id) {
        if (id == Constants.structurePlayerIdDbTypeId2) return StructurePlayer.TYPE_2;
        if (id == Constants.structurePlayerIdDbTypeId3) return StructurePlayer.TYPE_3;
        if (id == Constants.structurePlayerIdDbTypeId4) return StructurePlayer.TYPE_4;
        if (id == Constants.structurePlayerIdDbTypeId5) return StructurePlayer.TYPE_5;
        return StructurePlayer.TYPE_1;
    }
}