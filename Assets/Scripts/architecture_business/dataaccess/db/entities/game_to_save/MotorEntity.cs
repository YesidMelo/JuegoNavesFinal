using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Entity]
public class MotorEntity {
    [PrimaryKey]
    public long? id;

    [NotNull]
    public long? gameModelId;

    [NotNull]
    public long? typeMotorId;
}