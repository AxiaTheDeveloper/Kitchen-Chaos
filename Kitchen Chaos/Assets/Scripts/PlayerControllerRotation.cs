using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRotation : MonoBehaviour
{

    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    [SerializeField]private float kecepatanRotasi;

    //ambil arah perpindahan dr PlayerControllerMovement
    [SerializeField]private PlayerControllerMovement movement;

    //Untuk Animasi - PlayerAnimator
    private bool isJalan;
    private void Update()
    {
        RotasiKarakter();
        // Debug.Log(getIsJalan());
    }

    private void RotasiKarakter(){
        arahPerpindahan = movement.GetArahPerpindahan();
        //rotasi karakter sesuai arah gerak
        transform.forward = Vector3.Slerp(transform.forward, arahPerpindahan, kecepatanRotasi * Time.deltaTime);
    }

}
