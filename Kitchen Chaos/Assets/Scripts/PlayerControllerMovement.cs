using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SRP -> ngatur gerakan karakter player
public class PlayerControllerMovement : MonoBehaviour
{
    
    private Vector2 keyInput = new Vector2(0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    [SerializeField]private float kecepatanPerpindahan;

    //ambil input dari inputkey dari GameInput
    [SerializeField]private GameInput inputKey;

    //ambil bisa gerak ga biar ga nembus dinding dr PlayerControllerCollision
    [SerializeField]private PlayerControllerCollision collis;
    private bool bisaGerak;

    //Untuk Animasi - PlayerAnimator
    private bool isJalan;


    private void Update()
    {
        GerakKarakter();

        // Debug.Log(getIsJalan());
    }

    private void GerakKarakter(){
         
        keyInput = (inputKey.GetInputGerakkanNormalized());
        arahPerpindahan.Set(keyInput.x, 0f, keyInput.y);
        isJalan = (arahPerpindahan != Vector3.zero);
        //colliderrrrrrr
        
        bisaGerak = collis.GetBisaGerak(arahPerpindahan);
        if(!bisaGerak){
            //gabisa maju karena ada dinding

            //coba gerak ke kiri kanan
            Vector3 arahPerpindahanHorizontal = new Vector3(arahPerpindahan.x, 0f, 0f).normalized;
            bisaGerak = collis.GetBisaGerak(arahPerpindahanHorizontal);
            if(bisaGerak){
                arahPerpindahan = arahPerpindahanHorizontal;
            }
            else{
                //coba gerak atas bawah 
                Vector3 arahPerpindahanVertikal = new Vector3(0f, 0f, arahPerpindahan.z).normalized;
                bisaGerak = collis.GetBisaGerak(arahPerpindahanVertikal);
                if(bisaGerak){{
                    arahPerpindahan = arahPerpindahanVertikal;
                }}
            }
        }
        if(bisaGerak){
            transform.position += (arahPerpindahan * kecepatanPerpindahan * Time.deltaTime);
        }
        
        
    }
    

    public bool GetIsJalan(){
        return isJalan;
    }
    public Vector3 GetArahPerpindahan(){
        return arahPerpindahan;
    }
    public float GetJarakPindah(){
        return kecepatanPerpindahan * Time.deltaTime;
    }

}
