using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class KeyGameInputManager : MonoBehaviour
{
    public static KeyGameInputManager Instance {get; private set;}
    [SerializeField]private KeyBindingScriptableObject keyBindingSO;

    public event EventHandler OnRebinding;

    public enum KeyBinding{
        moveUp, moveDown, moveLeft, moveRight, interact, interactLain, Pause
    }
    private bool IsDoingRebinding = false;
    private KeyBinding rebindingKey;

    private void Awake() {
        Instance = this;
        if(Instance != null){
            // Debug.Log("hi!");
        }
    }

    private void Update(){
        
        if (Input.anyKey && IsDoingRebinding)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    
                    for(int i = 0; i < keyBindingSO.keyBindingCheck.Length;i++){
                        if(keyBindingSO.keyBindingCheck[i].keyBinding == rebindingKey){
                            // Debug.Log(keyBindingSO.keyBindingCheck[i].keyCode);
                            keyBindingSO.keyBindingCheck[i].keyCode = keyCode;
                            // Debug.Log(keyBindingSO.keyBindingCheck[i].keyCode);
                            IsDoingRebinding = false;
                            OptionsUI.Instance.HidePressToRebindKey();
                            
                            // OptionsUI.Instance.OptionsUpdateVisualUI();
                            OnRebinding?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    }
                
                }
            }
        }
    }

    public KeyCode GetKeyBinding(KeyBinding keyBinding){
        foreach(KeyBindingScriptableObject.KeyBindingCheck keyBindingCheck in keyBindingSO.keyBindingCheck){
            if(keyBindingCheck.keyBinding == keyBinding){
                return keyBindingCheck.keyCode;
            }
        }
        return KeyCode.None;
    }
    public bool GetKeyCode(KeyBinding key){
        foreach(KeyBindingScriptableObject.KeyBindingCheck keyBindingCheck in keyBindingSO.keyBindingCheck){
            if(keyBindingCheck.keyBinding == key){
                return Input.GetKey(keyBindingCheck.keyCode);
            }
        }
        return false;
    }
    public bool GetKeyCodeDown(KeyBinding key){
        foreach(KeyBindingScriptableObject.KeyBindingCheck keyBindingCheck in keyBindingSO.keyBindingCheck){
            if(keyBindingCheck.keyBinding == key){
                return Input.GetKeyDown(keyBindingCheck.keyCode);
            }
        }
        return false;
    }
    public void RebindBinding(KeyBinding key){
        // Debug.Log(keyBindingCheck.keyCode);
        IsDoingRebinding = true;
        rebindingKey = key;
        OptionsUI.Instance.ShowPressToRebindKey();
    }

    // private void OnGUI() {
        
    // }
}
