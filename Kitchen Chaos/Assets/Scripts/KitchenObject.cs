using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//utk tau ini object apa dan sedang ada di mana objeknya (identitas)
public class KitchenObject : MonoBehaviour
{
    [SerializeField]private KitchenScriptableObject kitchenObject;

    private CounterControllerInteraction counter;
    public KitchenScriptableObject GetKitchenObject(){
        return kitchenObject;
    }

    public void SetCounter(CounterControllerInteraction counter){
        this.counter = counter;
        transform.parent = counter.GetKitchenObjectNewPlace();
        transform.localPosition = Vector3.zero;
    }

    public CounterControllerInteraction GetCounter(){
        return counter;
    }
}
