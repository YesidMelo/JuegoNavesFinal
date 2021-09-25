using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
    public Canvas splash;

    public override void InstallBindings()
    {
        //Debug.Log("HE llegado a installBindings de ProjectContextInstaller");

        // ViewModels
        Container.Bind<UserInterfaceHandlerViewModel>().To<UserInterfaceHandlerViewModelImpl>().AsSingle();
        
    }
}