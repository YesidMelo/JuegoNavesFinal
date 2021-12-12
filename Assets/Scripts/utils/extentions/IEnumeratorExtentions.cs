using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IEnumeratorExtentions {
    public static string getStringFormat(this DateFormats dateformat) {
        string currentFormat;
        switch (dateformat) {
            default:
                currentFormat = "yyyy-MM-ddThh:mm:ss";
                break;
        }
        return currentFormat;
    }
}
