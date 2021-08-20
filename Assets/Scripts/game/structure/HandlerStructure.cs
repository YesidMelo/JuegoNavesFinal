using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStructureDelegate { }

public class HandlerStructure : MonoBehaviour
{
    private HandlerStructureDelegate _myDelegate;
    public HandlerStructureDelegate myDelegate { set { _myDelegate = value; } }
    public Structure currentStructure = Structure.TYPE_1;
    public AbstractStructure structure;

    // Start is called before the first frame update
    void Start()
    {
        initVariables();    
    }

    public void updateStructure(Structure structure) {
        currentStructure = structure;
        initVariables();
    }

    //private method
    void initVariables() => structure = (new StructureFactory()).getStructure(currentStructure);

}
