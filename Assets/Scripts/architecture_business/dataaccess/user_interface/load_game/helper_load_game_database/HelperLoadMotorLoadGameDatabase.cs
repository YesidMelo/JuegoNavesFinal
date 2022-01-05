using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadMotorLoadGameDatabase
{
    private GameModel gameModel;

    //public methods
    public HelperLoadMotorLoadGameDatabase initValues(GameModel gameModel)
    {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadMotors()
    {
        try
        {
            List<MotorEntity> listMotorEntity = await DatabaseManagerImpl.getInstance().getElements<MotorEntity>(conditions: generateListConditionsLaser());
            MotorModel motorModel = convertMotorEntityToMotorModel(listMotorEntity: listMotorEntity);
            gameModel.motorModel = motorModel;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    //private methods
    private List<Condition> generateListConditionsLaser()
    {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.value = gameModel.id;
        condition.type = TypeElement.INTEGER;

        List<Condition> listCondition = new List<Condition>();
        listCondition.Add(condition);
        return listCondition;
    }

    private MotorModel convertMotorEntityToMotorModel(List<MotorEntity> listMotorEntity) {
        MotorModel motorModel = new MotorModel();
        motorModel.listMotors = new List<MotorPlayer>();
        foreach(MotorEntity motor in listMotorEntity)
        {
            if (motorModel.id == null) motorModel.id = motor.id;
            if (motorModel.gameModelId == null) motorModel.gameModelId = motor.gameModelId;
            motorModel.listMotors.Add(MotorPlayer.TYPE_1.getTypeMotorPlayerById(id: motor.typeMotorId));
        }
        return motorModel;
    }

}
