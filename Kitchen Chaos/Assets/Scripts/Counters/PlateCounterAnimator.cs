using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterAnimator : MonoBehaviour
{
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private Transform plateVisuaONLYPrefab;

    [SerializeField]private PlateCControllerInteraction plateCounter;

    private List<GameObject> plateVisualGameObjList;

    private void Awake() {
        plateVisualGameObjList = new List<GameObject>();
    }
    private void Start() {
        plateCounter.OnPlateSpawned += plateC_OnPlateSpawned;
        plateCounter.OnPlateRemoved += plateC_OnPlateRemoved;
    }

    private void plateC_OnPlateSpawned(object sender, System.EventArgs e){
        Transform plateVisualTransform = Instantiate(plateVisuaONLYPrefab, spawnPoint);

        float plateYPosition = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0,plateYPosition * plateVisualGameObjList.Count,0);

        plateVisualGameObjList.Add(plateVisualTransform.gameObject);
    }
    private void plateC_OnPlateRemoved(object sender, System.EventArgs e){
        GameObject plateGameObj = plateVisualGameObjList[plateVisualGameObjList.Count - 1];
        plateVisualGameObjList.Remove(plateGameObj);
        Destroy(plateGameObj);
    }
}
