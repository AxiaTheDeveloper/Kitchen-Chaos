using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlateVisualIconUI : MonoBehaviour
{
    [SerializeField]private Image imageIcon;
    public void SetKitchenObjectSO(KitchenScriptableObject kitchenObjSO){
        imageIcon.sprite = kitchenObjSO.sprite;
    }
}
