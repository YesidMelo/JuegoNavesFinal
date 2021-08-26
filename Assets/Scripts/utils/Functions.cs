using System;
using System.Collections;
using UnityEngine;

public static class Functions 
{
    public static float getAngle(Vector2 me, Vector2 target) {
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

    public static float getAngleLookAt(Vector2 me, Vector2 target) => getAngle(me, target) - 90;
}
