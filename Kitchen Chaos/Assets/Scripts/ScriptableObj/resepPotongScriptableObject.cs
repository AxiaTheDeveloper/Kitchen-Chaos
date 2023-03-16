using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class resepPotongScriptableObject : ScriptableObject
{
    public KitchenScriptableObject bahan;
    public KitchenScriptableObject hasilPotong;

    public int totalPotongan;
}
