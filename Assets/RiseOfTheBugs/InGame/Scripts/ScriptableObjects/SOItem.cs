using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Type", menuName = "Scriptable Objects/New Item Type", order = 1)]
public class SOItem : ScriptableObject
{
    public string itemName; //Patch / Fix / Improvement
    public float efficiency; // 0.25 / 0.5 / 0.75 / 1
    public float size;

}