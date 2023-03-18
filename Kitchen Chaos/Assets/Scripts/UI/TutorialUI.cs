using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI moveUp_Text;
    [SerializeField]private TextMeshProUGUI moveDown_Text;
    [SerializeField]private TextMeshProUGUI moveLeft_Text;
    [SerializeField]private TextMeshProUGUI moveRight_Text;
    [SerializeField]private TextMeshProUGUI interact_Text;
    [SerializeField]private TextMeshProUGUI interactLain_Text;
    [SerializeField]private TextMeshProUGUI pause_Text;
    KeyGameInputManager keyGameInputManager;

    private void Start() {
        TutorialUpdateVisualUI();
        keyGameInputManager.OnRebinding += KeyGameInputManager_OnRebinding;
        Show();
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChange;
    }
    private void KitchenGameManager_OnStateChange(object sender, System.EventArgs e){
        if(KitchenGameManager.Instance.IsCountDownToStart()){
            Hide();
        }
        
    }
    private void KeyGameInputManager_OnRebinding(object sender, System.EventArgs e){
        TutorialUpdateVisualUI();
    }

    private void TutorialUpdateVisualUI(){
        keyGameInputManager = KeyGameInputManager.Instance;
        moveUp_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveUp).ToString();
        moveDown_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveDown).ToString();
        moveLeft_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveLeft).ToString();
        moveRight_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveRight).ToString();
        interact_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.interact).ToString();
        interactLain_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.interactLain).ToString();
        pause_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.Pause).ToString();
    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
