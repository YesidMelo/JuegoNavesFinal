using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface JoysticCache {
    void updatePositionJoystic(Vector2 direction);
    Vector2 currentDirection { get; }
}

public class JoysticCacheImpl : JoysticCache
{

    // static
    private static JoysticCacheImpl instance;

    public static JoysticCacheImpl getInstance() {
        if (instance == null) {
            instance = new JoysticCacheImpl();
        }
        return instance;
    }

    // class

    private JoysticCacheImpl() { }

    private Vector2 _currentDirection = new Vector2(0,0);

    public Vector2 currentDirection => _currentDirection;

    public void updatePositionJoystic(Vector2 direction) => _currentDirection = direction;
}
