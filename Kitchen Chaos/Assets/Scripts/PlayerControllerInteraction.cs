using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//another srp - ngatur interaction karakter player dgn segala objek
public class PlayerControllerInteraction : MonoBehaviour
{
    public static PlayerControllerInteraction Instance {get; private set;}
    private Vector2 keyInput = new Vector2(0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    private Vector3 arahPerpindahanTerakhir;

    [SerializeField]private float jarakInteraksi;


    //ambil input dari inputkey dari GameInput
    [SerializeField]private GameInput inputKey;

    [SerializeField]private LayerMask listObjekBisaInteract;

    private CounterControllerInteraction counterTerpilih;


    //Event Interact
    public event EventHandler OnInteractAct;
    public event EventHandler<OnSelectedCounterEventArgs> OnSelectedCounter;
    public class OnSelectedCounterEventArgs : EventArgs{
        public CounterControllerInteraction counterTerpilih;
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        OnInteractAct += InteraksiController_OnInteractAct;

    }


    private void Update()
    {
        InteraksiController();
        if(inputKey.GetInputInteract()){
            OnInteractAct?.Invoke(this, EventArgs.Empty);
        }
    }



    private void InteraksiController_OnInteractAct(object sender, System.EventArgs e){
        // counterTerpilih.interactWithCounter();
        if(counterTerpilih){
            counterTerpilih.interactCounter();
        }
        // Debug.Log(counterTerpilih.transform);
    }

    private void InteraksiController(){
        keyInput = (inputKey.GetInputGerakkanNormalized());
        arahPerpindahan.Set(keyInput.x, 0f, keyInput.y);

        if(arahPerpindahan != Vector3.zero){
            arahPerpindahanTerakhir = arahPerpindahan;
        }
        // Debug.Log("yak" + arahPerpindahanTerakhir);

        if(Physics.Raycast(transform.position, arahPerpindahanTerakhir, out RaycastHit cekObjek, jarakInteraksi)){
            if(cekObjek.transform.TryGetComponent(out CounterControllerInteraction counters)){
                if(counters != counterTerpilih){
                    selectedCounterEvent(counters);
                    // counterTerpilih.interactWithCounter();
                }
                
            }
            else{
                selectedCounterEvent(null);
            }
        }
        else{
            selectedCounterEvent(null);
        }

        // Debug.DrawRay(transform.position, Vector3.forward, Color.green);
    }

    private void selectedCounterEvent(CounterControllerInteraction counterTerpilih){
        this.counterTerpilih = counterTerpilih; 
        OnSelectedCounter?.Invoke(this, new OnSelectedCounterEventArgs{
            counterTerpilih = counterTerpilih
        });
    }
}
