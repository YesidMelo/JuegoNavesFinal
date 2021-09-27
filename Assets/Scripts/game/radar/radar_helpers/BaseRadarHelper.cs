using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRadarHelper 
{
    protected GameObject _currentObjective;
    protected List<GameObject> _objetives = new List<GameObject>();

    public List<GameObject> listObjetives { get => _objetives; }
    public GameObject currentObjetive { get => _currentObjective; }
    public abstract void addObjetive(Collider2D collision);

    public abstract void changeObjetive();

    public abstract void removeEnemy(Collider2D collision);
}
