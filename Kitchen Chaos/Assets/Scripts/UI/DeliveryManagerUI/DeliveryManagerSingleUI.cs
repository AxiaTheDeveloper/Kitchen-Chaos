using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//control UI dari per pesanan di deliverymanagerUI
public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI namaPesanan_Text;
    [SerializeField]private Transform iconKOContainer;
    [SerializeField]private Transform iconKOTemplate;

    private void Awake() {
        iconKOTemplate.gameObject.SetActive(false);
    }

    public void SetNamaPesananSO(PesananPembeliScriptableObject pesananSO){
        namaPesanan_Text.text = pesananSO.namaPesanan;
        foreach(Transform child in iconKOContainer){
            if(!(child == iconKOTemplate)) Destroy(child.gameObject);
        }
        foreach(KitchenScriptableObject kitchenObjSO in pesananSO.kitchenObjSOList){
            Transform kitchenObjTransform = Instantiate(iconKOTemplate, iconKOContainer);
            kitchenObjTransform.gameObject.SetActive(true);
            kitchenObjTransform.GetComponent<Image>().sprite = kitchenObjSO.sprite;
        }
    }
}
