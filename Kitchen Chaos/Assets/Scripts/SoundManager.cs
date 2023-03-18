using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    public static SoundManager Instance {get; private set;}
    private const string PLAYER_PREFS_SOUND_VOL = "SoundVolume";

    [SerializeField]private AudioClipScriptableObject audioClipSO;
    // [SerializeField]private CuttingCControllerInteraction cuttingCounter;

    private float volume = 0.1f;
    private void Awake() {
        Instance = this;
        
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOL, 0.1f);
    }
    private void Start() {
        DeliveryManager.Instance.OnPesananBerhasil += DeliveryManager_OnPesananBerhasil;
        DeliveryManager.Instance.OnPesananGagal += DeliveryManager_OnPesananGagal;

        CuttingCControllerInteraction.OnAnyCutSound += CuttingCounter_OnAnyCutSound;

        PlayerControllerInteraction.Instance.OnPickedObjSound += Player_OnPickedObjSound;

        BaseCounter.OnPlaceObjSound += BaseCounter_OnPlaceObjSound;

        TrashCCountrollerInteraction.OnTrashObjSound += TrashCounter_OnTrashObjSound;
    }

    private void TrashCounter_OnTrashObjSound(object sender, System.EventArgs e){
        TrashCCountrollerInteraction trashCounter = sender as TrashCCountrollerInteraction;
        PlaySound(audioClipSO.trash, trashCounter.transform.position);
    }
    private void BaseCounter_OnPlaceObjSound(object sender, System.EventArgs e){
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipSO.objDrop, baseCounter.transform.position);
    }

    private void Player_OnPickedObjSound(object sender, System.EventArgs e){
        PlaySound(audioClipSO.objPickUp, PlayerControllerInteraction.Instance.transform.position);
    }
    private void CuttingCounter_OnAnyCutSound(object sender, System.EventArgs e){
        CuttingCControllerInteraction cuttingCounter = sender as CuttingCControllerInteraction;
        PlaySound(audioClipSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnPesananBerhasil(object sender, System.EventArgs e){
        DeliveryCControllerInteraction deliveryCounter = DeliveryCControllerInteraction.Instance;
        PlaySound(audioClipSO.deliverySuccess, deliveryCounter.transform.position);
    }
    private void DeliveryManager_OnPesananGagal(object sender, System.EventArgs e){
        DeliveryCControllerInteraction deliveryCounter = DeliveryCControllerInteraction.Instance;
        PlaySound(audioClipSO.deliveryFail,deliveryCounter.transform.position);
    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f){
        PlaySound(audioClipArray[Random.Range(0,audioClipArray.Length)],position,volume);
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f){
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    //for player only
    public void PlayerFootStep(Vector3 position, float volumeMultiplier = 1f){
        PlaySound(audioClipSO.footstep,position, volume);
    }
    public void CountDownSound(){
        PlaySound(audioClipSO.warning,Vector3.zero);
    }
    public void PlayWarningSound(Vector3 position){
        PlaySound(audioClipSO.warning,position);
    }

    public void ChangeVoSoundEffect(){
        volume += 0.1f;
        if(volume > 1f){
            volume = 0f;
        }
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOL, volume);

    }

    public float GetVolume(){
        return volume;
    }
    
}
