using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionInterfaceRepository {
    public Move getCurrentMove();
    void setCurrentMovement(Move move);
}
public class InteractionInterfaceRepositoryImpl : InteractionInterfaceRepository
{
    private static InteractionInterfaceRepositoryImpl instance;

    public static InteractionInterfaceRepositoryImpl getInstance() {
        if (instance == null) {
            instance = new InteractionInterfaceRepositoryImpl();
        }
        return instance;
    }
    private InteractionInterfaceRepositoryImpl() { }

    private Move currentMove = Move.STOP;

    public Move getCurrentMove() => currentMove;

    public void setCurrentMovement(Move move) => currentMove = move;

}
