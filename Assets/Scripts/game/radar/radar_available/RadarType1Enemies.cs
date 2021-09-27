using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarType1Enemies : AbstractRadar
{
    public override GameObject currentObjetive => _baseRadar != null ? _baseRadar.currentObjetive : null;

    public override List<GameObject> listObjetives => _baseRadar != null ? _baseRadar.listObjetives : new List<GameObject>();

    public override void addObjetive(Collider2D collision) {
        if (_baseRadar == null) return;
        _baseRadar.addObjetive(collision);
    }

    public override void changeObjetive()
    {
        if (_baseRadar == null) return;
        _baseRadar.changeObjetive();
    }

    public override void removeEnemy(Collider2D collision)
    {
        if (_baseRadar == null) return;
        _baseRadar.removeEnemy(collision);
    }

    protected override void selectContextRadar()
    {
        if (_currentObject.Contains(Constants.nameEnemy)) {
            _baseRadar = new RadarDetectorPlayers();
            return;
        }
        _baseRadar = new RadarDetectorEnemies();
    }
}
