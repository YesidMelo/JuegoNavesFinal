using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Entity]
public class LifeEntity {
    [PrimaryKey]
    public long? id;

    [NotNull]
    public long? gameModelId;

    [NotNull]
    public long? typeLifeId;

    [NotNull]
    public float life;

    [NotNull]
    public float maxLife;
}
