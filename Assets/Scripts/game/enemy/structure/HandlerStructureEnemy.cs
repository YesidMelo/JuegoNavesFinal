using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStructureEnemy : MonoBehaviour, HandlerStructureEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public StructureEnemy currentStructure;
    public SpriteRenderer spriteRenderer;
    public Sprite Nivel1_Spacecraf1;
    public Sprite Nivel1_Spacecraf2;
    public Sprite Nivel1_Spacecraf3;
    public Sprite Nivel1_Spacecraf4;
    public Sprite Nivel1_Spacecraf5;
    

    private HandlerStructureEnemyViewModel viewModel = new HandlerStructureEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public method
    public void loadSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private methods
    private void changeStructure() {
        Sprite finalSprite;
        switch (currentStructure) {
            case StructureEnemy.TYPE_2:
                finalSprite = Nivel1_Spacecraf2;
                break;
            case StructureEnemy.TYPE_3:
                finalSprite = Nivel1_Spacecraf3;
                break;
            case StructureEnemy.TYPE_4:
                finalSprite = Nivel1_Spacecraf4;
                break;
            case StructureEnemy.TYPE_5:
                finalSprite = Nivel1_Spacecraf5;
                break;
            case StructureEnemy.TYPE_1:
            default:
                finalSprite = Nivel1_Spacecraf1;
                break;
        }
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
