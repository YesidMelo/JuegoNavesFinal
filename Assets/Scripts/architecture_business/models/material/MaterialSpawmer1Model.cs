using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawmer1Model {
    public Level level;
    public Dictionary<Material, List<GameObject>> dictionaryGameObjects = new Dictionary<Material,List<GameObject>>();
    public Dictionary<Material, int> counterMaterialsInLevel = new Dictionary<Material, int>();
}