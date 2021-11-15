using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScencePoblationGenerator : MonoBehaviour, HandlerScencePoblationGeneratorViewModelDelegate
{
    public GameObject prefabEnemy;
    public Level currentLevel;
    public bool updateLevel = false;

    private HandlerScencePoblationGeneratorViewModel viewModel = new HandlerScencePoblationGeneratorViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        updateCurrentLevelFromUI();
    }

    //public method

    public void updateCurrentLevel(Level level) {
        if (viewModel == null) return;
        viewModel.updateLevel(level);
    }

    //private method
    private void createSecondLieuTenants() {
        
    }    

    private void validateListEnemies(Dictionary<Level, List<GameObject>> currentList) {
        if (currentList.ContainsKey(currentLevel)) return;
        currentList[currentLevel] = new List<GameObject>();
    }

    private void instantiateElement(List<GameObject> listGameobjects, SpacecraftEnemy spacecraftEnemy) {
        if (prefabEnemy == null) return;
        GameObject spacecraft = Instantiate(prefabEnemy);
        spacecraft.transform.position = new Vector3(Functions.generateRandomPosionX(), Functions.generateRandomPosionY(), 0);
        HandlerSpacecraftEnemy handler = spacecraft.GetComponent<HandlerSpacecraftEnemy>();

        if (handler == null) return;
        handler.updateSpacecraft(spacecraftEnemy);
        listGameobjects.Add(spacecraft);
    }

    //ui methods
    private void updateCurrentLevelFromUI()
    {
        if (!updateLevel) return;
        updateLevel = false;
        updateCurrentLevel(currentLevel);
        
    }

    //IEnumerators
    
    //delegates
    public void notifyLoadLevel()
    {
        currentLevel = viewModel.currentLevel;
    }


}
