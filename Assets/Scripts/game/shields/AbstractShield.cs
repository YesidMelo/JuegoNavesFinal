using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShield {

    protected float _percentageOfDefense = 0f;
    protected float _percentageOfDefenseSuccess = 100f;

    // public methods
    public float percentageOfDefense {
        get => _percentageOfDefense;
    }

    public float percentageOfDefenseSuccess {
        get => _percentageOfDefenseSuccess;
    }
}
