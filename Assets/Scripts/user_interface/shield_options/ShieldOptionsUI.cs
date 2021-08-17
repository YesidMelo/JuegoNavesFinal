using TMPro;

public interface ShieldOptionsUIDelegate : AbstractCanvasUIDelegate{
    void goBack();
}

public class ShieldOptionsUI : AbstractCanvas, ShiledOptionsUIViemodelDelegate
{

    public ShieldOptionsUIDelegate myDelegate { set { _myDelegate = value; } }
    public TextMeshProUGUI title;
    public TextMeshProUGUI labelCurrentShield;
    public TextMeshProUGUI currentShield;
    public TextMeshProUGUI back;
    public TextMeshProUGUI save;

    private ShiledOptionsUIViemodel viewModel = new ShiledOptionsUIViemodelImpl();
    private ShieldOptionsUIDelegate _myDelegate;

    private void Start()
    {
        viewModel.myDelegate = this;
        initValues();
    }

    //clicks

    public void onClickBack() => viewModel.goBack();

    public void onClickSave() {
        viewModel.saveConfiguration();
    }

    //private methods

    void initValues() { 
        title.text = viewModel.title;
        labelCurrentShield.text = viewModel.labelCurrentShield;
        currentShield.text = viewModel.currentShield;
        back.text = viewModel.back;
        save.text = viewModel.save;
    }

    //delegate
    public void goBack()
    {
        if (_myDelegate == null) { return; }
        _myDelegate.goBack();
    }
}
