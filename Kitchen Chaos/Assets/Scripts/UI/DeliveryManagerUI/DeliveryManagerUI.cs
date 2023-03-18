using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//full control delivery manager UI -> kasih pesanan dan lain sebagainya
public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField]private Transform pesananList;
    [SerializeField]private Transform pesananTemplate;

   

    private void Awake() {
        pesananTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        DeliveryManager.Instance.OnPesananDipesan += DeliveryManager_OnPesananDipesan;
        DeliveryManager.Instance.OnPesananDikirimBenar += DeliveryManager_OnPesananDikirimBenar;

        UpdateVisualPesanan();
    }
    
    private void DeliveryManager_OnPesananDipesan(object sender, System.EventArgs e){
        UpdateVisualPesanan();
    }

    private void DeliveryManager_OnPesananDikirimBenar(object sender, System.EventArgs e){
        UpdateVisualPesanan();
    }

    private void UpdateVisualPesanan(){
        foreach(Transform child in pesananList){
            if(!(child == pesananTemplate)) Destroy(child.gameObject);
        }
        foreach(PesananPembeliScriptableObject pesananSO in DeliveryManager.Instance.GetPesananPembeliSOList()){
            Transform pesananTransform = Instantiate(pesananTemplate, pesananList);
            pesananTransform.gameObject.SetActive(true);
            pesananTransform.GetComponent<DeliveryManagerSingleUI>().SetNamaPesananSO(pesananSO);
        }
    }
}
