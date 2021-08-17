using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AboutViewModelDelegte {
    void goBack();
}

public interface AboutViewModel { 
    string about { get; }
    string detailAbout { get; }
    AboutViewModelDelegte myDelegate { set; }

    void goBack();
}

public class AboutViewModelImpl : AboutViewModel
{
    private AboutViewModelDelegte _myDelegate;

    public string about {
        get { return "Acerca del juego"; }
    }

    public string detailAbout {
        get { 
            return "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Cras ex augue, posuere imperdiet accumsan eu, consequat rhoncus ipsum. Vivamus fermentum efficitur risus, a vestibulum eros tincidunt et. Etiam suscipit aliquam vehicula. Vestibulum vel tincidunt ligula, quis maximus dui. Vestibulum commodo consectetur ultricies. In congue malesuada urna eget pellentesque. Maecenas scelerisque nisl eget ligula vestibulum dignissim.Nunc elit sapien, tristique at blandit in, laoreet ut odio.Donec vitae dapibus justo, quis scelerisque metus. Phasellus quis nisi egestas dolor aliquam luctus.Sed facilisis placerat quam, viverra fringilla dui semper a. Ut non fermentum nulla. Pellentesque luctus eu lacus vitae aliquet. Sed lobortis eros at ipsum ultricies, nec volutpat nibh gravida.Maecenas sed mattis ligula. Aenean accumsan leo vel ex ornare, eget iaculis mi sodales."
            +"Fusce condimentum tempus pellentesque. Vivamus id pretium nulla, in aliquam enim. Vestibulum viverra nulla sit amet enim blandit, eget fermentum magna tempor. Sed odio augue, fringilla in risus vel, aliquet sagittis magna. Ut et mollis risus, quis laoreet massa. Nunc at tempus velit, id fringilla metus. Nunc sit amet urna at leo convallis pharetra. Proin consectetur maximus scelerisque. Donec a volutpat eros."
            +"Suspendisse euismod ut mi in rhoncus.Morbi risus nunc, luctus sagittis placerat ac, sodales at metus. Etiam non lobortis felis. Donec vulputate blandit sem, eget iaculis justo ultricies eu. Praesent sagittis fringilla massa quis pharetra. Sed quis dui sit amet nibh egestas imperdiet. Curabitur tincidunt pellentesque urna, quis aliquam neque tristique vitae. Etiam at imperdiet purus. Integer lobortis vehicula eros id sollicitudin. Etiam a tellus lacinia, imperdiet nunc quis, facilisis neque.Duis accumsan magna risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Mauris eleifend pharetra mi, a bibendum urna gravida nec. Ut venenatis non eros sit amet eleifend."; 
        }
    }

    public AboutViewModelDelegte myDelegate {
        set => _myDelegate = value; 
    }

    public void goBack() {
        if (_myDelegate == null) { return; }
        _myDelegate.goBack();
    }

}
