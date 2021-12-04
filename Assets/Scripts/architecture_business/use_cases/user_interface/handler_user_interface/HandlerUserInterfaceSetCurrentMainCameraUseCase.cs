using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerUserInterfaceSetCurrentMainCameraUseCase {
    bool invoke(Camera camera);
}

public class HandlerUserInterfaceSetCurrentMainCameraUseCaseImpl : HandlerUserInterfaceSetCurrentMainCameraUseCase
{
    private HandlerUserInterfaceRepository repository = new HandlerUserInterfaceRepositoryImpl();
    public bool invoke(Camera camera) => repository.setCurrentMainCamera(camera: camera);
}