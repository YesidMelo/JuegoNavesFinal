using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerDateTimeType<T> : BaseHandlerTypeDB<T>
{

    public override bool itHasBeen()
    {
        if (setValueNullDateTimeValueDateTime()) return true;
        if (setValueDateTimeValueDateTime()) return true;
        if (setValueNullDateTimeValueString()) return true;
        if (setValueDateTimeValueString()) return true;
        return false;
    }

    //private methods

    private bool setValueNullDateTimeValueDateTime()
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

    private bool setValueDateTimeValueDateTime()
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
    private bool setValueNullDateTimeValueString()
    {
        if (currentField.FieldType != typeof(DateTime?)) return false;
        try
        {
            DateTime? newValue = DateTime.ParseExact(value.ToString(), "yyyy-MM-ddThh:mm:ss", null);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueDateTimeValueString()
    {
        if (currentField.FieldType != typeof(DateTime)) return false;
        try
        {
            DateTime newValue = DateTime.ParseExact(value.ToString(), "yyyy-MM-ddThh:mm:ss", null);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

}