using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Entity]
public class LifeEntity : BaseDBEntity{
    [PrimaryKey]
    public long? id;

    [NotNull]
    public long? gameModelId;

    public long? typeLifeId;

    [NotNull]
    public float life;

    [NotNull]
    public float maxLife;
}
