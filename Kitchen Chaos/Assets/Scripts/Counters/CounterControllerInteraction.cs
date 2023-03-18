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
            if(player.HasKitchenObject()){
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
                    //plate
                    if(plateKitchenObj.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())){
                        GetKitchenObject().DestroySelf();
                    }
                    
                }
                else{
                    //no plate
                    if(GetKitchenObject().TryGetPlate(out  plateKitchenObj)){
                        if(plateKitchenObj.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())){
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else{
                GetKitchenObject().SetParent(player);
            }
            
        }

    }


    //kasih spawnpoint si counter




}
