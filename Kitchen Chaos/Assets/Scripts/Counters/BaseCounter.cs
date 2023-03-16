using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjParent
{
    [SerializeField]private Transform spawnPoint;
    private KitchenObject kitchenObject;
    public virtual void InteractCounter(PlayerControllerInteraction player){
        Debug.LogError("BaseC Interact");
    }
    
    public virtual void InteractCounterLain(PlayerControllerInteraction player){
        // Debug.LogError("CounterLain Interact");
    }
    public Transform GetKitchenObjectNewPlace(){
        return spawnPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }

    //bersihin kitchen object lama
    public void ClearKitchenObject(){
        kitchenObject = null;
    }
    public bool HasKitchenObject(){
        return (kitchenObject != null);
    }
}
