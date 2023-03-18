using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoveCControllerInteraction : BaseCounter, IObjectHasProgress
{

    //event time
    public event EventHandler<IObjectHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs{
        public StateKompor state;
    }

    [SerializeField]private resepMasakScriptableObject[] resepMasakSOArray;
    [SerializeField]private resepGosongScriptableObject[] resepGosongSOArray;
    public enum StateKompor{
        Idle, Memasak, Jadi, Gosong
    }

    resepMasakScriptableObject resepMasakSO;
    private float masakTimerJadi = 0;

    resepGosongScriptableObject resepGosongSO;
    private float masakTimerGosong = 0;

    private StateKompor state;

    private void Start() {
        state = StateKompor.Idle;
    }
    private void Update() {
        if(HasKitchenObject()){
            // 
            if(state == StateKompor.Memasak){
                masakTimerJadi += Time.deltaTime;

                OnProgressChanged?.Invoke(this, new IObjectHasProgress.OnProgressChangedEventArgs{progressNormalized = (float)masakTimerJadi / resepMasakSO.durasiMasak});

                if(masakTimerJadi >= resepMasakSO.durasiMasak){
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObj(resepMasakSO.hasilJadi, this);

                    state = StateKompor.Jadi;
                    masakTimerGosong = 0f;
                    resepGosongSO = GetResepGosongSO(GetKitchenObject().GetKitchenObjectSO());

                    eventEffect();
                }
            }
            else if(state == StateKompor.Jadi){
                masakTimerGosong += Time.deltaTime;

                OnProgressChanged?.Invoke(this, new IObjectHasProgress.OnProgressChangedEventArgs{progressNormalized = (float)masakTimerGosong / resepGosongSO.durasiMasakGosong});

                if(masakTimerGosong >= resepGosongSO.durasiMasakGosong){
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObj(resepGosongSO.hasilGosong, this);

                    state = StateKompor.Gosong;
                    eventEffect();

                    OnProgressChanged?.Invoke(this, new IObjectHasProgress.OnProgressChangedEventArgs{progressNormalized = 0f});
                }
            }
            
        }
    }
    public override void InteractCounter(PlayerControllerInteraction player){
         if(!HasKitchenObject()){
            if(player.HasKitchenObject()){
                if(CekAdaResep(player.GetKitchenObject().GetKitchenObjectSO())){
                    
                    player.GetKitchenObject().SetParent(this);
                    resepMasakSO = GetResepMasakSO(GetKitchenObject().GetKitchenObjectSO()); 

                    state = StateKompor.Memasak;
                    masakTimerJadi = 0f;
                    eventEffect();

                    OnProgressChanged?.Invoke(this, new IObjectHasProgress.OnProgressChangedEventArgs{progressNormalized = (float)masakTimerJadi / resepMasakSO.durasiMasak});
                }
                
                
            }
            
        }
        else{
            // Debug.Log(GetKitchenObject().transform);
            if(!player.HasKitchenObject()){
                GetKitchenObject().SetParent(player);
                state = StateKompor.Idle;
                // masakTimerJadi = 0f;
                eventEffect();

                OnProgressChanged?.Invoke(this, new IObjectHasProgress.OnProgressChangedEventArgs{progressNormalized = 0f});
            }
            else{
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
                    if(plateKitchenObj.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())){
                        GetKitchenObject().DestroySelf();
                        state = StateKompor.Idle;
                        // masakTimerJadi = 0f;
                        eventEffect();

                        OnProgressChanged?.Invoke(this, new IObjectHasProgress.OnProgressChangedEventArgs{progressNormalized = 0f});
                    }
                    
                }
            }
            
        }
    }





    private bool CekAdaResep(KitchenScriptableObject bahanKitchenObjSO){
        resepMasakScriptableObject resep = GetResepMasakSO(bahanKitchenObjSO);
        return resep != null;
    }

    private KitchenScriptableObject GetHasilPotong(KitchenScriptableObject bahanKitchenObjSO){
        resepMasakScriptableObject resep = GetResepMasakSO(bahanKitchenObjSO);
        if(resep) return resep.hasilJadi;
        return null;
    }

    private resepMasakScriptableObject GetResepMasakSO (KitchenScriptableObject bahanKitchenObjSO){
        foreach (resepMasakScriptableObject resep in resepMasakSOArray){
            // Debug.Log(kitchenObjSO.objName);
            if(bahanKitchenObjSO == resep.bahan){
                //  Debug.Log("1" + resep.hasilPotong.objName);
                return resep;
            }
        }
        return null;
    }

    private resepGosongScriptableObject GetResepGosongSO (KitchenScriptableObject bahanKitchenObjSO){
        foreach (resepGosongScriptableObject resep in resepGosongSOArray){
            // Debug.Log(kitchenObjSO.objName);
            if(bahanKitchenObjSO == resep.hasilJadi){
                //  Debug.Log("1" + resep.hasilPotong.objName);
                return resep;
            }
        }
        return null;
    }

    private void eventEffect(){
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{state = state});
    }

    public bool IsJadi(){
        return state == StateKompor.Jadi;
    }
}
