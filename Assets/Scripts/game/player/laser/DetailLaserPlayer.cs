using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailLaserPlayer 
{
    protected float _impactDamage;
    protected string _nameParent;
    protected GameObject _parent;

    public float impactDamage { 
        get => _impactDamage;
        set => _impactDamage = value; 
    }

    public string nameParent
    {
        get => _nameParent;
        set => _nameParent = value;
    }

    public GameObject parent
    {
        get => _parent;
        set => _parent = value;
    }
}
