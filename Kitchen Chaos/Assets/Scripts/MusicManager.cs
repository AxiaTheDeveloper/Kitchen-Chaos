using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get; private set;}
    private const string PLAYER_PREFS_MUSIC_VOL = "MusicVolume";
    private float volume = 0.3f;
    private AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOL, 0.3f);
        audioSource.volume = volume;
    }
    public void ChangeVoSoundEffect(){
        volume += 0.1f;
        if(volume > 1f){
            volume = 0f;
        }
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOL, volume);
    }

    public float GetVolume(){
        return volume;
    }
}
