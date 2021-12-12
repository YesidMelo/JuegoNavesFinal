using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DatetimeExtentions {
    public static string convertToString(this DateTime dateTime, DateFormats format) {

        return dateTime.ToString(format: format.getStringFormat());
    }
}