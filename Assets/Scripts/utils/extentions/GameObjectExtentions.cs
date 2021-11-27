using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtentions 
{
    public static bool minimunDistance(this GameObject currentObject, GameObject otherObject) {
        float distance = Vector2.Distance(currentObject.transform.position, otherObject.transform.position);
        return distance <= Constants.minimunDistaceBetweenPlayerEnemy;
    }

    public static void changeCurrentPositionToRandom(this GameObject currentObject) {
        float newPositionY = Random.Range(-(Constants.dimensionHeightBackground/2), (Constants.dimensionHeightBackground / 2));
        float newPositionX = Random.Range(-(Constants.dimensionWidthBackground/2), (Constants.dimensionWidthBackground / 2));
        currentObject.transform.position = new Vector3(newPositionX, newPositionY, 0);
    }

    public static void show(this GameObject gameObject) {
        gameObject.SetActive(true);
    }

    public static void hidden(this GameObject gameObject) {
        gameObject.SetActive(false);
    }
}
