using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]       // Audio Source zostanie utworzone w obiekcie, do którego przypisany zostanie te skrypt

public class TargetCollision : MonoBehaviour
{


    bool beenHit = false;       //cel został trafiony?
    Animation targetRoot;       //zmienna prywatna,
    public AudioClip hitSound;
    public AudioClip resetSound;
    public float resetTime = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision theObject) {                        // czy obiekt trafiony kokosem
        if(beenHit==false && theObject.gameObject.name=="coconut"){
            StartCoroutine("targetHit");

        }
    }



    IEnumerator targetHit() {
        GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetRoot.Play("down");
        beenHit=true;
        CoconutWin.targets++;
        yield return new WaitForSeconds(resetTime);
        GetComponent<AudioSource>().PlayOneShot(resetSound);
        targetRoot.Play("up");
        beenHit=false;
        CoconutWin.targets--;
    }




}
