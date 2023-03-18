using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCControllerInteraction : BaseCounter
{
    public static DeliveryCControllerInteraction Instance {get; private set;}
    private void Awake() {
        Instance = this;
    }
    public override void InteractCounter(PlayerControllerInteraction player)
    {
        if(player.HasKitchenObject()){
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
                DeliveryManager.Instance.KirimPesanan(plateKitchenObj);
                player.GetKitchenObject().DestroySelf();
            }
            
        }
    }
}
