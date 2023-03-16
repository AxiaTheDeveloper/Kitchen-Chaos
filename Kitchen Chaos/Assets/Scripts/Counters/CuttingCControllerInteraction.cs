using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCControllerInteraction : BaseCounter
{
    //event utk bar
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs{
        public float progressNormalized;
    }
    //event animasi
    public event EventHandler OnPlayerCutObj;
    
    [SerializeField]private resepPotongScriptableObject[] resepPotonganSOArray; 
    resepPotongScriptableObject resepPotongSO;
    private int banyakProgessPotong = 0;
    public override void InteractCounter(PlayerControllerInteraction player){
        if(!HasKitchenObject()){
            if(player.HasKitchenObject()){
                if(CekAdaResep(player.GetKitchenObject().GetKitchenObjectSO())){
                    banyakProgessPotong = 0;
                    
                    player.GetKitchenObject().SetParent(this);
                    
                    resepPotongSO = GetResepPotongSO(GetKitchenObject().GetKitchenObjectSO());
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{progressNormalized = (float)banyakProgessPotong / resepPotongSO.totalPotongan});
                }
                
                
            }
            
        }
        else{
            // Debug.Log(GetKitchenObject().transform);
            if(!player.HasKitchenObject()){
                GetKitchenObject().SetParent(player);
                banyakProgessPotong = 0;
            }
            
            
        }
    }

    public override void InteractCounterLain(PlayerControllerInteraction player){
        if(HasKitchenObject() && CekAdaResep(GetKitchenObject().GetKitchenObjectSO())){
            banyakProgessPotong++;
            
            // Debug.Log(banyakProgessPotong);
            resepPotongSO = GetResepPotongSO(GetKitchenObject().GetKitchenObjectSO());
            OnPlayerCutObj?.Invoke(this,EventArgs.Empty);

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{progressNormalized = (float)banyakProgessPotong / resepPotongSO.totalPotongan});

            if(banyakProgessPotong >= resepPotongSO.totalPotongan){
                KitchenScriptableObject hasilPotong = GetHasilPotong(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();
                
                KitchenObject.SpawnKitchenObj(hasilPotong, this);

                
            }
            
        }
    }
    private bool CekAdaResep(KitchenScriptableObject bahanKitchenObjSO){
        resepPotongScriptableObject resep = GetResepPotongSO(bahanKitchenObjSO);
        return resep != null;
    }

    private KitchenScriptableObject GetHasilPotong(KitchenScriptableObject bahanKitchenObjSO){
        resepPotongScriptableObject resep = GetResepPotongSO(bahanKitchenObjSO);
        if(resep) return resep.hasilPotong;
        return null;
    }

    private resepPotongScriptableObject GetResepPotongSO (KitchenScriptableObject bahanKitchenObjSO){
        foreach (resepPotongScriptableObject resep in resepPotonganSOArray){
            // Debug.Log(kitchenObjSO.objName);
            if(bahanKitchenObjSO == resep.bahan){
                //  Debug.Log("1" + resep.hasilPotong.objName);
                return resep;
            }
        }
        return null;
    }
}
