using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface SencenceSelectDB {

    Task<List<T>> getElements<T>(List<Condition> conditions) where T : BaseDBEntity;

}

public class SencenceSelectDBImpl : SencenceSelectDB {

    //static varables
    private static SencenceSelectDBImpl instance;

    //static Methods
    public static SencenceSelectDBImpl getInstance() {
        if (instance == null) {
            instance = new SencenceSelectDBImpl();
        }
        return instance;
    }
    private SencenceSelectDBImpl() { }

    //public methods

    public async Task<List<T>> getElements<T>(List<Condition> conditions) where T : BaseDBEntity
    {
        if (conditions == null) conditions = new List<Condition>();
        string querySelect = getSentenceSelect<T>(conditions: conditions);
        //Debug.Log(querySelect);
        List<T> elements = new List<T>();
        //return (T)Activator.CreateInstance(typeof(T));
        return elements;
    }

    //private methods 

    private string getSentenceSelect<T>(List<Condition> conditions) where T : BaseDBEntity
    {
        var sentenceSelect = string.Format("SELECT * FROM {0} ", typeof(T).Name);
        var stringConditions = generateConditionsSentenceSelect(conditions: conditions);

        string finalSentence = string.Format(
            "{0} {1}",
            sentenceSelect,
            stringConditions
        );

        return finalSentence;
    }

    private string generateConditionsSentenceSelect(List<Condition> conditions)
    {
        StringBuilder conditionString = new StringBuilder("");

        if (conditions.Count == 0)
        {
            return conditionString.ToString();
        }

        foreach (Condition condition in conditions)
        {
            if (!isValidCondition(condition)) continue;
            if (!conditionString.ToString().Contains("WHERE")) conditionString.Append("WHERE ");

            conditionString.Append($"{condition.columnName} {condition.clausure.getClausureSQL()} {selectStringCondition(condition: condition)} ");

            if (conditions.IndexOf(condition) < conditions.Count - 1) conditionString.Append("AND ");

        }

        return conditionString.ToString();
    }

    private string selectStringCondition(Condition condition)
    {
        string element = "";

        switch (condition.type)
        {
            case TypeElement.TEXT:
                element += $"\"{condition.valueString}\"";
                break;
            case TypeElement.INTEGER:
                element += $"{condition.valueInt}";
                break;
            case TypeElement.FLOAT:
                element += $"{condition.valueFloat}";
                break;
            case TypeElement.BOOL:
                element += $"{(condition.valueBool ? 1 : 0)}";
                break;
        }

        return element;
    }

    private bool isValidCondition(Condition condition)
    {
        if (string.IsNullOrEmpty(condition.columnName)) return false;
        if (condition.clausure == null) return false;
        return condition.type.conditionContainsValue(condition: condition);
    }

}