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

    private HandlerNumberType<T> handlerNumberType = new HandlerNumberType<T>();
    private HandlerBooleanType<T> handlerBooleanType = new HandlerBooleanType<T>();
    private HandlerTextType<T> handlerTextType = new HandlerTextType<T>();
    private HandlerDateTimeType<T> handlerDateTimeType = new HandlerDateTimeType<T>();

    public HelperChangeBetweenObject(
        FieldInfo currentField,
        object value,
        T element
    )
    {
        this.currentField = currentField;
        this.value = value;
        this.element = element;
        initHandlerTypes();
    }

    public void setValue()
    {
        if (handlerNumberType.itHasBeen()) return;
        if (handlerBooleanType.itHasBeen()) return;
        if (handlerTextType.itHasBeen()) return;
        if (handlerDateTimeType.itHasBeen()) return;

        Debug.Log(string.Format("tipo actual: {0}\n", currentField.FieldType));
    }

    //private methods
    private void initHandlerTypes()
    {

        handlerNumberType.startValues(
            currentField: currentField,
            value: value,
            element: element
        );

        handlerBooleanType.startValues(
            currentField: currentField,
            value: value,
            element: element
        );

        handlerTextType.startValues(
            currentField: currentField,
            value: value,
            element: element
        );

        handlerDateTimeType.startValues(
            currentField: currentField,
            value: value,
            element: element
        );

    }


}
