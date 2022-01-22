using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class HandlerScencePoblationGenerator1 : MonoBehaviour, HandlerScencePoblationGeneratorViewModelDelegate
{
    //Disparador en hilo principal
    //documentacion en : https://stackoverflow.com/questions/41330771/use-unity-api-from-another-thread-or-call-a-function-in-the-main-thread
    //documentacion en : https://docs.microsoft.com/en-us/dotnet/api/system.threading.synchronizationcontext?view=net-5.0
    private SynchronizationContext syncContext = SynchronizationContext.Current;

    public GameObject prefabEnemy;

    public int SECOND_LIEUTENANTS = 0;
    public int LIEUTENENTS = 0;
    public int MAJOR = 0;
    public int LIEUTENANTCOLONEL = 0;
    public int COLONEL = 0;
    public int BRIGADUERGENERAL = 0;
    public int MAJOR_GENERAL = 0;
    public int GENERAL;

    private HandlerScencePoblationGeneratorViewModel viewModel = new HandlerScencePoblationGeneratorViewModelImpl();
    private HelperHandlerScencePopulationGenerator helperHandlerPopulation = new HelperHandlerScencePopulationGeneratorImpl();

    ///lifeCycle
    private void Awake()
    {
        viewModel.myDelegate = this;
        helperHandlerPopulation.startCheckPopulation(create: createInstancePrefab);
    }

    
    void Update()
    {
        checkCurrentPopulation();
    }

    private void OnDestroy()
    {
        helperHandlerPopulation.stopCheckCurrentStatusGame();
    }

    //public methods

    //private methods
    private void checkCurrentPopulation() {
        SECOND_LIEUTENANTS = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.SECOND_LIEUTENANTS);
        LIEUTENENTS = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.LIEUTENENTS);
        MAJOR = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.MAJOR);
        LIEUTENANTCOLONEL = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.LIEUTENANTCOLONEL);
        COLONEL = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.COLONEL);
        BRIGADUERGENERAL = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.BRIGADUERGENERAL);
        MAJOR_GENERAL = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.MAJOR_GENERAL);
        GENERAL = viewModel.getEnemiesMissingInThePopulation(SpacecraftEnemy.GENERAL);
    }

    private async Task createInstancePrefab(SpacecraftEnemy spacecraftEnemy, int missing) {
        for (int counter = 0; counter < missing; counter++) {
            syncContext.Post(
                (_) =>
                {
                    string currentName = generateRandomName();
                    GameObject currentSpacecraft = instantiateElement(spacecraftEnemy: spacecraftEnemy);
                    if (currentSpacecraft == null) return;
                    currentSpacecraft.name = currentName;
                    viewModel.addEnemy(spacecraft: spacecraftEnemy, gameObject: currentSpacecraft);
                },
                null
            );
            await Task.Delay(Constants.timeAwaitCreateNewPrefab);
        }
    }


    private string generateRandomName() {
        
        StringBuilder builder = new StringBuilder();
        builder.Append($"{Constants.nameSpacecraft}_");
        builder.Append($"{Constants.nameEnemy}_");

        return builder.ToString().addRandomString(Constants.lengthRandomNameEnemies);
    }

    private GameObject instantiateElement(SpacecraftEnemy spacecraftEnemy)
    {
        if (prefabEnemy == null) return null;

        GameObject spacecraft = Instantiate(prefabEnemy);
        spacecraft.transform.position = new Vector3(Functions.generateRandomPosionX(), Functions.generateRandomPosionY(), 0);
        HandlerSpacecraftEnemy handler = spacecraft.GetComponent<HandlerSpacecraftEnemy>();

        if (handler == null)
        {
            Destroy(spacecraft);
            return null;
        }
        handler.updateSpacecraft(spacecraftEnemy);
        return spacecraft;
    }
}
