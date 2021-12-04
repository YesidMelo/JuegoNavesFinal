using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerUSerInterfaceGetCurrentMainCameraUseCase {
    Camera invoke();
}
public class HandlerUSerInterfaceGetCurrentMainCameraUseCaseImpl : HandlerUSerInterfaceGetCurrentMainCameraUseCase
{
    private HandlerUserInterfaceRepository repository = new HandlerUserInterfaceRepositoryImpl();
    public Camera invoke() => repository.getCurrentMainCamera;
}