using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryManager : MonoBehaviour
{
    //event
    public event EventHandler OnPesananDipesan;
    public event EventHandler OnPesananDikirimBenar;
    //event utk nyalain audio/sound effect
    public event EventHandler OnPesananBerhasil;
    public event EventHandler OnPesananGagal;
    public static DeliveryManager Instance {get; private set;}
    [SerializeField]private ListPesananScriptableObject listPesananSO;
    private List<PesananPembeliScriptableObject> pesananPembeliSOList;

    private float lamaPesananKeluar;
    [SerializeField]private float totalLamaPesananKeluar;

    [SerializeField]private int totalPesananPembeli = 0;

    private int totalPesananBerhasilDikirim;

    private void Awake() {
        Instance = this;

        pesananPembeliSOList = new List<PesananPembeliScriptableObject>();
    }

    private void Update() {
        lamaPesananKeluar -= Time.deltaTime;
        if(lamaPesananKeluar <= 0f){
            lamaPesananKeluar = totalLamaPesananKeluar;


            if(pesananPembeliSOList.Count < totalPesananPembeli){
                if(!KitchenGameManager.Instance.IsGameStart()) return;
                PesananPembeliScriptableObject pesananPembeliSO = listPesananSO.pesananSOList[(UnityEngine.Random.Range(0, listPesananSO.pesananSOList.Count))];

                Debug.Log(pesananPembeliSO.namaPesanan);

                pesananPembeliSOList.Add(pesananPembeliSO);

                OnPesananDipesan?.Invoke(this, EventArgs.Empty);
            }
            
        }
    }

    public void KirimPesanan(PlateKitchenObj plateKitchenObj){
        for(int i=0; i<pesananPembeliSOList.Count; i++){
            PesananPembeliScriptableObject pesananPembeliSO = pesananPembeliSOList[i];

            if(pesananPembeliSO.kitchenObjSOList.Count == plateKitchenObj.GetKitchenObjSOList().Count){
                bool pesananSamaDenganKiriman = true;
                foreach(KitchenScriptableObject pesananKitchenObjSO in pesananPembeliSO.kitchenObjSOList){
                    bool adaKitchenObjSO = false; 
                    foreach(KitchenScriptableObject inPlateKitchenObjSO in plateKitchenObj.GetKitchenObjSOList()){
                        if(pesananKitchenObjSO == inPlateKitchenObjSO){
                            adaKitchenObjSO = true;
                            break;
                        }
                    }
                    if(!adaKitchenObjSO){
                        pesananSamaDenganKiriman = false;
                    }
                }
                if(pesananSamaDenganKiriman){
                    // Debug.Log("Benar");
                    totalPesananBerhasilDikirim++;
                    pesananPembeliSOList.RemoveAt(i);
                    OnPesananDikirimBenar?.Invoke(this, EventArgs.Empty);

                    OnPesananBerhasil?.Invoke(this, EventArgs.Empty);
                    return;
                    
                }
                // else{
                //     Debug.Log("Salah");
                // }
            }
        }
        //ga ada yg ketemu, player salah kirim
        OnPesananGagal?.Invoke(this, EventArgs.Empty);
    }

    public List<PesananPembeliScriptableObject> GetPesananPembeliSOList(){
        return pesananPembeliSOList;
    }
    public int GetTotalPesananBerhasilDikirim(){
        return totalPesananBerhasilDikirim;
    }

    
}
