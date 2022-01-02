using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    public string columnName;
    public Clause clausure;
    public TypeElement type;
    public object value;
}

public class Versions<T> {

    //this parameter contains oldVersion
    public List<Condition> oldVersion;
    public List<Condition> newVersion;
    public T table;
}
