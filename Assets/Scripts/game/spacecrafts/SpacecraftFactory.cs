using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftFactory : MonoBehaviour
{

    public bool createSpaceCraft = false;
    public List<GameObject> prefabs = new List<GameObject>();


    private void Update()
    {
        createSpaceCraftMethod();
    }

    private void createSpaceCraftMethod() {
        if (!createSpaceCraft) {
            return;
        }
        createSpaceCraft = false;
        spacecraftSelectedGame(Spacecraft.SPACECRAFT_1);
    }

    public GameObject spacecraftSelectedGame(Spacecraft spaceCraftSelected) {
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
        GameObject instantiated = Instantiate(selected);
        return instantiated;
    }

    public GameObject spacecraftSelectedGamer(Spacecraft spaceCraftSelected)
    {
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
        GameObject instantiated = Instantiate(selected);
        return instantiated;
    }
}
