using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface JoysticRepository {
    void updateMovementJoystic(Vector2 direction);
    Vector2 currentMovementJoystic { get; }
}

public class JoysticRepositoryImpl : JoysticRepository
{

    private JoysticCache joysticCache = JoysticCacheImpl.getInstance();

    public Vector2 currentMovementJoystic => joysticCache.currentDirection;

    public void updateMovementJoystic(Vector2 direction) => joysticCache.updatePositionJoystic(direction);
}
