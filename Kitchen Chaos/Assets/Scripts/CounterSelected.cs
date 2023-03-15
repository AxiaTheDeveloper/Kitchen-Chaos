using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSelected : MonoBehaviour
{
    [SerializeField]private CounterControllerInteraction counterr;
    [SerializeField]private GameObject visualTerpilih;
    private void Start() {
        PlayerControllerInteraction.Instance.OnSelectedCounter += Player_OnSelectedCounter;
    }

    private void Player_OnSelectedCounter(object sender, PlayerControllerInteraction.OnSelectedCounterEventArgs e){
        if(e.counterTerpilih == counterr){
            muncul();
            // Debug.Log("yay");
        }
        else{
            hilang();
        }
    }
    private void muncul(){
        visualTerpilih.SetActive(true);
    }
    private void hilang(){
        visualTerpilih.SetActive(false);
    }
}
