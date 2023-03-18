using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance {get; private set;}
    // [SerializeField]private KitchenGameManager kitchenGameManager;
    [SerializeField]private Button soundsEffectButton;
    [SerializeField]private Button musicButton;
    
    [SerializeField]private TextMeshProUGUI soundsEffect_Text;
    [SerializeField]private TextMeshProUGUI music_Text;

    [SerializeField]private Button closeOptionButton;


    //KeyBinding
    [SerializeField]private Button moveUpButton;
    [SerializeField]private Button moveDownButton;
    [SerializeField]private Button moveLeftButton;
    [SerializeField]private Button moveRightButton;
    [SerializeField]private Button interactButton;
    [SerializeField]private Button interactLainButton;
    [SerializeField]private Button pauseButton;

    [SerializeField]private TextMeshProUGUI moveUp_Text;
    [SerializeField]private TextMeshProUGUI moveDown_Text;
    [SerializeField]private TextMeshProUGUI moveLeft_Text;
    [SerializeField]private TextMeshProUGUI moveRight_Text;
    [SerializeField]private TextMeshProUGUI interact_Text;
    [SerializeField]private TextMeshProUGUI interactLain_Text;
    [SerializeField]private TextMeshProUGUI pause_Text;

    [SerializeField]private KeyGameInputManager keyGameInputManager;

    [SerializeField]private Transform pressToRebindKeyTransform;
    private void Awake(){
        Instance = this;
        // keyGameInputManager = KeyGameInputManager.Instance;
        soundsEffectButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVoSoundEffect();
            OptionsUpdateVisualUI();
        });
        musicButton.onClick.AddListener(() => {
            // SoundManager.Instance.ChangeVoSoundEffect();
            MusicManager.Instance.ChangeVoSoundEffect();
            OptionsUpdateVisualUI();
        });
        closeOptionButton.onClick.AddListener(() => {
            // SoundManager.Instance.ChangeVoSoundEffect();
            Hide();
        });

        moveUpButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.moveUp);
        });
        moveDownButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.moveDown);
        });
        moveLeftButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.moveLeft);
        });
        moveRightButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.moveRight);
        });
        interactButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.interact);
        });
        interactLainButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.interactLain);
        });
        pauseButton.onClick.AddListener(() => {
            keyGameInputManager.RebindBinding(KeyGameInputManager.KeyBinding.Pause);
        });
        
    }

    private void Start() {
        // kitchenGameManager = GetComponent<KitchenGameManager>();
        Debug.Log("Hi");
        KitchenGameManager.Instance.OnGameUnPause += KitchenGameManager_OnGameUnPause;
        Debug.Log("Hii");
        // KitchenGameManager.Instance
        keyGameInputManager.OnRebinding += KeyGameInputManager_OnRebinding;
        OptionsUpdateVisualUI();
        Hide();
        HidePressToRebindKey();
    }
    private void KitchenGameManager_OnGameUnPause(object sender, System.EventArgs e){
        Hide();
    }
    private void KeyGameInputManager_OnRebinding(object sender, System.EventArgs e){
        OptionsUpdateVisualUI();
    }
    private void OptionsUpdateVisualUI(){
        soundsEffect_Text.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        music_Text.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        keyGameInputManager = KeyGameInputManager.Instance;
        moveUp_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveUp).ToString();
        moveDown_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveDown).ToString();
        moveLeft_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveLeft).ToString();
        moveRight_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.moveRight).ToString();
        interact_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.interact).ToString();
        interactLain_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.interactLain).ToString();
        pause_Text.text = keyGameInputManager.GetKeyBinding(KeyGameInputManager.KeyBinding.Pause).ToString();
    }
    public void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
    public void ShowPressToRebindKey(){
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }
    public void HidePressToRebindKey(){
        pressToRebindKeyTransform.gameObject.SetActive(false);
        
    }
}
