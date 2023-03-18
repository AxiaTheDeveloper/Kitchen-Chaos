using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateComplete : MonoBehaviour
{
    [Serializable]public struct kitchenObjSO_GameObjVisual{
        public KitchenScriptableObject kitchenObjSO;
        public GameObject gameObj;
    }
    [SerializeField]private PlateKitchenObj plateKitchenObj;
    [SerializeField]private List<kitchenObjSO_GameObjVisual> kitchenObjGameObjList;

    // private void Awake(){
    //     kitchenObjGameObjList = new List<kitchenObjSO_GameObjVisual>();
    // }

    private void Start() {
        plateKitchenObj.OnIngredientAdded += plateKitchenObj_OnIngredientAdded;
        // Debug.Log("yes!");
        foreach (kitchenObjSO_GameObjVisual kitchenObjSOGameObj in kitchenObjGameObjList){
            kitchenObjSOGameObj.gameObj.SetActive(false);
            
        }
    }
    private void plateKitchenObj_OnIngredientAdded(object sender, PlateKitchenObj.OnIngredientAddedEventArgs e){
        // e.kitchenObjSO
        foreach (kitchenObjSO_GameObjVisual kitchenObjSOGameObj in kitchenObjGameObjList){
            if(kitchenObjSOGameObj.kitchenObjSO == e.kitchenObjSO){
                kitchenObjSOGameObj.gameObj.SetActive(true);
            }
        }
    }

}
