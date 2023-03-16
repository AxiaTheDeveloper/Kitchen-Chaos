using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//agar ui lsg melihat ke kamera
public class UILookAtCamera : MonoBehaviour
{
    private enum LookAtMode{
        biasa, terbalik, lurus, lurusTerbalik
    }

    [SerializeField]private LookAtMode lookAtMode;
    private void LateUpdate() {
        if(lookAtMode == LookAtMode.biasa){
            transform.LookAt(Camera.main.transform);
        }
        else if(lookAtMode == LookAtMode.terbalik) {
            Vector3 arahKeCamera = transform.position - Camera.main.transform.position;
            transform.LookAt(transform.position + arahKeCamera);
        }
        else if(lookAtMode == LookAtMode.lurus) {
            transform.forward = Camera.main.transform.position;
        }
        else if(lookAtMode == LookAtMode.lurusTerbalik) {
            transform.forward = -Camera.main.transform.position;
        }
    }
}
