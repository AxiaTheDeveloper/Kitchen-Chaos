using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class KeyBindingScriptableObject : ScriptableObject
{
    [Serializable]
    public class KeyBindingCheck{
        public KeyGameInputManager.KeyBinding keyBinding;
        public KeyCode keyCode;
    }
    public KeyBindingCheck[] keyBindingCheck;
}
