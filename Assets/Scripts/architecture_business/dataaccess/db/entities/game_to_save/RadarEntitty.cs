using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Entity]
public class RadarEntitty {

    [PrimaryKey]
    public long? id;

    [NotNull]
    public long? gameModelId;

    [NotNull]
    public long? typeRadarId;

}