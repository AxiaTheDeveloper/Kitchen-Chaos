using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSoundController : MonoBehaviour
{
    [SerializeField]private StoveCControllerInteraction stoveCounter;
    private AudioSource audioSource;

    private float warningTimer;
    [SerializeField]private float warningTimerMax;

    private bool warningSoundPlay;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start() {
        stoveCounter.OnStateChanged += stoveC_OnStateChanged;
        stoveCounter.OnProgressChanged += stoveCounter_OnProgressChanged;
    }   
    private void Update() {
        if(warningSoundPlay){
            warningTimer -= Time.deltaTime;
            if(warningTimer <= 0){
                warningTimer = warningTimerMax;
                SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);
            }
        }
            

    }
    private void stoveC_OnStateChanged(object sender, StoveCControllerInteraction.OnStateChangedEventArgs e){
        bool komporNyala = e.state == StoveCControllerInteraction.StateKompor.Memasak || e.state == StoveCControllerInteraction.StateKompor.Jadi;
        if(komporNyala){
            audioSource.Play();
        }
        else{
            audioSource.Pause();
        }

        
    }

    private void stoveCounter_OnProgressChanged(object sender, IObjectHasProgress.OnProgressChangedEventArgs e){
        float hampirGosong = 0.5f;
        warningSoundPlay = e.progressNormalized >= hampirGosong && stoveCounter.IsJadi();
        
        
    }


}
