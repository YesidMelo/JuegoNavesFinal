using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStorageDelegate { }

public class HandlerStorage : MonoBehaviour
{
    private HandlerStorageDelegate _myDelegate;
    public HandlerStorageDelegate myDelegate { set { _myDelegate = value; } }
    public Storage currentStorage = Storage.TYPE_1;
    public AbstractStorage storage;

    // Start is called before the first frame update
    void Start()
    {
        initVariables();
    }

    //public methods
    public void updateStorage(Storage storage) {
        currentStorage = storage;
        initVariables();
    }

    // private methods
    void initVariables() => (new StorageFactory()).getStorage(currentStorage);
}
