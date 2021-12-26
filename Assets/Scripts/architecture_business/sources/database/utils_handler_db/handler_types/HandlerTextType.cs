using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerTextType<T> : BaseHandlerTypeDB<T>
{
    public override bool itHasBeen()
    {
        return setValueString();
    }

    //private methods
    private bool setValueString()
    {
        if (currentField.FieldType != typeof(string)) return false;
        try
        {
            string newValue = Convert.ToString(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

}