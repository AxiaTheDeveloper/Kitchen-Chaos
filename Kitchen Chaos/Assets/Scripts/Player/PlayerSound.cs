using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private PlayerControllerMovement player;
    private float waktuFootStep;
    [SerializeField]private float totalWaktuFootStep;
    [SerializeField]private float volumeSound;
    private void Awake() {
        player = GetComponent<PlayerControllerMovement>();
    }
    private void Update() {
        waktuFootStep -= Time.deltaTime;
        if(waktuFootStep <= 0f){
            waktuFootStep = totalWaktuFootStep;
            if(player.GetIsJalan()){
                SoundManager.Instance.PlayerFootStep(player.transform.position, volumeSound);
            }
            
        }
    }
}
