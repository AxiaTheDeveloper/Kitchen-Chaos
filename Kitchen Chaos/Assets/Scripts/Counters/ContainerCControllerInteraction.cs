using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCControllerInteraction : BaseCounter
{
    [SerializeField]private KitchenScriptableObject kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObj;

    public override void InteractCounter(PlayerControllerInteraction player)
    {
        if(!player.HasKitchenObject()){
            KitchenObject.SpawnKitchenObj(kitchenObjectSO, player);
        
            OnPlayerGrabbedObj?.Invoke(this,EventArgs.Empty);
        }
        
            
            // Debug.Log(kitchenObjSpawn.GetComponent<KitchenObject>().GetKitchenObject().objName);
            
    }


     //kasih spawnpoint si counter
    
}
