using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateKitchenObj : KitchenObject
{
    //event
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs{
        public KitchenScriptableObject kitchenObjSO;
    }
    [SerializeField]private List<KitchenScriptableObject> bisaDiletakkanKitchenObjSOList;
    private List<KitchenScriptableObject> kitchenObjSOList;

    private void Awake() {
        kitchenObjSOList = new List<KitchenScriptableObject>();
    }
    public bool TryAddIngredient(KitchenScriptableObject kitchenObjSO){
        if(!bisaDiletakkanKitchenObjSOList.Contains(kitchenObjSO)) return false;
        if(kitchenObjSOList.Contains(kitchenObjSO)){
            return false;
        }
        else{
            kitchenObjSOList.Add(kitchenObjSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs{
                kitchenObjSO = kitchenObjSO
            });
            return true;
        }
        
    }

    public List<KitchenScriptableObject> GetKitchenObjSOList(){
        return kitchenObjSOList;
    }
}
