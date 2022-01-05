using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HandlerNumberType<T> : BaseHandlerTypeDB<T> {

    //public methods

    public override bool itHasBeen()
    {
        if (setValueLong()) return true;
        if (setValueNullLong()) return true;
        if (setValueShort()) return true;
        if (setValueNullShort()) return true;
        if (setValueInt()) return true;
        if (setValueNullInt()) return true;
        if (setValueFloat()) return true;
        if (setValueNullFloat()) return true;
        return false;
    }

    //private methods

    private bool setValueLong()
    {
        if (currentField.FieldType != typeof(long)) return false;
        try
        {
            long newValue = Convert.ToInt64(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueNullLong()
    {
        if (currentField.FieldType != typeof(long?)) return false;
        try
        {
            long? newValue = Convert.ToInt64(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueShort()
    {
        if (currentField.FieldType != typeof(short)) return false;
        try
        {
            short newValue = Convert.ToInt16(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueNullShort()
    {
        if (currentField.FieldType != typeof(short?)) return false;
        try
        {
            short? newValue = Convert.ToInt16(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueInt()
    {
        if (currentField.FieldType != typeof(int)) return false;
        try
        {
            int newValue = Convert.ToInt32(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    private bool setValueNullInt()
    {
        if (currentField.FieldType != typeof(int?)) return false;
        try
        {
            int? newValue = Convert.ToInt16(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueNullFloat()
    {
        if (currentField.FieldType != typeof(float?)) return false;
        try
        {
            float? newValue = Convert.ToSingle(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool setValueFloat()
    {
        if (currentField.FieldType != typeof(float)) return false;
        try
        {
            float newValue = Convert.ToSingle(value: value);
            currentField.SetValue(element, newValue);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    
}