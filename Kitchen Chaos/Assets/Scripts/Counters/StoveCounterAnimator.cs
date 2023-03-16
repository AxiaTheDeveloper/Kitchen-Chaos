using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterAnimator : MonoBehaviour
{
    [SerializeField]private StoveCControllerInteraction stoveCounter;
    [SerializeField]private GameObject komporNyalaEffect;
    [SerializeField]private GameObject masakPartikelEffect;
    private void Start() {
        stoveCounter.OnStateChanged += stoveC_OnStateChanged;
    }   
    private void stoveC_OnStateChanged(object sender, StoveCControllerInteraction.OnStateChangedEventArgs e){
        bool showEffect = e.state == StoveCControllerInteraction.StateKompor.Memasak || e.state == StoveCControllerInteraction.StateKompor.Jadi;
        
        komporNyalaEffect.SetActive(showEffect);
        masakPartikelEffect.SetActive(showEffect);
    }
   
   
}
