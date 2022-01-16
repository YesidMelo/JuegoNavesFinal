using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUI : MonoBehaviour, BackgroundUIViewModelDelegate
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> listSprites;
    public Level currentLevelUI;

    private BackgroundUIViewModel viewModel = new BackgroundUIViewModelImpl();

    //lifecycle
    void Start()
    {
        viewModel.myDelegate = this;
    }

    
    void Update()
    {
        viewModel.checkCurrentLevel();
        checkIfCurrentSpriteRendererIsNull();
    }

    //public methods

    //private methods
    private void checkIfCurrentSpriteRendererIsNull() {
        if (spriteRenderer.sprite != null) return;
        spriteRenderer.sprite = viewModel.getCurrentLevel().getCurrentBackground(listSprites: listSprites);
    }

    //ui methods

    //delegates
    public void updateBackground(Level level)
    {
        currentLevelUI = level;
        Sprite sprite = level.getCurrentBackground(listSprites: listSprites);

        if (sprite == null) return;
        spriteRenderer.sprite = sprite;
    }

}
