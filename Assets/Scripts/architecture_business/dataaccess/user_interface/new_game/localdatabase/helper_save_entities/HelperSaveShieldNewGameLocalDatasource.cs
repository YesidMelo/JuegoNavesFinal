using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveShieldNewGameLocalDatasource {

    private long idGameModel;
    private ShieldModel shieldModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveShieldNewGameLocalDatasource initValues(
        long idGameModel,
        ShieldModel shieldModel
    ) {
        this.idGameModel = idGameModel;
        this.shieldModel = shieldModel;
        return this;
    }

    public async Task<bool> saveShield() {
        ShieldEntity shieldEntity = new ShieldEntity();
        shieldEntity.gameModelId = idGameModel;
        shieldEntity.typeShieldId = shieldModel.currentShield.getIdDb();
        await databaseManager.insert(element: shieldEntity);
        return true;
    }

}