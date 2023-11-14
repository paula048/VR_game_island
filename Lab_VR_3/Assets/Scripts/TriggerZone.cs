using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip lockedSound;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            if(Inventory.charge == 4){
                transform.Find("door").SendMessage("DoorCheck");
            }
            else{
                transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
                col.gameObject.SendMessage("HUDon");
            }
        }
    }
}
