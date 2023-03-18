using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateCControllerInteraction : BaseCounter
{
    //event
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    [SerializeField]private KitchenScriptableObject plateSO;
    private float timerPlateSpawn;
    [SerializeField]private float lamaPlateSpawn;

    private int totalPlateNow;
    [SerializeField]private int totalPlate;

    private void Update() {
        timerPlateSpawn += Time.deltaTime;
        if(timerPlateSpawn >= lamaPlateSpawn){
            timerPlateSpawn = 0f;
            if(totalPlateNow < totalPlate){
                totalPlateNow++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public override void InteractCounter(PlayerControllerInteraction player){
        if(!player.HasKitchenObject()){
            if(totalPlateNow > 0){
                KitchenObject.SpawnKitchenObj(plateSO, player);
                totalPlateNow--;
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
