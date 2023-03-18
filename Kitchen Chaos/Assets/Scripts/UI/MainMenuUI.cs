using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]private Button startButton;
    [SerializeField]private Button quitButton;


    //button gausa eksternal aturnya
    private void Awake(){
        startButton.onClick.AddListener(() => {
            LoadingScreenScene.Load(LoadingScreenScene.Scene.MainGame);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
        Time.timeScale = 1f;
    }
}
