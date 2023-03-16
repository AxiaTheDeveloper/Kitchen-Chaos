using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class resepMasakScriptableObject : ScriptableObject
{
    public KitchenScriptableObject bahan;
    public KitchenScriptableObject hasilJadi;

    public float durasiMasak;
}
