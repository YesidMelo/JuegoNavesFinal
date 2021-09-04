using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftFactory : MonoBehaviour
{
    public List<GameObject> prefabs = new List<GameObject>();

    public GameObject spacecraftSelectedGame(
        Spacecraft spaceCraftSelected
    ) {
        GameObject selected;
        switch (spaceCraftSelected) {
            case Spacecraft.SPACECRAFT_2:
                selected = prefabs[1];
                break;
            case Spacecraft.SPACECRAFT_3:
                selected = prefabs[2];
                break;
            case Spacecraft.SPACECRAFT_4:
                selected = prefabs[3];
                break;
            case Spacecraft.SPACECRAFT_5:
                selected = prefabs[4];
                break;
            case Spacecraft.SPACECRAFT_1:
            default:
                selected = prefabs[0];
                break;
        }
        return selected;
    }

    public GameObject spacecraftSelectedPlayer(
        Spacecraft spaceCraftSelected
    ) {
        GameObject selected;
        switch (spaceCraftSelected)
        {
            case Spacecraft.SPACECRAFT_2:
                selected = prefabs[1];
                break;
            case Spacecraft.SPACECRAFT_3:
                selected = prefabs[2];
                break;
            case Spacecraft.SPACECRAFT_4:
                selected = prefabs[3];
                break;
            case Spacecraft.SPACECRAFT_5:
                selected = prefabs[4];
                break;
            case Spacecraft.SPACECRAFT_1:
            default:
                selected = prefabs[0];
                break;
        }
        return selected;
    }
}
