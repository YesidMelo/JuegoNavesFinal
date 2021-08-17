using TMPro;
using UnityEngine;

public interface LaserOptionsUIDelegate : AbstractCanvasUIDelegate {
    void goBack();
}

public class LaserOptionsUI : AbstractCanvas, LaserOptionsUIViewModelDelegate
{

    public LaserOptionsUIDelegate myDelegate { set { _myDelegate = value; } }

    public TextMeshProUGUI title;
    public TextMeshProUGUI labelCurrentLaser;
    public TextMeshProUGUI back;
    public TextMeshProUGUI descriptionCurrentLAser;
    public TextMeshProUGUI save;


    private LaserOptionsUIDelegate _myDelegate;
    private LaserOptionsUIViewModel viewModel = new LaserOptionsUIViewModelImpl();

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initValues();
    }

    //clicks
    public void clickBack() { 
        viewModel.goBack();
    }

    public void clickSave() {
        viewModel.saveConfiguration();
    }

    //private methods
    private void initValues() {
        title.text = viewModel.title;
        back.text = viewModel.back;
        labelCurrentLaser.text = viewModel.labelCurrentLaser;
        descriptionCurrentLAser.text = viewModel.descriptionCurrentLaser;
        save.text = viewModel.save;
    }

    //delegate
    public void goBack()
    {
        if (_myDelegate == null) { return; }
        _myDelegate.goBack();
    }
}
