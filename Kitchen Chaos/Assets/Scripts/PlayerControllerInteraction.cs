using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//another srp - ngatur interaction karakter player dgn segala objek
public class PlayerControllerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 keyInput = new Vector2(0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    private Vector3 arahPerpindahanTerakhir;

    [SerializeField]private float jarakInteraksi;
    //ambil input dari inputkey dari GameInput
    [SerializeField]private GameInput inputKey;

    [SerializeField]private LayerMask listObjekBisaInteract;
    private void Update()
    {
        InteraksiController();
    }

    private void InteraksiController(){
        keyInput = (inputKey.GetInputGerakkanNormalized());
        arahPerpindahan.Set(keyInput.x, 0f, keyInput.y);

        if(arahPerpindahan != Vector3.zero){
            arahPerpindahanTerakhir = arahPerpindahan;
        }
        // Debug.Log("yak" + arahPerpindahanTerakhir);

        if(Physics.Raycast(transform.position, arahPerpindahanTerakhir, out RaycastHit cekObjek, jarakInteraksi)){
            if(cekObjek.transform.TryGetComponent(out ClearCounterControllerInteraction clearCounter)) clearCounter.test();
            // Debug.Log(cekObjek.transform);
        }

        // Debug.DrawRay(transform.position, Vector3.forward, Color.green);
  
    }
}
