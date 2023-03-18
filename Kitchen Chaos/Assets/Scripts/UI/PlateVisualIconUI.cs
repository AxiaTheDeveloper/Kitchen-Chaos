using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateVisualIconUI : MonoBehaviour
{
    [SerializeField]private PlateKitchenObj plateKitchenObj;
    [SerializeField]private Transform iconUITemplate;

    private void Awake() {
        iconUITemplate.gameObject.SetActive(false);
    }
    private void Start() {
        plateKitchenObj.OnIngredientAdded += plateKitchenObj_OnIngredientAdded;
    }
    private void plateKitchenObj_OnIngredientAdded(object sender, PlateKitchenObj.OnIngredientAddedEventArgs e){
        UpdateVisualIcon();
    }

    private void UpdateVisualIcon(){
        //cr dr list kitchenObj yg ada di plate
        foreach (Transform child in transform){
            if(!(child == iconUITemplate)) Destroy(child.gameObject);
        }
        foreach (KitchenScriptableObject kitchenObjSO in plateKitchenObj.GetKitchenObjSOList()){
            Transform iconTransform = Instantiate(iconUITemplate, transform); // transform jd child ke parent (plate)
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<SinglePlateVisualIconUI>().SetKitchenObjectSO(kitchenObjSO);
        }
    }
}
