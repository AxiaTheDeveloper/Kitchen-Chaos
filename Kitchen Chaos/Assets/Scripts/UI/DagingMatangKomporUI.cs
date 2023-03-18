using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagingMatangKomporUI : MonoBehaviour
{
    [SerializeField]private StoveCControllerInteraction stoveCounter;

    private void Start() {
        stoveCounter.OnProgressChanged += stoveCounter_OnProgressChanged;
        Hide();
    }
    private void stoveCounter_OnProgressChanged(object sender, IObjectHasProgress.OnProgressChangedEventArgs e){
        float hampirGosong = 0.5f;
        if(e.progressNormalized >= hampirGosong && stoveCounter.IsJadi() ){
            Show();
        }
        else{
            Hide();
        }
        
    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
