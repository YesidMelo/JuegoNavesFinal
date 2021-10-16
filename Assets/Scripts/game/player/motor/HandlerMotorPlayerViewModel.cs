using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerMotorPlayerViewModelDelegate {
    void notifyLoadListMotors();
    void notifyMovementAttack();
    void notifyMovementDefence();
}
public interface HandlerMotorPlayerViewModel {
    int speedMotor { get; }
    List<MotorPlayer> listMotors{ get; }
    bool loadMotors();
    HandlerMotorPlayerViewModelDelegate myDelegate { get; set; }
    void setMotors(List<MotorPlayer> listMotors);
    void move();
}
public class HandlerMotorPlayerViewModelImpl : HandlerMotorPlayerViewModel
{
    private SpacecraftPlayerGetListMotorUseCase getListMotorUseCase = new SpacecraftPlayerGetListMotorUseCaseImpl();
    private SpacecraftPlayerGetSpeedMotorUseCase getSpeedMotorUseCase = new SpacecraftPlayerGetSpeedMotorUseCaseImpl();
    private SpacecraftPlayerLoadMotorUseCase loadMotorUseCase = new SpacecraftPlayerLoadMotorUseCaseImpl();
    private SpacecraftPlayerUpdateListMotorsUseCase updateListMotorsUseCase = new SpacecraftPlayerUpdateListMotorsUseCaseImpl();
    private HandlerMotorPlayerViewModelDelegate _myDelegate;
    private CurrentActionSpacecraftUseCase currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();
    public int speedMotor => getSpeedMotorUseCase.invoke();

    public List<MotorPlayer> listMotors => getListMotorUseCase.invoke();

    public HandlerMotorPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void move()
    {
        Debug.Log("Move");
        if (_myDelegate == null) return;
        if (currentActionSpacecraftUseCase.invoke() == Action.ATTACK) {
            Debug.Log("Attack");
            _myDelegate.notifyMovementAttack();
            return;
        }
        Debug.Log("Defence");
        _myDelegate.notifyMovementDefence();
    }

    public bool loadMotors()
    {
        if (!loadMotorUseCase.invoke()) return false;
        if (_myDelegate == null) return true;
        _myDelegate.notifyLoadListMotors();
        return true;
    }

    public void setMotors(List<MotorPlayer> listMotors)
    {
        if (listMotors == null || listMotors.Count == 0) return;
        updateListMotorsUseCase.invoke(listMotors);
        loadMotors();
    }
}
