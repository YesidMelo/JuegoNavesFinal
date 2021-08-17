using TMPro;

public interface ConfigurationSpaceCraftUIDelegate : AbstractCanvasUIDelegate {
    void goToLasers();
    void goToShields();
    void goToBack();

}

public class ConfigurationSpaceCraftUI : AbstractCanvas, ConfigurationSpaceCraftUIViewModelDelegate
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI laser;
    public TextMeshProUGUI shield;
    public TextMeshProUGUI back;
    public ConfigurationSpaceCraftUIDelegate myDelegate { set { _myDelegate = value;  } }

    private ConfigurationSpaceCraftUIViewModel viewModel = new ConfigurationSpaceCraftUIViewModelImpl();
    private ConfigurationSpaceCraftUIDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initValues();

    }

    //clicks
    public void clickGoBack() => viewModel.goToBack();
    public void clickGoLaser() => viewModel.goToLasers();
    public void clickGoShields() => viewModel.goToShields();

    // private methods

    bool notExistsDelegate() => _myDelegate == null;

    void initValues() {
        title.text = viewModel.title;
        back.text = viewModel.back;
        laser.text = viewModel.laser;
        shield.text = viewModel.shield;
    }

    //delegates

    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public void goToLasers()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToLasers();
    }

    public void goToShields()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToShields();
    }


}
