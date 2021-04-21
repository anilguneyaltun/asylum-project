using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3,15)]
    public string[] sentences; 
}
