using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Functions 
{
    public static float getAngleBetweenTwoVector2(Vector2 me, Vector2 target) {
        return (float) (Math.Atan2(target.y - me.y, target.x - me.x) * (180 / Math.PI));
    }

    public static Quadrant getCuadrant (Vector2 target) {
        if (target.x < 0 && target.y > 0) {
            return Quadrant.QUADRANT_2;
        }
        if (target.x < 0 && target.y < 0)
        {
            return Quadrant.QUADRANT_3;
        }
        if (target.x > 0 && target.y < 0)
        {
            return Quadrant.QUADRANT_4;
        }
        return Quadrant.QUADRANT_1;
    }

    public static float getAngleLookAt(Vector2 me, Vector2 target) => getAngleBetweenTwoVector2(me, target) - 90;

    public static float getAngle(this Vector2 currentVector) {
        float currentAngle = (float)(Math.Atan2(currentVector.y, currentVector.x) * (180 / Math.PI)) ;
        return currentAngle;
    }

    public static float generateRandomNumberBetween(float number1, float number2) {
        return Random.Range(number1, number2);
    }
}
