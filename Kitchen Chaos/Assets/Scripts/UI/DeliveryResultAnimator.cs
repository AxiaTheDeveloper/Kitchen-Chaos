using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultAnimator : MonoBehaviour
{
    [SerializeField]private DeliveryResultUI deliveryResultUI;
    private Animator animatorController;
    private const string POP_UP = "PopUp";
    private void Awake() {
        animatorController = GetComponent<Animator>();
    }

    private void Start() {
        deliveryResultUI.OnDelivery += deliveryResult_OnDelivery;
    }

    private void deliveryResult_OnDelivery(object sender, System.EventArgs e){
        animatorController.SetTrigger(POP_UP);
        
    }
}
