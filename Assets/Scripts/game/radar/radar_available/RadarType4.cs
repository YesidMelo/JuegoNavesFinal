using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarType4 : AbstractRadar {
    public override GameObject currentObjetive => null;

    public override List<GameObject> listObjetives => new List<GameObject>();

    public override void addObjetive(Collider2D collision)
    {

    }

    public override void changeObjetive()
    {

    }

    public override void removeEnemy(Collider2D collision)
    {

    }

    protected override void selectContextRadar()
    {

    }
}