using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerUserInterfaceCache {

    bool setCurrentMainCamera(Camera camera);

    Camera getCurrentMainCamera { get; }
}

public class HandlerUserInterfaceCacheImpl : HandlerUserInterfaceCache
{
    //static variables
    private static HandlerUserInterfaceCacheImpl instance;

    //static methods

    public static HandlerUserInterfaceCacheImpl getInstance() {
        if (instance == null) {
            instance = new HandlerUserInterfaceCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private Camera _currentMainCamera;
    
    public Camera getCurrentMainCamera => _currentMainCamera;

    public bool setCurrentMainCamera(Camera camera) {
        _currentMainCamera = camera;
        return true;
    }
}