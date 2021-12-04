using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerUserInterfaceRepository {
    bool setCurrentMainCamera(Camera camera);

    Camera getCurrentMainCamera { get; }
}
public class HandlerUserInterfaceRepositoryImpl : HandlerUserInterfaceRepository
{

    private HandlerUserInterfaceCache cache = HandlerUserInterfaceCacheImpl.getInstance();

    public Camera getCurrentMainCamera => cache.getCurrentMainCamera;

    public bool setCurrentMainCamera(Camera camera) => cache.setCurrentMainCamera(camera: camera);
}