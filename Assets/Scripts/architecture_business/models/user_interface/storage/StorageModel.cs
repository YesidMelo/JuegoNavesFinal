using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageModel {
    public long? id;
    public long? gameModelId;
    public StoragePlayer currentStorage;
    public List<MaterialModel> listMaterials = new List<MaterialModel>();
}