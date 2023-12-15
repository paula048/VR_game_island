using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           // lab 9


public class ThrowTrigger : MonoBehaviour           // panel, obszar w którym aktywuje się : f. rzucania kosa i włącza się celownik
{

    public RawImage crosshair;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            CoconutThrower.canThrow=true;
            crosshair.enabled=true;

        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player") {
            CoconutThrower.canThrow=false;
            crosshair.enabled=false;
        }
    }
}
