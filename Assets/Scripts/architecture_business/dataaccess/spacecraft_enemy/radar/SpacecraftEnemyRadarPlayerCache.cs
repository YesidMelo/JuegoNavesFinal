using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRadarPlayerCache {
    List<GameObject> getCurrentPlayers(IdentificatorModel identificator);
    GameObject currentPlayer(IdentificatorModel identificator);

    void addPlayer(IdentificatorModel identificator, GameObject player);
    void removePlayer(IdentificatorModel identificator, GameObject player);
}

public class SpacecraftEnemyRadarPlayerCacheImpl : SpacecraftEnemyRadarPlayerCache
{
    // static variables
    private static SpacecraftEnemyRadarPlayerCacheImpl instance;

    // static methods
    public static SpacecraftEnemyRadarPlayerCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyRadarPlayerCacheImpl();
        }
        return instance;
    }

    private Dictionary<IdentificatorModel, List<GameObject>> _currentListPlayer = new Dictionary<IdentificatorModel, List<GameObject>>();
    private Dictionary<IdentificatorModel, GameObject> _currentPlayer = new Dictionary<IdentificatorModel, GameObject>();

    public GameObject currentPlayer(IdentificatorModel identificator)
    {
        return _currentPlayer[identificator];
    }

    public List<GameObject> getCurrentPlayers(IdentificatorModel identificator)
    {
        if (!_currentListPlayer.ContainsKey(identificator)) return new List<GameObject>();
        return _currentListPlayer[identificator];
    }

    public void addPlayer(IdentificatorModel identificator, GameObject player)
    {
        if (_currentListPlayer.ContainsKey(identificator)) return;
        if (!player.name.Contains(Constants.nameShieldPlayer)) return;
        List<GameObject> listPlayers = new List<GameObject>();
        listPlayers.Add(player);
        _currentListPlayer.Add(identificator, listPlayers);
        _currentPlayer[identificator] = player;
    }

    public void removePlayer(IdentificatorModel identificator, GameObject player)
    {
        if (!_currentListPlayer.ContainsKey(identificator)) return;
        List<GameObject> getListPlayers = _currentListPlayer[identificator];
        if (!getListPlayers.Contains(player)) return;
        getListPlayers.Remove(player);
        if (_currentPlayer[identificator] != player) return;
        _currentPlayer[identificator] = null;
    }
}