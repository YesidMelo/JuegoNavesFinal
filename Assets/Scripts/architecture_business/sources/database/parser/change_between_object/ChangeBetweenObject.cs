using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ChangeBetweenObject<T,K> {

    public List<K> transformList(List<T> listInput) {
        List<K> listTransformed = new List<K>();
        foreach (T currentElement in listInput) {
            listTransformed.Add(
                transform(input: currentElement)
            );
        }
        return listTransformed;
    }

    public K transform(T input) {
        K newElement = (K)Activator.CreateInstance(typeof(K));
        assignValues(input: input, newElement: newElement);
        return newElement;
    }

    //private methods
    private void assignValues(T input, K newElement) {

        Type typeInput = typeof(T);
        FieldInfo[] fieldsInput = typeInput.GetFields();
        Type typeNewField = typeof(K);
        foreach (FieldInfo currentFieldInfo in fieldsInput) {
            FieldInfo fieldNewElement = typeNewField.GetField(currentFieldInfo.Name);
            if (fieldNewElement == null) continue;

            try
            {
                (new HelperChangeBetweenObject<K>(
                    currentField: fieldNewElement,
                    value: currentFieldInfo.GetValue(input),
                    element: newElement
                    )
                ).setValue();
            }
            catch (Exception e) {
                Debug.Log(e.Message);
            }
        }
    }
}