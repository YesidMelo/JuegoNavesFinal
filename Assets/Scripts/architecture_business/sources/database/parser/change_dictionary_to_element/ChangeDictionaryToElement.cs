using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ChangeDictionaryToElement<T> {


    public List<T> convertListDictionaryToListElements<T>(List<Dictionary<string, object>> listDictionary)
    {
        List<T> elements = new List<T>();
        foreach (Dictionary<string, object> currentDictionary in listDictionary)
        {
            T newElement = (T)Activator.CreateInstance(typeof(T));
            assignValuesToElement(dictionary: currentDictionary, element: newElement);
            elements.Add(newElement);
        }
        return elements;
    }

    //private methods
    private void assignValuesToElement<T>(Dictionary<string, object> dictionary, T element)
    {
        foreach (KeyValuePair<string, object> entry in dictionary)
        {
            Type elementType = typeof(T);
            FieldInfo currentField = elementType.GetField(entry.Key);
            try
            {
                (new HelperChangeDictionaryToElement<T>(currentField: currentField, value: entry.Value, element: element)).setValue();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

}