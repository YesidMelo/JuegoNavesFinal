using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HelperGetValueByAttributePrimaryKey<T> : BaseHelpersGetValuesByAttribute<T> {

    public long getValuePrimaryKey() {
        FieldInfo currentField = getFieldInfoPrimaryKey();
        if (currentField == null) return 0;
        if (currentField.FieldType == typeof(long?)) {
            return (long) currentField.GetValue(element);
        }
        if (currentField.FieldType == typeof(long))
        {
            return (long)currentField.GetValue(element);
        }
        return 0;
    }

    //private methods

    private FieldInfo getFieldInfoPrimaryKey() {
        Type type = typeof(T);
        FieldInfo[] fieldsFromType = type.GetFields();
        FieldInfo fieldInfoPrimaryKey = null;

        foreach (FieldInfo currentFieldInfo in fieldsFromType) {
            var listPrimaryKeys = (PrimaryKey[]) currentFieldInfo.GetCustomAttributes(typeof(PrimaryKey), true);
            if (listPrimaryKeys.Length == 0) continue;
            fieldInfoPrimaryKey = currentFieldInfo;
            break;
        }

        return fieldInfoPrimaryKey;
    }
}