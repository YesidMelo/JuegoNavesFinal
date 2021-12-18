using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Clause
{
    EQUALS,
    IS,
    GREATER_THAN,
    LESS_THAN,
    GREATER_THAN_OR_EQUAL_TO,
    LESS_THAN_OR_EQUAL_TO,
    IN,
    IS_NULL
}

public enum TypeElement
{
    INTEGER,
    TEXT,
    BOOL,
    FLOAT
}

public enum TypeElementDB { 
    INTEGER,
    TEXT,
    BLOB,
    REAL,
}


#region extentions
public static class ExtentionsClausuare
{
    public static string getClausureSQL(this Clause clausure)
    {
        string clausureSQL;
        switch (clausure)
        {
            case Clause.EQUALS:
                clausureSQL = "=";
                break;
            case Clause.IS:
                clausureSQL = "IS";
                break;
            case Clause.GREATER_THAN:
                clausureSQL = ">";
                break;
            case Clause.GREATER_THAN_OR_EQUAL_TO:
                clausureSQL = ">=";
                break;
            case Clause.LESS_THAN:
                clausureSQL = "<";
                break;
            case Clause.LESS_THAN_OR_EQUAL_TO:
                clausureSQL = "<=";
                break;
            case Clause.IN:
                clausureSQL = "IN";
                break;
            case Clause.IS_NULL:
                clausureSQL = "IS NULL";
                break;
            default:
                clausureSQL = "";
                break;
        }
        return clausureSQL;
    }

}

public static class ExtentionsTypeElement
{

    public static bool conditionContainsValue(
        this TypeElement element,
        Condition condition
    )
    {
        return
            (element == TypeElement.INTEGER && condition.valueInt != null) ||
            (element == TypeElement.TEXT && condition.valueString != null) ||
            (element == TypeElement.BOOL && condition.valueBool != null) ||
            (element == TypeElement.FLOAT && condition.valueFloat != null)
            ;
    }

    public static TypeElement getTypeElementByName(string typeString) {
        foreach (TypeElement type in (TypeElement[]) Enum.GetValues(typeof(TypeElement))) { 

        }
        return TypeElement.TEXT;
    }

}
#endregion
