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
    public Material currentMaterial;


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
    }

    private void Update()
    {
        currentMaterial = _viewModel.currentMaterial;
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

    public void updateMaterial(Material material) {
        _viewModel.addMaterialToSpawmer(material: material);
        spriteRenderer.sprite = _viewModel.currentMaterial.getSpriteByMaterial(listSpriteMaterials: listSprites);
    }

    //private methods

}
