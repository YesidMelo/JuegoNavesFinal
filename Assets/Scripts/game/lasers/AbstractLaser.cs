using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLaser 
{
    protected float _impactDamage;
    protected string _nameParent;
    protected GameObject _parent;

    public abstract float impactDamage { get; set; }

    public string nameParent {
        get => _nameParent;
        set => _nameParent = value;
    }

    public GameObject parent
    {
        get => _parent;
        set => _parent = value;
    }
}
