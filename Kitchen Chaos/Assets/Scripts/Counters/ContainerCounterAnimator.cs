using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnimator : MonoBehaviour
{
    [SerializeField]private ContainerCControllerInteraction containerCounter;
    private Animator animatorController;
    private const string OPEN_CLOSE = "OpenClose";
    private void Awake() {
        animatorController = GetComponent<Animator>();
    }

    private void Start() {
        containerCounter.OnPlayerGrabbedObj += containerC_OnPlayerGrabbedObj;
    }

    private void containerC_OnPlayerGrabbedObj(object sender, System.EventArgs e){
        animatorController.SetTrigger(OPEN_CLOSE);
    }

}
