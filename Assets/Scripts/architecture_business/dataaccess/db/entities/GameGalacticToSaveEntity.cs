using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGalacticToSaveEntity : BaseDBEntity
{
    [PrimaryKey]
    public long? id;

    [NotNull]
    public string? name;
    public DateTime? dateTime;
    public bool? ejem; 
}