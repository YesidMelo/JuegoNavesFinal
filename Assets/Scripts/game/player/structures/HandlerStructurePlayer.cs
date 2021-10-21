using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStructurePlayer : MonoBehaviour, HandlerStructurePlayerViewModelDelegate
{

    public StructurePlayer currentStructure = StructurePlayer.TYPE_1;
    public SpriteRenderer spriteRenderer;
    public Sprite spacecraftPlayer1;
    public Sprite spacecraftPlayer2;
    public Sprite spacecraftPlayer3;
    public Sprite spacecraftPlayer4;
    public Sprite spacecraftPlayer5;
    public bool loadStructureUI = false;
    public bool updateStructureUI = false;
    public GameObject parent;

    private HandlerStructurePlayerViewModel viewModel = new HandlerStructurePlayerViewModelImpl();
    private bool _updateStructure = false;

    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadStructure();
    }

    void Update()
    {
        updateStructure();
        loadStructureFromUIUnity();
        updateStructureFromUIUnity();
    }

    //public methods

    public void updateStructure(StructurePlayer structure) {
        if (viewModel == null) return;
        viewModel.updateStructure(structure);
    }

    //private methods
    private void updateStructure() {
        if (!_updateStructure) return;
        _updateStructure = false;
        currentStructure = viewModel.currentStructure;
        updateSpriteInSpriteRenderer();
    }

    private void updateSpriteInSpriteRenderer() {
        Sprite finalSprite;
        switch (currentStructure) {
            case StructurePlayer.TYPE_2:
                finalSprite = spacecraftPlayer2;
                break;
            case StructurePlayer.TYPE_3:
                finalSprite = spacecraftPlayer3;
                break;
            case StructurePlayer.TYPE_4:
                finalSprite = spacecraftPlayer4;
                break;
            case StructurePlayer.TYPE_5:
                finalSprite = spacecraftPlayer5;
                break;
            case StructurePlayer.TYPE_1:
            default:
                finalSprite = spacecraftPlayer1;
                break;
        }
        spriteRenderer.sprite = finalSprite;
    }

    //update from ui
    private void loadStructureFromUIUnity()
    {
        if (!loadStructureUI) return;
        loadStructureUI = false;
        if (viewModel == null) return;
        viewModel.loadStructure();
    }

    private void updateStructureFromUIUnity() {
        if (!updateStructureUI) return;
        updateStructureUI = false;
        updateStructure(currentStructure);
    }

    //delegates
    public void notifyLoadStructure()
    {
        _updateStructure = true;
    }

}
