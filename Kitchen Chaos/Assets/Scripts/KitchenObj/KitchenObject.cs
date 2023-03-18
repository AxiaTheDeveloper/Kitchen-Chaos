using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//utk kshtau ini object apa dan sedang ada di mana objeknya (identitas) 
public class KitchenObject : MonoBehaviour
{
    [SerializeField]private KitchenScriptableObject kitchenObjectSO;

    private IKitchenObjParent kitchenObjParent;
    public KitchenScriptableObject GetKitchenObjectSO(){
        return kitchenObjectSO;
    }

    //set kitchen object ada d mana
    public void SetParent(IKitchenObjParent kitchenObjParent){
        //hapus lama
        if(this.kitchenObjParent != null) this.kitchenObjParent.ClearKitchenObject();

        //ganti baru
        this.kitchenObjParent = kitchenObjParent;
        // if(kitchenObjParent.HasKitchenObject()){
        //     // Debug.Log(kitchenObjParent.transform);
        //     // Debug.Log(kitchenObjParent.GetKitchenObject().transform);
        //     Debug.LogError("error");
        // }

        kitchenObjParent.SetKitchenObject(this);
        


        //updet visual
        transform.parent = kitchenObjParent.GetKitchenObjectNewPlace();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjParent GetParent(){
        return kitchenObjParent;
    }

    public void DestroySelf(){
        kitchenObjParent.ClearKitchenObject();
        Destroy(gameObject);
    }


    public bool TryGetPlate(out PlateKitchenObj plateKitchenObj){
        if(this is PlateKitchenObj){
            plateKitchenObj = this as PlateKitchenObj;
            return true;
        }
        else{
            plateKitchenObj = null;
            return false;
        }
    }
    
    public static KitchenObject SpawnKitchenObj(KitchenScriptableObject kitchenObjSO, IKitchenObjParent objParent){
        Transform kitchenObjSpawn = Instantiate(kitchenObjSO.prefabObj);
        KitchenObject kitchenObj = kitchenObjSpawn.GetComponent<KitchenObject>();
        kitchenObj.SetParent(objParent);

        return kitchenObj;
    }
}
