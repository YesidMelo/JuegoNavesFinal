using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class PrimaryKey: Attribute { }

[AttributeUsage(AttributeTargets.Field)]
public class NotNull : Attribute { }