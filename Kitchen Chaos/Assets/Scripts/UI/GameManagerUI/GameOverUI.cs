using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI pesananBerhasilDikirimNumber;
    [SerializeField]private Button mainMenuButton;

    // private void Awake() {
    //     gameObject.SetActive(false);
    // }

    private void Awake() {
        mainMenuButton.onClick.AddListener(() => {
            // SoundManager.Instance.ChangeVoSoundEffect();
            LoadingScreenScene.Load(LoadingScreenScene.Scene.MainMenu);
        });
    }
    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChange;
        HideCountdown();
    }
   

    private void KitchenGameManager_OnStateChange(object sender, System.EventArgs e){
        if(KitchenGameManager.Instance.IsGameOver()){
            
            pesananBerhasilDikirimNumber.text = DeliveryManager.Instance.GetTotalPesananBerhasilDikirim().ToString();
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
