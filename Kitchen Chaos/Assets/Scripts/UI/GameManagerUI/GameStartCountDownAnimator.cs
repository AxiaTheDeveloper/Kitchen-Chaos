using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartCountDownAnimator : MonoBehaviour
{
    [SerializeField]private GameStartCountDownUI gameStartCDUI;
    private Animator animatorController;
    private const string POP_UP = "PopUp";
    private void Awake() {
        animatorController = GetComponent<Animator>();
    }

    private void Start() {
        gameStartCDUI.OnCountDownNumberChange += gameStartCountDown_OnCountDownNumberChange;
    }

    private void gameStartCountDown_OnCountDownNumberChange(object sender, System.EventArgs e){
        animatorController.SetTrigger(POP_UP);
    }
}
