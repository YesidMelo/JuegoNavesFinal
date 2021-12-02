using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeCache
{
    public float life { get; }
    public StructurePlayer currentStructure { get; }
    public float maxLife { get; }
    public void addLife(float life); 
    public void addStructureLife(StructurePlayer structure);
    public bool loadLife();
    public void quitLife(float life);
    public void updateCurrentLife(float currentLife);
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

    private float _maxLife = 1000;
    private float _life = 0;
    private StructurePlayer _currentStructure = StructurePlayer.TYPE_1;

    private SpacecraftPlayerLifeCacheImpl() {}

    public float life => _life;

    public float maxLife => _maxLife;

    public StructurePlayer currentStructure => _currentStructure;

    public void addLife(float life)
    {
        if (_life == _maxLife) return;
        float finalLife = _life + life;
        if (finalLife >= _maxLife)
        {
            _life = _maxLife;
            return;
        }
        _life = finalLife;
    }

    public void addStructureLife(StructurePlayer structure)
    {
        _currentStructure = structure;
        elementsLife();
    }

    public bool loadLife()
    {
        elementsLife();
        return true;
    }

    public void quitLife(float life)
    {
        if (_life == 0) return;
        float finalLife = _life - life;
        if (finalLife <= 0)
        {
            _life = 0;
            return;
        }
        _life = finalLife;
    }

    public void updateCurrentLife(float currentLife)
    {
        _life = currentLife;
    }

    //private methods
    private void elementsLife() {
        switch (_currentStructure)
        {
            case StructurePlayer.TYPE_2:
                _maxLife = Constants.lifePlayerStructureType2;
                _life = _maxLife;
                return;
            case StructurePlayer.TYPE_3:
                _maxLife = Constants.lifePlayerStructureType3;
                _life = _maxLife;
                return;
            case StructurePlayer.TYPE_4:
                _maxLife = Constants.lifePlayerStructureType4;
                _life = _maxLife;
                return;
            case StructurePlayer.TYPE_5:
                _maxLife = Constants.lifePlayerStructureType5;
                _life = _maxLife;
                return;
            case StructurePlayer.TYPE_1:
            default:
                _maxLife = Constants.lifePlayerStructureType1;
                _life = _maxLife;
                return;
        }
    }

    
}
