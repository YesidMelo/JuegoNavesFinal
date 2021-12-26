using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveStorageNewGameLocalDatasource {

    private long idGameModel;
    private StorageModel storageModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveStorageNewGameLocalDatasource initValues(
        long idGameModel,
        StorageModel storageModel
    ) {
        this.idGameModel = idGameModel;
        this.storageModel = storageModel;
        return this;
    }

    public async Task<bool> saveStorage() {
        StorageEntity storageEntity = new StorageEntity();
        storageEntity.gameModelId = idGameModel;
        storageEntity.typeStorageId = storageModel.currentStorage.getIdDb();
        await databaseManager.insert(element: storageEntity);
        return true;
    }
}