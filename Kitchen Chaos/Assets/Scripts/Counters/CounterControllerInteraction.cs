using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//kontrol semua interaksi clear counter dengan objek lain  
public class CounterControllerInteraction : BaseCounter
{
    [SerializeField]private KitchenScriptableObject kitchenObjectSO;

    
    public override void InteractCounter(PlayerControllerInteraction player)
    {
        if(!HasKitchenObject()){
            if(player.HasKitchenObject()){
                player.GetKitchenObject().SetParent(this);
            }
            
        }
        else{
            if(!player.HasKitchenObject()){
                GetKitchenObject().SetParent(player);
            }
            
        }

    }


    //kasih spawnpoint si counter




}
