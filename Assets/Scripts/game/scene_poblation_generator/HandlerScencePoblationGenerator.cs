using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScencePoblationGenerator : MonoBehaviour, HandlerScencePoblationGeneratorViewModelDelegate
{
    public GameObject prefabEnemy;
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
        updateCurrentLevelFromUI();
        runCoroutinePopulation();
    }

    //public method

    public void updateCurrentLevel(Level level) {
        if (viewModel == null) return;
        viewModel.updateLevel(level);
    }

    //private method

    private void runCoroutinePopulation() {
        if (!startCoroutineCheckPopulation) return;
        if (isRunCoroutineCheckPopulation) return;
        startCoroutineCheckPopulation = false;
        isRunCoroutineCheckPopulation = true;
        StartCoroutine(checkPopulation());
    }

    private GameObject instantiateElement(SpacecraftEnemy spacecraftEnemy) {
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
        updateCurrentLevel(currentLevel);

    }

    //IEnumerators

    private IEnumerator checkPopulation() {
        while (isRunCoroutineCheckPopulation) {
            if (viewModel.isAllPoblation(currentLevel)) {
                Debug.Log(string.Format("{0}: {1}", "poblacion", "bien"));
                yield return new WaitForSeconds(1f);
            }
            Dictionary<SpacecraftEnemy, int> populationMissing = viewModel.getEnemiesMissingInThePopulation(currentLevel);
            foreach (KeyValuePair<SpacecraftEnemy, int> entry in populationMissing) {
                Debug.Log(string.Format("{0}: {1}", entry.Key, entry.Value));
                for (int counter = 0; counter< entry.Value; counter++) {
                    GameObject spacecraft = instantiateElement(entry.Key);
                    if (spacecraft == null) continue;
                    viewModel.addEnemy(level: currentLevel, spacecraft: entry.Key, gameObject: spacecraft);
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitForSeconds(1f);
        }
        isRunCoroutineCheckPopulation = false;
        yield return null;
    }

    
    //delegates
    public void notifyLoadLevel()
    {
        currentLevel = viewModel.currentLevel;
        startCoroutineCheckPopulation = true;
    }


}
