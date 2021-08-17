using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AboutUIDelegate : AbstractCanvasUIDelegate
{
    void goBack();
}

public class AboutUI : AbstractCanvas, AboutViewModelDelegte
{
    public AboutUIDelegate myDelegate;
    private AboutViewModel viewModel = new AboutViewModelImpl();

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
    }

    public void clickGoToBack() {
        viewModel.goBack();
        
    }

    public void goBack()
    {
        if (myDelegate == null) { return; }
        myDelegate.goBack();
    }
}
