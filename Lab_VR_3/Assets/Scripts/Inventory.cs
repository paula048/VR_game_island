using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static int charge = 0;
    public AudioClip collectSound;

    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;

  
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CellPickup(){      // zerbranie ogniw
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        chargeHudGUI.texture = hudCharge[charge];
        HUDon();
    }


    void HUDon(){
        if(!chargeHudGUI.enabled){
            chargeHudGUI.enabled = true;
        }
    }


}
