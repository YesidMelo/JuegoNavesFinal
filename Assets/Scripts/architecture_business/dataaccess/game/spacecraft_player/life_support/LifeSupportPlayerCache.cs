using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LifeSupportPlayerCache {
    LifeSupportPlayer getCurrentLifeSupport();
    LifeSupportModel currentLifeSupportModel { get; }
    void setCurrentLifeSupportModel(LifeSupportModel lifeSupportModel);
}

public class LifeSupportPlayerCacheImpl : LifeSupportPlayerCache
{

    //static variables
    private static LifeSupportPlayerCache instance;

    //static methods
    public static LifeSupportPlayerCache getInstance() {
        if (instance == null) {
            instance = new LifeSupportPlayerCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private LifeSupportModel _currentLifeSupportModel = new LifeSupportModel();
    private LifeSupportPlayer _currentLifeSupport;

    public LifeSupportModel currentLifeSupportModel {
        get {
            _currentLifeSupportModel.currentLifeSupport = _currentLifeSupport;
            return _currentLifeSupportModel;
        }
    }

    public LifeSupportPlayer getCurrentLifeSupport() => _currentLifeSupport;

    public void setCurrentLifeSupportModel(LifeSupportModel lifeSupportModel)
    {
        if (lifeSupportModel == null) return;
        _currentLifeSupportModel = lifeSupportModel;
    }
}