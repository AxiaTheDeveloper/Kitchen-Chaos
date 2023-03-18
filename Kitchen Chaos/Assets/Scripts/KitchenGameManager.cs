using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KitchenGameManager : MonoBehaviour
{
    //event kshtau tiap state berubah
    public static KitchenGameManager Instance {get; private set;}
    public event EventHandler OnStateChanged;
    public event EventHandler OnInputPause;
    public event EventHandler OnGamePause;
    public event EventHandler OnGameUnPause;

    public event EventHandler OnInteractStartGame;
    private bool isGamePause = false;

    [SerializeField]private GameInput inputKey;
    
    private enum StateGame{
        WaitingToStart, CountDownToStart, GameStart, GameOver
    }
    
    private StateGame state;
    // private float waitingTimer = 1f;
    [SerializeField]private float countDownTimer;
    private float gamePlayTimer;
    [SerializeField]private float gamePlayTimerTotal;
    private void Awake() {
        Instance = this;
        if(Instance != null){
            Debug.Log("BENAR");
        }
        state = StateGame.WaitingToStart;
        // Debug.Assert(Instance != null, "GameInput instance is null");
    }
    private void Start() {
        
        OnInputPause += gameManager_OnInputPause;
        OnInteractStartGame += gameManager_OnInteractStartGame;
    }

    private void gameManager_OnInputPause(object sender, System.EventArgs e){
        // counterTerpilih.interactWithCounter();
        PauseGame();
        // Debug.Log(counterTerpilih.transform);
    }
    private void gameManager_OnInteractStartGame(object sender, System.EventArgs e){
        if(state == StateGame.WaitingToStart){
            state = StateGame.CountDownToStart;
            EventStateChanged();
        }
    }

    private void Update() {
        if(inputKey.GetInputPause()){
            OnInputPause?.Invoke(this, EventArgs.Empty);
        }
        if(inputKey.GetInputInteract()){
            OnInteractStartGame?.Invoke(this, EventArgs.Empty);
        }
        else if(state == StateGame.CountDownToStart){
            countDownTimer -= Time.deltaTime;
            if(countDownTimer <= 0f){
                state = StateGame.GameStart;
                gamePlayTimer = gamePlayTimerTotal;
                EventStateChanged();
            }
        }
        else if(state == StateGame.GameStart){
            gamePlayTimer -= Time.deltaTime;
            // Debug.Log(gamePlayTimer);
            if(gamePlayTimer <= 0f){
                state = StateGame.GameOver;
                EventStateChanged();
            }
        }
        else if(state == StateGame.GameOver){
            
        }
        // Debug.Log(state);
    }

    public bool IsGameStart(){
        return state == StateGame.GameStart;
    }
    public bool IsCountDownToStart(){
        return state == StateGame.CountDownToStart;
    }

    private void EventStateChanged(){
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public float GetCountDownTimer(){
        return countDownTimer;
    }

    public bool IsGameOver(){
        return state == StateGame.GameOver;
    }
    public float GetGamePlayTimerNormalized(){
        return 1 - (gamePlayTimer/gamePlayTimerTotal);
    }

    public void PauseGame(){
        isGamePause = !isGamePause;
        if(isGamePause){
            Time.timeScale = 1f;
            OnGameUnPause?.Invoke(this,EventArgs.Empty);
        }
        else{
            Time.timeScale = 0f;
            
            OnGamePause?.Invoke(this,EventArgs.Empty);
        }
        
    }

}
