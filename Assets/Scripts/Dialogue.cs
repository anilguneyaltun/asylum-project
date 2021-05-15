using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public AudioSource audioSource;
    public string name;
    [TextArea(3,15)]
    public string[] sentences;

    public AudioClip[] audioClips;
    
}
