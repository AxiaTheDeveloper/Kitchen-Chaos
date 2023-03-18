using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInput : MonoBehaviour
{
    // float keyInputx = 0, keyInputy = 0;

    public static GameInput Instance {get; private set;}
    private Vector2 keyInput = new Vector2(0,0);

    private bool checkInputInteract = false;
    private bool checkInputInteractLain = false;
    private bool checkInputPause = false;

    [SerializeField]KeyGameInputManager keyGameInputManager;
    
    private void Awake() {
        Instance = this;
        
        // keyGameInputManager = KeyGameInputManager.Instance;
    }
    // private void Update() {
    //     Debug.Log(keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveUp));
    // }
    
    public Vector2 GetInputGerakkanNormalized(){
        // keyInputx = 0, keyInputy = 0;
        keyInput.Set(0,0);

        if(keyGameInputManager.GetKeyCode(KeyGameInputManager.KeyBinding.moveUp)) keyInput.y = 1;
        if(keyGameInputManager.GetKeyCode(KeyGameInputManager.KeyBinding.moveDown)) keyInput.y = -1;
        if(keyGameInputManager.GetKeyCode(KeyGameInputManager.KeyBinding.moveRight)) keyInput.x = 1;
        if(keyGameInputManager.GetKeyCode(KeyGameInputManager.KeyBinding.moveLeft)) keyInput.x = -1;
    
        keyInput = keyInput.normalized; //biar kalau gerak diagonal ga lebih cepat dari gerak hrzntl/vrtkl

        return keyInput;
    }

    public bool GetInputInteract(){
        if(keyGameInputManager.GetKeyCodeDown(KeyGameInputManager.KeyBinding.interact)) {
            checkInputInteract = true; 
        }
        else{
            checkInputInteract = false;
        }
        return checkInputInteract;

        // if(Input.GetKey(KeyCode.E)) {
        //     interactAct?.Invoke(this, EventArgs.Empty);
        // }
    }
    public bool GetInputInteractLain(){
        if(keyGameInputManager.GetKeyCodeDown(KeyGameInputManager.KeyBinding.interactLain)) {
            checkInputInteractLain = true; 
        }
        else{
            checkInputInteractLain = false;
        }
        return checkInputInteractLain;
    }
    public bool GetInputPause(){
        if(keyGameInputManager.GetKeyCodeDown(KeyGameInputManager.KeyBinding.Pause)) {
            checkInputPause = true; 
        }
        else{
            checkInputPause = false;
        }
        return checkInputPause;
    }

    

}
