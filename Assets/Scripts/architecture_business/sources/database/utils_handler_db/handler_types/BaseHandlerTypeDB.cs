using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class BaseHandlerTypeDB<T> {

    protected FieldInfo currentField;
    protected object value;
    protected T element;

    public void startValues(
        FieldInfo currentField,
        object value,
        T element
    )
    {
        this.currentField = currentField;
        this.value = value;
        this.element = element;
    }

    public abstract bool itHasBeen();
}