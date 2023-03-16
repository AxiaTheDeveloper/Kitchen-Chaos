using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCCountrollerInteraction : BaseCounter
{
    public override void InteractCounter(PlayerControllerInteraction player){
         if(player.HasKitchenObject()){
            player.GetKitchenObject().DestroySelf();
         }
    }
}
