using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsDelegate { 
}

public class MaterialsUI : MonoBehaviour, MaterialsUIViewModelDelegate
{
    //ui variables
    public List<Sprite> listSprites = new List<Sprite>();
    public SpriteRenderer spriteRenderer;


    //variables
    public MaterialsDelegate myDelegate;
    private MaterialsUIViewModel _viewModel = new MaterialUIViewModelImpl();

    //Lyfecycle
    private void Awake()
    {
        _viewModel.myDelegate = this;
    }

    void Start()
    {
        spriteRenderer.sprite = _viewModel.currentMaterial.getSpriteByMaterial(listSpriteMaterials: listSprites);
        _viewModel.addMaterialToSpawmer(currentMaterial: gameObject);
    }

    private void OnDestroy()
    {
        _viewModel.destroyMaterial(currentMaterial: gameObject);
    }

    //public methods
    public Material getCurrentMaterial
    {
        get => _viewModel.currentMaterial;
    }

    //private methods

}
