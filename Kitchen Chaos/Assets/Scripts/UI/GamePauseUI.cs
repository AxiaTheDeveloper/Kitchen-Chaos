using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField]private Button resumeButton;
    [SerializeField]private Button maineMenuButton;
    [SerializeField]private Button optionButton;
    private void Awake(){
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.PauseGame();
        });
        maineMenuButton.onClick.AddListener(() => {
            LoadingScreenScene.Load(LoadingScreenScene.Scene.MainMenu);
        });
        optionButton.onClick.AddListener(() => {
            OptionsUI.Instance.Show();
        });
    }
    private void Start() {
        KitchenGameManager.Instance.OnGamePause += KitchenGameManager_OnGamePause;
        KitchenGameManager.Instance.OnGameUnPause += KitchenGameManager_OnGameUnPause;
        Hide();
    }
    private void KitchenGameManager_OnGamePause(object sender, System.EventArgs e){
        Show();
    }
    private void KitchenGameManager_OnGameUnPause(object sender, System.EventArgs e){
        Hide();
    }
    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
