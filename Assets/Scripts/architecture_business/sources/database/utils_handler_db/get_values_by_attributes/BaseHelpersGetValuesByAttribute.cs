using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHelpersGetValuesByAttribute <T> {

    protected T element;

    public void setValue(T element) => this.element = element;

}