using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (AudioSource))]

public class CoconutThrower : MonoBehaviour
{

    public AudioClip throwSound;
    public Rigidbody coconutPrefab;                 // prefabr kokosu, 
                                                    // dany konretny typ, dzieki czemu nie trzeba odwołąć się do   GetComponent() ...
    public float throwSpeed = 30.0f;
    public static bool canThrow = false;        






    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
            if(Input.GetButtonUp("Fire1") && canThrow){
                GetComponent<AudioSource>().PlayOneShot(throwSound);
                Rigidbody newCoconut = Instantiate(coconutPrefab, transform.position, transform.rotation) as Rigidbody;
                newCoconut.name = "coconut";            // bez tego Unity domy slnie daje nazwe Clone (bo ... Instantiate)
                newCoconut.velocity = throwSpeed * transform.forward;       // predkosć = szybkosć * kierunek
            }
            

            //Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newCoconut.GetComponent<Collider>(), true);    // ignorowanie kolizji

            


        
    }
}
