using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStructureEnemy : MonoBehaviour, HandlerStructureEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public StructureEnemy currentStructure;
    public Level currentLevel;
    public SpriteRenderer spriteRenderer;
    public Sprite currentSpriteFromLevel;
    public List<Sprite> listSprites = new List<Sprite>();
    

    private HandlerStructureEnemyViewModel viewModel = new HandlerStructureEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        checkCurrentLevel();
    }

    //public method
    public void loadSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private methods
    private void checkCurrentLevel() {
        
        if (currentLevel == viewModel.currentLevel) return;
        currentLevel = viewModel.currentLevel;
        changeStructure();
    }

    private void changeStructure() {
        Sprite finalSprite = currentStructure.getCurrentSprite(
            spacecraftEnemy: currentSpacecraft,
            level: viewModel.currentLevel,
            listSprite: listSprites
        );
        
        if (finalSprite == null) return;
        currentSpriteFromLevel = finalSprite;
        spriteRenderer.sprite = finalSprite;
    }
    //ui methods
    //delegates

    public void notifyLoadScructure()
    {
        currentStructure = viewModel.currentStructure;
        changeStructure();
    }

    public void notifyLoadSpacecraft()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }
}
