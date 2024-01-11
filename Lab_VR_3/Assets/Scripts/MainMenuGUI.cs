using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[RequireComponent (typeof (AudioSource))]       // Audio Source zostanie utworzone w obiekcie, do którego przypisany zostanie te skrypt


public class MainMenuGUI : MonoBehaviour
{
    public AudioClip beep;
    public GUISkin menuSkin;
    public Rect menuArea;
    public Texture gameLogo;

    // przyciski
    Rect playBtnRect;
    Rect instructionsBtnRect;
    Rect quitBtnRect;
    float buttonWidth = 200;
    float buttonHeight = 40;
    float space = 20;

    public bool adjustPosition;
    public bool adjustSize;


    float coefX=1.0f;
    float coefY=1.0f;




    string menuPage = "main";
    public Rect instructionsRect;





    void Start()
    {

        if (adjustSize) {
            coefX = Screen.width/1024.0f;
            coefY = Screen.height/768.0f;
            menuArea.width*=coefX;
            menuArea.height*=coefY;
        }


        if (adjustPosition) {                   // zmiana rozdzielczości
            float w_2 = menuArea.width * 0.5f;
            float h_2 = menuArea.height * 0.5f;
            menuArea.x = (menuArea.x + w_2) * Screen.width/1024 - w_2;
            menuArea.y = (menuArea.y + h_2) * Screen.height/768 - h_2;
        }

        // playBtnRect = new Rect(50, 250, buttonWidth, buttonHeight);
        // instructionsBtnRect = new Rect(50, 250 + buttonHeight+space, buttonWidth, buttonHeight);
        // quitBtnRect = new Rect(50, 250 + (buttonHeight+space)*2, buttonWidth, buttonHeight);

        playBtnRect = new Rect(50*coefX, 250*coefY, buttonWidth*coefX, buttonHeight*coefY);
        instructionsBtnRect = new Rect(50*coefX, (250 + buttonHeight + space)*coefY, buttonWidth*coefX, buttonHeight*coefY);
        quitBtnRect = new Rect(50*coefX, (250 + (buttonHeight + space)*2)* coefY, buttonWidth*coefX, buttonHeight*coefY);

        instructionsRect = new Rect(0, 250 * coefY, 300 * coefX, buttonHeight * 3 * coefY);


        
    }



// void OnGUI() {
//         GUI.skin = menuSkin;
//         GUI.BeginGroup(menuArea);       //stworzyć obszar dla elementów interfejsu użytkownika poprzez zdefiniowanie nowej grupy GUI (all elemnt in one group):

//         //GUI.DrawTexture (new Rect (0,0, 300*coefX, 211*coefY), gameLogo);

//         GUI.DrawTexture (new Rect (0,0, 300, 211), gameLogo);


//         if (GUI.Button(instructionsBtnRect, "Play")) {
//             Debug.Log("Naciśnięto <Play>");
//             GetComponent<AudioSource>().PlayOneShot(beep);


//         }
//         if (GUI.Button(instructionsBtnRect, "Instructions")) {
//             Debug.Log("Naciśnięto <Instructions>");
//             GetComponent<AudioSource>().PlayOneShot(beep);


//         }
//         if (GUI.Button(quitBtnRect, "Quit")) {
//             Debug.Log("Naciśnięto <Quit>");
//             GetComponent<AudioSource>().PlayOneShot(beep);
//             //StartCoroutine("ButtonAction", "quit");
//         }

//         GUI.EndGroup();         //kończy definicję nowej grupy GU

//     }




    void OnGUI() {
        GUI.skin = menuSkin;
        if(menuPage == "main"){
            
        GUI.BeginGroup(menuArea);       //stworzyć obszar dla elementów interfejsu użytkownika poprzez zdefiniowanie nowej grupy GUI (all elemnt in one group):

        GUI.DrawTexture (new Rect (0,0, 300*coefX, 211*coefY), gameLogo);

        //GUI.DrawTexture (new Rect (0,0, 300, 211), gameLogo);


        if (GUI.Button(playBtnRect, "Play")) {
            Debug.Log("Naciśnięto <Play>");
            StartCoroutine("ButtonAction", "Menu");



        }
        if (GUI.Button(instructionsBtnRect, "Instructions")) {
            Debug.Log("Naciśnięto <Instructions>");
            menuPage="instructions";
            GetComponent<AudioSource>().PlayOneShot(beep);


        }
        if (GUI.Button(quitBtnRect, "Quit")) {
            Debug.Log("Naciśnięto <Quit>");
            //GetComponent<AudioSource>().PlayOneShot(beep);
            StartCoroutine("ButtonAction", "quit");

            //StartCoroutine("ButtonAction", "quit");
        }

        GUI.EndGroup();         //kończy definicję nowej grupy GU
        }
        else if (menuPage == "instructions") {
            GUI.Label(instructionsRect, "Obudziłeś się na tajemniczej wyspie..." + "Znajdź sposób na zwrócenie na siebie uwagi, inaczej zostaniesz tu na zawsze!");
            if(GUI.Button(quitBtnRect, "Back")) {
                GetComponent<AudioSource>().PlayOneShot(beep);
                menuPage="main";
            }
        }
        


    }





    IEnumerator ButtonAction (string levelName) {
        GetComponent<AudioSource>().PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);
        if (levelName != "quit") {
            SceneManager.LoadScene(levelName);
        }else {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit ();
        #endif
        }
}




    

    // Update is called once per frame
    void Update()
    {
        
    }
}

