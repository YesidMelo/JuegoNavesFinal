using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HandlerScencePoblationGenerator : MonoBehaviour, 
    HandlerScencePoblationGeneratorViewModelDelegate, 
    IHelperHandlerScencePopulationGeneratorDelegate
{

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
    private IHelperHandlerScencePopulationGenerator helperHandlerPopulation = new HelperHandlerScencePopulationGeneratorImpl();

    ///lifeCycle
    private void Awake()
    {
        viewModel.myDelegate = this;
        helperHandlerPopulation.myDelegate = this;
    }

    
    void Update()
    {
        checkCurrentPopulation();
        helperHandlerPopulation.checkPopulationLevel();
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

    public void generateSpacecraft(SpacecraftEnemy spacecraftEnemy, int missing)
    {
        for (int index = 0; index < missing; index++) {
            string currentName = generateRandomName();
            GameObject currentSpacecraft = instantiateElement(spacecraftEnemy: spacecraftEnemy);
            if (currentSpacecraft == null) return;
            currentSpacecraft.name = currentName;
            viewModel.addEnemy(spacecraft: spacecraftEnemy, gameObject: currentSpacecraft);
        }
    }

    private string generateRandomName()
    {

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
