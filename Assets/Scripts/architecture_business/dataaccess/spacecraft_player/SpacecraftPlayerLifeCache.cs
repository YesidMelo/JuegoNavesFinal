using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeCache
{
    public float life { get; }
    public void setMaxLife(float life);

    public void addLife(float life);
    public void quitLife(float life);
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

    public float life => _life;

    public void setMaxLife(float life) { 
        _maxLife = life;
        if (_life != 0) return;
        _life = life;
    }

    public void quitLife(float life) {
        if (_life == 0) return;
        float finalLife = _life - life;
        if (finalLife <= 0) {
            _life = 0;
            return;
        }
        _life = finalLife;
    }

    public void addLife(float life)
    {
        if (_life == _maxLife) return;
        float finalLife = _life + life;
        if (finalLife >= _maxLife) {
            _life = _maxLife;
            return;
        }
        _life = finalLife;
    }
}
