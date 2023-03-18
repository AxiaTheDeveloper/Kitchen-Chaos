using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DeliveryResultUI : MonoBehaviour
{
    public event EventHandler OnDelivery;
    [SerializeField]private Image bg;
    [SerializeField]private Image icon;
    [SerializeField]private TextMeshProUGUI msg;
    [SerializeField]private Color berhasilColor;
    [SerializeField]private Color gagalColor;
    [SerializeField]private Sprite berhasilSprite;
    [SerializeField]private Sprite gagalSprite;


    private void Start() {
        DeliveryManager.Instance.OnPesananBerhasil += DeliveryManager_OnPesananBerhasil;
        DeliveryManager.Instance.OnPesananGagal += DeliveryManager_OnPesananGagal;
        Hide();
    }

    private void DeliveryManager_OnPesananBerhasil(object sender, System.EventArgs e){
        Show();
        bg.color = berhasilColor;
        icon.sprite = berhasilSprite;
        msg.text = "DELIVERY\nBERHASIL";
        // Debug.Log("TestB");
        OnDelivery?.Invoke(this, EventArgs.Empty);
    }
    private void DeliveryManager_OnPesananGagal(object sender, System.EventArgs e){
        Show();
        bg.color = gagalColor;
        icon.sprite = gagalSprite;
        msg.text = "DELIVERY\nGAGAL";
        // Debug.Log("TestG");
        OnDelivery?.Invoke(this, EventArgs.Empty);
    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
