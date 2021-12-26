using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Entity]
public class GameEntity : BaseDBEntity {

    [PrimaryKey]
    public long? id;

    [NotNull]
    public string namePlayer;

    [NotNull]
    public DateTime date;

}