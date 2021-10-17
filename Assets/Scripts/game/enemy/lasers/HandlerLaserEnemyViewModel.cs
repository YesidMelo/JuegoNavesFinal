using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserEnemyViewModelDelegate { }
public interface HandlerLaserEnemyViewModel {
    HandlerLaserEnemyViewModelDelegate myDelegate { get; set; }
    
}
public class HandlerLaserEnemyViewModelImpl : HandlerLaserEnemyViewModel
{
    public HandlerLaserEnemyViewModelDelegate myDelegate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}