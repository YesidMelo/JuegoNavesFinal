using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValuesByAttribute <T> {

    private T element;
    private HelperGetValueByAttributePrimaryKey<T> getValuePrimaryKey = new HelperGetValueByAttributePrimaryKey<T>();

    public void initVariables(T element) {
        this.element = element;
        getValuePrimaryKey.setValue(element: element);
    }

    public long getPrimaryKey() => getValuePrimaryKey.getValuePrimaryKey();
}