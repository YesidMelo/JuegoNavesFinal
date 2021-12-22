using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HelperChangeBetweenObject <T>
{


    private FieldInfo currentField;
    private object value;
    private T element;

    public HelperChangeBetweenObject(
        FieldInfo currentField,
        object value,
        T element
    )
    {
        this.currentField = currentField;
        this.value = value;
        this.element = element;
    }

    public void setValue()
    {
        if (setValueLong()) return;
        if (setValueNullLong()) return;
        if (setValueShort()) return;
        if (setValueNullShort()) return;
        if (setValueString()) return;
        if (setValueNullDateTime()) return;
        if (setValueDateTime()) return;
        if (setValueNullBoolean()) return;
        if (setValueBoolean()) return;

        Debug.Log(string.Format("tipo actual: {0}\n", currentField.FieldType));
    }

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
            Debug.Log(e.Message);
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
            Debug.Log(e.Message);
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
            Debug.Log(e.Message);
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
            Debug.Log(e.Message);
            return false;
        }
    }

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
            Debug.Log(e.Message);
            return false;
        }
    }

    private bool setValueNullDateTime()
    {
        if (currentField.FieldType != typeof(DateTime?)) return false;
        try
        {
            currentField.SetValue(element, value);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    private bool setValueDateTime()
    {
        if (currentField.FieldType != typeof(DateTime)) return false;
        try
        {
            currentField.SetValue(element, value);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

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
            Debug.Log(e.Message);
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
            Debug.Log(e.Message);
            return false;
        }
    }
}
