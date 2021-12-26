using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveMotorNewGameLocalDatasource {

    private long idGameModel;
    private MotorModel motorModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveMotorNewGameLocalDatasource initValues(
        long idGameModel,
        MotorModel motorModel
    ) {
        this.idGameModel = idGameModel;
        this.motorModel = motorModel ;
        return this;
    }

    public async Task<bool> saveMotors() {
        List<MotorEntity> listMotorsEntities = new List<MotorEntity>();
        foreach (MotorPlayer currentMotor in motorModel.listMotors) {
            MotorEntity motorEntity = new MotorEntity();
            motorEntity.gameModelId = idGameModel;
            motorEntity.typeMotorId = currentMotor.getTyperMotorIdDB();
            listMotorsEntities.Add(motorEntity);
        }
        await databaseManager.insertAll(element: listMotorsEntities);
        return true;
    }
}