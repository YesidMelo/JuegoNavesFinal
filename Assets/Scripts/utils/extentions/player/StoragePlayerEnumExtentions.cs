using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StoragePlayerEnumExtentions {

    public static long getIdDb(this StoragePlayer currentStorage) { 
        switch(currentStorage) {
            case StoragePlayer.TYPE_2:
                return 2;
            case StoragePlayer.TYPE_3:
                return 3;
            case StoragePlayer.TYPE_4:
                return 4;
            case StoragePlayer.TYPE_5:
                return 5;
            default:
                return 1;
        }    
    }

}