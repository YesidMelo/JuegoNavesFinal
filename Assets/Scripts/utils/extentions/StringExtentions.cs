using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class StringExtentions {
    
    public static DateTime convertToDateTime(this string date, DateFormats format) {
        return DateTime.ParseExact(date, format: format.getStringFormat(), null);
    }

    public static string addRandomString(this string current, int length) {
        System.Random random = new System.Random();
        char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        StringBuilder builder = new StringBuilder();
        builder.Append(current);

        for (int index = 0; index < length; index++) {
            builder.Append(chars[random.Next(chars.Length)].ToString());            
        }

        return builder.ToString();

    }

}