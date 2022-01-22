using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopulationModel {

    public Level level;
    public Dictionary<SpacecraftEnemy, List<GameObject>> dictionaryEnemies = new Dictionary<SpacecraftEnemy, List<GameObject>>();
    public Dictionary<SpacecraftEnemy, int> dictionaryCounterEnemies = new Dictionary<SpacecraftEnemy, int>();
}