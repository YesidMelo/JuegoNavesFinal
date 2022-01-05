using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StoragePlayerEnumExtentions {

    public static long getIdDb(this StoragePlayer currentStorage) { 
        switch(currentStorage) {
            case StoragePlayer.TYPE_2:
                return Constants.storagePlayerIdDBType2;
            case StoragePlayer.TYPE_3:
                return Constants.storagePlayerIdDBType3;
            case StoragePlayer.TYPE_4:
                return Constants.storagePlayerIdDBType4;
            case StoragePlayer.TYPE_5:
                return Constants.storagePlayerIdDBType5;
            default:
                return Constants.storagePlayerIdDBType1;
        }    
    }

    public static StoragePlayer getStoragePlayerByIdDB(this StoragePlayer currentStorage, long? id) {
        if (id == Constants.storagePlayerIdDBType2) return StoragePlayer.TYPE_2;
        if (id == Constants.storagePlayerIdDBType3) return StoragePlayer.TYPE_3;
        if (id == Constants.storagePlayerIdDBType4) return StoragePlayer.TYPE_4;
        if (id == Constants.storagePlayerIdDBType5) return StoragePlayer.TYPE_5;
        return StoragePlayer.TYPE_1;
    }

}