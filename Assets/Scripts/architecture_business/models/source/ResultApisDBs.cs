using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResultApisDBs { 
    
}

public class Success<T> : ResultApisDBs{
    public int code;
    public string messagge;
    public T data;
}

public class Failure<T> : ResultApisDBs{
    public int code;
    public string messagge;
}

public static class ResultGameExtentions {
    
    public static void safeResponse<T>(this ResultApisDBs currentResult, Action<T> actionSuccess, System.Action actionError) {
        if (currentResult is Success<T>) {
            actionSuccess(((Success<T>)currentResult).data);
            return;
        }
        actionError();
    }
}