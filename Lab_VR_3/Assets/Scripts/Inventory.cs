using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static int charge = 0;
    public AudioClip collectSound;
  
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CellPickup(){
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
    }


}