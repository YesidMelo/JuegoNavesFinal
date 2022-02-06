using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportEntity : BaseDBEntity {

    [PrimaryKey]
    public long? id;

    [NotNull]
    public long? gameModelId;

    [NotNull]
    public long? lifeSupportId;
}