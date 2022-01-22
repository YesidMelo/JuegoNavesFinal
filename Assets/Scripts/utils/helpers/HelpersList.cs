using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpersList
{

    public delegate bool FilterCondition<T>(T parameter);

    public static List<T> filter<T>(List<T> currentList, FilterCondition<T> myCondition) {
        List<T> listFiltered = new List<T>();
        foreach (T current in currentList) {
            if (!myCondition(parameter: current)) continue;
            listFiltered.Add(current);
        }
        return listFiltered;
    }

    public static bool isEmpty<T>(List<T> currentList) => currentList.Count == 0;
    public static bool isNullOrEmpty<T>(List<T> currentList) => currentList == null || currentList.Count == 0;
    public static T first<T>(List<T> currentList) => currentList[0];
    
}