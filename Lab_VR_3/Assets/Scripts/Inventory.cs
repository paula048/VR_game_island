using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static int charge = 0;
    public AudioClip collectSound;

    // zapałki
    bool haveMatches = false;
    bool isFire = false;                //-------  added by me
    public RawImage matchHudGUI ;

    public Text textHints;          // img zapałki
    

    

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


    // znaleziono zapałki ?

    void MatchPickup(){
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        matchHudGUI.enabled = true;
    }


    void OnControllerColliderHit(ControllerColliderHit col){
        if (col.gameObject.name == "campfire"){
            if(haveMatches){
                LightFire(col.gameObject);
            } else if(!isFire){
                textHints.SendMessage("ShowHint", "Mógłbym rozpalić ognisko do wezwania pomocy.\nTylko czym...");
            }
        }
    }

    void LightFire(GameObject campfire){
        
        ParticleSystem[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();

        foreach(ParticleSystem emitter in fireEmitters){
            emitter.Play();
        }
        campfire.GetComponent<AudioSource>().Play();

        isFire = true;
        matchHudGUI.enabled=false;
        haveMatches=false;
        
        
    }



    


}
