using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjParent
{
    public Transform GetKitchenObjectNewPlace();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    //bersihin kitchen object lama
    public void ClearKitchenObject();
    public bool HasKitchenObject();
}
