using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSelected : MonoBehaviour
{
    [SerializeField]private BaseCounter counterr;
    [SerializeField]private GameObject[] visualTerpilih;
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
        foreach(GameObject visualSelect in visualTerpilih){
            visualSelect.SetActive(true);
        } 
    }
    private void hilang(){
        foreach(GameObject visualSelect in visualTerpilih) {
            visualSelect.SetActive(false);
        }
    }
}
