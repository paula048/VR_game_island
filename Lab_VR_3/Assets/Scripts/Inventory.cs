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

    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;

  
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
        meter.material.mainTexture = meterCharge[charge];
    }


    void HUDon(){
        if(!chargeHudGUI.enabled){
            chargeHudGUI.enabled = true;
        }
    }


    


}
