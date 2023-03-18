using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCCountrollerInteraction : BaseCounter
{
    public static event EventHandler OnTrashObjSound;
    new public static void resetStaticData(){
        OnTrashObjSound = null;
    }
    public override void InteractCounter(PlayerControllerInteraction player){
         if(player.HasKitchenObject()){
            player.GetKitchenObject().DestroySelf();
            OnTrashObjSound?.Invoke(this, EventArgs.Empty);
         }
    }
}
