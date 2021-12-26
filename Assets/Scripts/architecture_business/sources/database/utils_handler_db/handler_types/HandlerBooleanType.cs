using System;
using UnityEngine;

public class HandlerBooleanType<T> : BaseHandlerTypeDB<T>
{
    //public methods
    public override bool itHasBeen()
    {
        if (setValueBoolean()) return true;
        if (setValueNullBoolean()) return true;
        return false;
    }

    //private methods
    private bool setValueNullBoolean()
    {
        if (currentField.FieldType != typeof(bool?)) return false;
        try
        {
            byte valueBlob = Convert.ToByte(value: value);
            bool? newValue = valueBlob == 1;
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueBoolean()
    {
        if (currentField.FieldType != typeof(bool)) return false;
        try
        {
            byte valueBlob = Convert.ToByte(value: value);
            bool newValue = valueBlob == 1;
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}