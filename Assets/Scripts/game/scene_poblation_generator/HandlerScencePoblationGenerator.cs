using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScencePoblationGenerator : MonoBehaviour, HandlerScencePoblationGeneratorViewModelDelegate
{

    public GameObject prefabEnemy;
    /*
    public Level levelToChange;
    public Level currentLevel;
    public bool updateLevel = false;
    public bool startCoroutineCheckPopulation = false;
    

    public bool isRunCoroutineCheckPopulation = false;
    private HandlerScencePoblationGeneratorViewModel viewModel = new HandlerScencePoblationGeneratorViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        checkCurrentLevel();
        updateCurrentLevelFromUI();
        runCoroutinePopulation();
    }


    //public method

    public void updateCurrentLevel(Level level) {
        if (viewModel == null) return;
        viewModel.updateLevel(level);
    }

    //private method

    private void checkCurrentLevel() {
        if (currentLevel == viewModel.currentLevel) return;
        isRunCoroutineCheckPopulation = false;
        startCoroutineCheckPopulation = true;
        viewModel.checkCurrentLevel();
    }
    private void runCoroutinePopulation() {
        try {
            if (!startCoroutineCheckPopulation) return;
            if (isRunCoroutineCheckPopulation) return;
            startCoroutineCheckPopulation = false;
            isRunCoroutineCheckPopulation = true;
            StartCoroutine(checkPopulation());
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
        
    }

    private GameObject instantiateElement(SpacecraftEnemy spacecraftEnemy) {
        if (viewModel.isGameInPause()) return null;
        if (prefabEnemy == null) return null;
        GameObject spacecraft = Instantiate(prefabEnemy);
        spacecraft.transform.position = new Vector3(Functions.generateRandomPosionX(), Functions.generateRandomPosionY(), 0);
        HandlerSpacecraftEnemy handler = spacecraft.GetComponent<HandlerSpacecraftEnemy>();

        if (handler == null) {
            Destroy(spacecraft);
            return null; 
        }
        handler.updateSpacecraft(spacecraftEnemy);
        return spacecraft;
    }

    //ui methods
    private void updateCurrentLevelFromUI()
    {
        if (!updateLevel) return;
        updateLevel = false;
        updateCurrentLevel(levelToChange);

    }

    //IEnumerators

    private IEnumerator checkPopulation() {
        while (isRunCoroutineCheckPopulation) {
            if (viewModel.isAllPoblation(levelToChange)) {
                yield return new WaitForSeconds(1f);
            }
            if (viewModel.isGameInPause())
            {
                yield return new WaitForSeconds(1f);
            }
            Dictionary<SpacecraftEnemy, int> populationMissing = viewModel.getEnemiesMissingInThePopulation(levelToChange);
            foreach (KeyValuePair<SpacecraftEnemy, int> entry in populationMissing) {
                for (int counter = 0; counter< entry.Value; counter++) {
                    GameObject spacecraft = instantiateElement(entry.Key);
                    if (spacecraft == null) continue;
                    spacecraft.name = string.Format("{0}{1}",spacecraft.name,counter);
                    if (spacecraft == null) continue;
                    viewModel.addEnemy(level: levelToChange, spacecraft: entry.Key, gameObject: spacecraft);
                    yield return new WaitForSeconds(0.003f);
                }
            }
            yield return new WaitForSeconds(1f);
        }
        isRunCoroutineCheckPopulation = false;
        yield return null;
    }

    */

    //delegates
    public void notifyLoadLevel()
    {
        /*
        levelToChange = viewModel.currentLevel;
        startCoroutineCheckPopulation = true;
        */
    }


}
