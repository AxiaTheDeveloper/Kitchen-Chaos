using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField]private GameObject hasProgressGameObj;
    [SerializeField]private Image bar;
    private IObjectHasProgress hasProgress;
    private void Start() {
        hasProgress = hasProgressGameObj.GetComponent<IObjectHasProgress>();
        hasProgress.OnProgressChanged += hasProgress_OnProgressChanged;
        bar.fillAmount = 0f;
        hilang();
    }
    private void hasProgress_OnProgressChanged(object sender, IObjectHasProgress.OnProgressChangedEventArgs e){
        
        bar.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 0f || e.progressNormalized == 1f){
            hilang();
        }
        else{
            muncul();
            if(e.progressNormalized >= 0.6f){
                bar.color = new Color32(116,255,47,255);
            }
            else if(e.progressNormalized >= 0.3f){
                bar.color = new Color32(238,255,47,255);
            }
            else{
                bar.color = new Color32(255,169,47,255);
            }
        }
    }

    private void muncul(){
        gameObject.SetActive(true);
    }
    private void hilang(){
        gameObject.SetActive(false);
    }
}
