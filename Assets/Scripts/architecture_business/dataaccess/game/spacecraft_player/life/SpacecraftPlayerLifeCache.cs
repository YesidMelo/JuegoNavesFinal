using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeCache
{
    public float life { get; }
    public StructurePlayer currentStructure { get; }
    public LifeModel currentLifeModel { get; }
    public float maxLife { get; }
    public void addLife(float life); 
    public void addStructureLife(StructurePlayer structure);
    public bool loadLife();
    public void quitLife(float life);
    public void setCurrentLifeModel(LifeModel lifeModel);
    public void updateCurrentLife(float currentLife);
    public void restoreLife();
    public void clearCache();
}

public class SpacecraftPlayerLifeCacheImpl : SpacecraftPlayerLifeCache
{
    private static SpacecraftPlayerLifeCacheImpl instance;

    public static SpacecraftPlayerLifeCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerLifeCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private float _maxLife = 1000;
    private float _life = 0;
    private StructurePlayer _currentStructure = StructurePlayer.TYPE_1;
    private LifeModel _currentLifeModel = new LifeModel();

    private SpacecraftPlayerLifeCacheImpl() {}

    public float life => _life;

    public float maxLife => _maxLife;

    public StructurePlayer currentStructure => _currentStructure;

    public LifeModel currentLifeModel {
        get {
            _currentLifeModel.life = _life;
            _currentLifeModel.maxLife = _maxLife;
            return _currentLifeModel;
        }
    }
    public void clearCache()
    {
        _maxLife = 1000;
        _life = 0;
        _currentStructure = StructurePlayer.TYPE_1;
        _currentLifeModel = new LifeModel();
    }

    public void addLife(float life)
    {
        if (_life == _maxLife) return;
        float finalLife = _life + life;
        if (finalLife >= _maxLife)
        {
            _life = _maxLife;
            _currentLifeModel.life = life;
            return;
        }
        _life = finalLife;
        _currentLifeModel.life = life;
    }

    public void addStructureLife(StructurePlayer structure)
    {
        _currentStructure = structure;
        elementsLife();
    }

    public bool loadLife() {
        if (_currentLifeModel.life == 0 && _currentLifeModel.maxLife == 0) {
            elementsLife();
        }
        return true;
    }

    public void quitLife(float life)
    {
        if (_life == 0) return;
        float finalLife = _life - life;
        if (finalLife <= 0)
        {
            _life = 0;
            _currentLifeModel.life = life;
            return;
        }
        _life = finalLife;
        _currentLifeModel.life = life;
    }

    public void updateCurrentLife(float currentLife)
    {
        _life = currentLife;
        _currentLifeModel.life = life;
    }

    public void setCurrentLifeModel(LifeModel lifeModel) { 
        _currentLifeModel = lifeModel;
        _life = _currentLifeModel.life;
    }

    public void restoreLife()
    {
        _life = _maxLife;
    }

    //private methods
    private void elementsLife() {
        switch (_currentStructure)
        {
            case StructurePlayer.TYPE_2:
                _maxLife = Constants.lifePlayerStructureType2;
                _life = _maxLife;
                _currentLifeModel.maxLife = life;
                return;
            case StructurePlayer.TYPE_3:
                _maxLife = Constants.lifePlayerStructureType3;
                _life = _maxLife;
                _currentLifeModel.maxLife = life;
                return;
            case StructurePlayer.TYPE_4:
                _maxLife = Constants.lifePlayerStructureType4;
                _life = _maxLife;
                _currentLifeModel.maxLife = life;
                return;
            case StructurePlayer.TYPE_5:
                _maxLife = Constants.lifePlayerStructureType5;
                _life = _maxLife;
                _currentLifeModel.maxLife = life;
                return;
            default:
                _maxLife = Constants.lifePlayerStructureType1;
                _life = _maxLife;
                _currentLifeModel.maxLife = life;
                return;
        }
    }

}
