using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterAnimator : MonoBehaviour
{
    [SerializeField]private CuttingCControllerInteraction cuttingCounter;
    private Animator animatorController;
    private const string CUT = "Cut";
    private void Awake() {
        animatorController = GetComponent<Animator>();
    }

    private void Start() {
        cuttingCounter.OnPlayerCutObj += cuttingC_OnPlayerCutObj;
    }

    private void cuttingC_OnPlayerCutObj(object sender, System.EventArgs e){
        animatorController.SetTrigger(CUT);
    }
}
