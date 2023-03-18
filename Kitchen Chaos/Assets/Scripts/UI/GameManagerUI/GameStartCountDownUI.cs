using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStartCountDownUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI countDownText;

    public event EventHandler OnCountDownNumberChange;

    private int nomorSebelumnya;

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChange;
    }
    private void Update() {
        int countDownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountDownTimer());
        countDownText.text = countDownNumber.ToString();
        if(nomorSebelumnya != countDownNumber){
            nomorSebelumnya = countDownNumber;
            OnCountDownNumberChange?.Invoke(this,EventArgs.Empty);
            SoundManager.Instance.CountDownSound();
        }
    }

    private void KitchenGameManager_OnStateChange(object sender, System.EventArgs e){
        if(KitchenGameManager.Instance.IsCountDownToStart()){
            ShowCountdown();
        }
        else{
            HideCountdown();
        }
    }

    private void ShowCountdown(){
        gameObject.SetActive(true);
    }
    private void HideCountdown(){
        gameObject.SetActive(false);
    }
}
