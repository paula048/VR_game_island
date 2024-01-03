using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



[RequireComponent (typeof (AudioSource))]


public class MainMenuBtns : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string levelToLoad;
    public Sprite normalTexture;
    public Sprite rollOverTexture;
    public AudioClip beep;


    public bool quitButton = false;     // przełacznik






    // Update is called once per frame
    void Update()
    {
        
    }

    //funkcję, która zdefiniuje teksturę używaną przez komponent UI w momencie, gdy kursor myszy pojawi się w jej obszarze
    public void OnPointerEnter(PointerEventData eventData) {
        GetComponent<Image>().sprite = rollOverTexture;
    }


    // Aby wykryć sytuację, gdy kursor myszy znika z obszaru tekstury

    public void OnPointerExit(PointerEventData eventData){
        GetComponent<Image>().sprite = normalTexture;
    }


    public void OnPointerUp(PointerEventData eventData) {
        
        if (quitButton) {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        else {
            GetComponent<AudioSource>().PlayOneShot(beep);
            SceneManager.LoadScene(levelToLoad);
        }
}


    



    // ważne:  Trzeba dołączyć pustą obsługę zdarzenia PointerDown, gdyż bez tego nie pojawi się zdarzenie PointerUp
    public void OnPointerDown(PointerEventData eventData) {
    }
}
