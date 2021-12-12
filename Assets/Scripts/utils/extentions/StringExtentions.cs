using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtentions {
    
    public static DateTime convertToDateTime(this string date, DateFormats format) {
        return DateTime.ParseExact(date, format: format.getStringFormat(), null);
    }

}