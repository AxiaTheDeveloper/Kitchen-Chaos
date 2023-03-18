using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadingScreenScene{
   

    public enum Scene{
        MainMenu, MainGame, LoadingScreen
    }
    public static Scene targetNextSceneIndex;
    public static void Load(Scene targetNextSceneIndex){
        LoadingScreenScene.targetNextSceneIndex = targetNextSceneIndex;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());

        
    }

    public static void LoaderCallBack(){
        SceneManager.LoadScene(targetNextSceneIndex.ToString());
    }

}
