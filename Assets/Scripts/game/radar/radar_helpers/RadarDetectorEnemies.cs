using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarDetectorEnemies : BaseRadarHelper
{
    public override void addObjetive(Collider2D collision)
    {
        GameObject parent = collision.transform.parent.gameObject;
        if (parent.transform.parent == null) return;
        GameObject grandParent = parent.transform.parent.gameObject;
        if (!grandParent.name.Contains(Constants.nameEnemy)) return;
        if (_objetives.Contains(collision.gameObject)) return;
        _objetives.Add(collision.gameObject);
    }

    public override void changeObjetive()
    {
        if (_objetives.Count == 0) return;
        if (_objetives.Count == 1) {
            _currentObjective = _objetives[0];
            return;
        }
        GameObject toChange = _currentObjective;
        _objetives.Remove(toChange);
        _currentObjective = _objetives[0];
        _objetives.Add(toChange);
    }

    public override void removeEnemy(Collider2D collision)
    {
        GameObject parent = collision.transform.parent.gameObject;
        if (parent.transform.parent == null) return;
        GameObject grandParent = parent.transform.parent.gameObject;
        if (!grandParent.name.Contains(Constants.nameEnemy)) return;
        if (!_objetives.Contains(collision.gameObject)) return;
        if (collision.gameObject == _currentObjective) {
            _currentObjective = null;
        }
        _objetives.Remove(collision.gameObject);
    }
}
