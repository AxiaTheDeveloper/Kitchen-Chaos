using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    // float keyInputx = 0, keyInputy = 0;
    private Vector2 keyInput = new Vector2(0,0);
    public Vector2 GetInputGerakkanNormalized(){
        // keyInputx = 0, keyInputy = 0;
        keyInput.Set(0,0);

        if(Input.GetKey(KeyCode.W)) keyInput.y = 1;
        if(Input.GetKey(KeyCode.S)) keyInput.y = -1;
        if(Input.GetKey(KeyCode.D)) keyInput.x = 1;
        if(Input.GetKey(KeyCode.A)) keyInput.x = -1;
    
        keyInput = keyInput.normalized; //biar kalau gerak diagonal ga lebih cepat dari gerak hrzntl/vrtkl

        return keyInput;
    }
}
