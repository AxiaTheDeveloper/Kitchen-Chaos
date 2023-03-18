using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField]private Image timer;

    private void Update() {
        timer.fillAmount = KitchenGameManager.Instance.GetGamePlayTimerNormalized();
        // Debug.Log(timer.fillAmount);
        if(timer.fillAmount >= 0.6){
            timer.color = new Color32(255,60,52,255);
        }
        else if(timer.fillAmount >= 0.3){
            timer.color = new Color32(174,255,167,255);
        }
        else {
            timer.color = new Color32(167,232,255,255);
        }
    }
}
