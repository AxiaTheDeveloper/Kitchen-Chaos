using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SRP -> ngatur animasi karakter player
public class PlayerAnimator : MonoBehaviour
{
    //ambil isJalan (jalan ato ga) dari PlayerControllerMovement
    [SerializeField] private PlayerControllerMovement player;
    private Animator animatorController;
    private const string IS_JALAN = "IsJalan";



    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        animatorController.SetBool(IS_JALAN, false);
        // Debug.Log(player.getIsJalan());
    }

    private void Update(){
        // Debug.Log(player.getIsJalan());
        animatorController.SetBool(IS_JALAN, player.GetIsJalan());
        
    }
}
