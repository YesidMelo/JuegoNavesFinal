using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLaserCache {
    public void deleteLaser(IdentificatorModel identificatorModel);
    public Laser finalImpactLaser(IdentificatorModel identificatorModel);
    public List<Laser> listLasers(IdentificatorModel identificatorModel);
    public int mediaImpactLaser(IdentificatorModel identificatorModel);
    public void setListLasers(List<Laser> listLasers, IdentificatorModel identificatorModel);

}

public class SpacecraftEnemyLaserCacheImpl : SpacecraftEnemyLaserCache
{
    private static SpacecraftEnemyLaserCacheImpl _instance;
    public static SpacecraftEnemyLaserCacheImpl getInstance()
    {
        if (_instance == null) {
            _instance = new SpacecraftEnemyLaserCacheImpl();
        }
        return _instance;
    }

    private Dictionary<IdentificatorModel, Laser> _allFinalImpactLaser = new Dictionary<IdentificatorModel, Laser>();
    private Dictionary<IdentificatorModel, List<Laser>> _allListLasers = new Dictionary<IdentificatorModel, List<Laser>>();
    private Dictionary<IdentificatorModel, int> _allMediaImpactLaser = new Dictionary<IdentificatorModel, int>();

    private SpacecraftEnemyLaserCacheImpl() { }

    public void deleteLaser(IdentificatorModel identificatorModel)
    {
        deleteElementFromDictonary<Laser>(_allFinalImpactLaser, identificatorModel);
        deleteElementFromDictonary<List<Laser>>(_allListLasers, identificatorModel);
        deleteElementFromDictonary<int>(_allMediaImpactLaser, identificatorModel);
    }

    public Laser finalImpactLaser(IdentificatorModel identificatorModel)
    {
        if (_allFinalImpactLaser.ContainsKey(identificatorModel)) {
            return _allFinalImpactLaser[identificatorModel];
        }
        return Laser.TYPE_1;
    }

    public List<Laser> listLasers(IdentificatorModel identificatorModel)
    {
        if (_allListLasers.ContainsKey(identificatorModel)) {
            return _allListLasers[identificatorModel];
        }
        return new List<Laser>();
    }

    public int mediaImpactLaser(IdentificatorModel identificatorModel)
    {
        if (_allMediaImpactLaser.ContainsKey(identificatorModel)) {
            return _allMediaImpactLaser[identificatorModel];
        }
        return (int)Constants.laserType1;
    }

    public void setListLasers(List<Laser> listLasers, IdentificatorModel identificatorModel)
    {
        if (identificatorModel == null) return;
        if (_allListLasers.ContainsKey(identificatorModel)) return;
        _allListLasers.Add(identificatorModel, listLasers);
        _allMediaImpactLaser.Add(identificatorModel, calculateMediaImpactLaser(identificatorModel));
        _allFinalImpactLaser.Add(identificatorModel, calculateFinalImpactLaser(identificatorModel));
    }

    //private methods

    int calculateMediaImpactLaser(IdentificatorModel identificatorModel)
    {
        int finalMediaImpactLaser = 0;
        for (int index = 0; index < _allListLasers[identificatorModel].Count; index++)
        {
            finalMediaImpactLaser = finalMediaImpactLaser + getImpactLaserFromType(_allListLasers[identificatorModel][index]);
        }

        return finalMediaImpactLaser / _allListLasers[identificatorModel].Count;
    }

    int getImpactLaserFromType(Laser laser)
    {
        switch (laser)
        {
            case Laser.TYPE_2:
                return (int)Constants.laserType2;
            case Laser.TYPE_3:
                return (int)Constants.laserType3;
            case Laser.TYPE_4:
                return (int)Constants.laserType4;
            case Laser.TYPE_5:
                return (int)Constants.laserType5;
            case Laser.TYPE_1:
            default:
                return (int)Constants.laserType1;
        }
    }

    Laser calculateFinalImpactLaser(IdentificatorModel identificatorModel)
    {
        if (_allMediaImpactLaser[identificatorModel] > 0 && _allMediaImpactLaser[identificatorModel] < Constants.laserType2) return Laser.TYPE_1;
        if (Constants.laserType2 <= _allMediaImpactLaser[identificatorModel] && _allMediaImpactLaser[identificatorModel] < Constants.laserType3) return Laser.TYPE_2;
        if (Constants.laserType3 <= _allMediaImpactLaser[identificatorModel] && _allMediaImpactLaser[identificatorModel] < Constants.laserType4) return Laser.TYPE_3;
        if (Constants.laserType4 <= _allMediaImpactLaser[identificatorModel] && _allMediaImpactLaser[identificatorModel] < Constants.laserType5) return Laser.TYPE_4;
        return Laser.TYPE_5;
    }

    private void deleteElementFromDictonary<K>(Dictionary<IdentificatorModel, K> dictionary, IdentificatorModel identificatorModel) {
        if (!dictionary.ContainsKey(identificatorModel)) return;
        dictionary.Remove(identificatorModel);
    }
}