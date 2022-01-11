using System;
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
        try
        {
            List<MotorEntity> listMotorsEntities = new List<MotorEntity>();
            foreach (MotorPlayer currentMotor in motorModel.listMotors)
            {
                MotorEntity motorEntity = new MotorEntity();
                motorEntity.gameModelId = idGameModel;
                motorEntity.typeMotorId = currentMotor.getTyperMotorIdDB();
                listMotorsEntities.Add(motorEntity);
            }
            MotorEntity motorToDelete = new MotorEntity();
            motorToDelete.gameModelId = idGameModel;
            await databaseManager.deleteElementsWithCondition<MotorEntity>(conditions: generateListConditionsToDelete());
            await databaseManager.insertAll(element: listMotorsEntities);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return true;
        }
    }

    private List<Condition> generateListConditionsToDelete() {
        List<Condition> listConditions = new List<Condition>();
        
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.type = TypeElement.INTEGER;
        condition.value = idGameModel;

        listConditions.Add(condition);

        return listConditions;
    }
}