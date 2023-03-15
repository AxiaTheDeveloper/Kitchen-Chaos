using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CounterControllerInteraction : MonoBehaviour
{

    [SerializeField]private KitchenScriptableObject kitchenObjectSO;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private CounterControllerInteraction differentCounter;
    private bool testing=true;
    private KitchenObject kitchenObject;

    private void Update() {
        if(testing && Input.GetKeyDown(KeyCode.T)){
            if(kitchenObject != null){
                kitchenObject.SetCounter(differentCounter);
            }
        }
    }

    
    public void interactCounter()
    {
        if(kitchenObject == null){
            Transform kitchenObjSpawn = Instantiate(kitchenObjectSO.prefabObj, spawnPoint);
            kitchenObjSpawn.localPosition = Vector3.zero;
            kitchenObject = kitchenObjSpawn.GetComponent<KitchenObject>();
            Debug.Log(kitchenObjSpawn.GetComponent<KitchenObject>().GetKitchenObject().objName);

            kitchenObject.SetCounter(this);
        }
        else{
            Debug.Log(kitchenObject.GetCounter());
        }



        

        
    }

    public Transform GetKitchenObjectNewPlace(){
        return spawnPoint;
    }
    // public void SetKitchenO



}
