using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerDateTimeType<T> : BaseHandlerTypeDB<T>
{

    public override bool itHasBeen()
    {
        if (setValueNullDateTime()) return true;
        if (setValueDateTime()) return true;
        return false;
    }

    //private methods

    private bool setValueNullDateTime()
    {
        if (currentField.FieldType != typeof(DateTime?)) return false;
        try
        {
            string valueString = ((DateTime)value).ToString("yyyy-MM-ddThh:mm:ss");
            DateTime? newValue = DateTime.ParseExact(valueString, "yyyy-MM-ddThh:mm:ss", null);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueDateTime()
    {
        if (currentField.FieldType != typeof(DateTime)) return false;
        try
        {
            string valueString = ((DateTime)value).ToString("yyyy-MM-ddThh:mm:ss");
            DateTime newValue = DateTime.ParseExact(valueString, "yyyy-MM-ddThh:mm:ss", null);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}