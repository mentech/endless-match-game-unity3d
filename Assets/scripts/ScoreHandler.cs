using UnityEngine;


using System;

public class ScoreHandler : MonoBehaviour {
    
    // Use this for initialization

        void ilkBaslangic()
    {


        StartScript.menuButon.SetActive(false);
        StartScript.karistirButon.SetActive(false);
        StartScript.menuHelpButon.SetActive(true);
       
    }
    void Start () {

        
        
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 1);

            // ----------------------    ilk başlangıçta eğitim  ---------------------------------------------------------
            
            helpButon.level = 4;
            GlobalVariables.kameraX = -77;
            Vector3 kameraKoordinati = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position;
            kameraKoordinati.x = -77;
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position = kameraKoordinati;
            GlobalVariables.howToPlaydayim = true;
            GlobalVariables.startGame = false;
            Invoke("ilkBaslangic", 0.01f);

        }
        if (!PlayerPrefs.HasKey("YuksekSkor"))
        {
            PlayerPrefs.SetInt("YuksekSkor", 0);
           
        }


    }

	void Update () {


        if (GlobalVariables.level > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", GlobalVariables.level);

        }
        if (GlobalVariables.level > PlayerPrefs.GetInt("YuksekSkor"))
        {
            PlayerPrefs.SetInt("YuksekSkor", GlobalVariables.level);

        }
    }

    public Font font;
    void OnGUI ()
    {
        string ekranUst;
        if (!GlobalVariables.startGame)
        {
            ekranUst = "Level : " + Convert.ToString(GlobalVariables.level);
            Vector3 btnInactivePos = GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position;
            btnInactivePos.x = 555;
            GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position = btnInactivePos;
        }
        else
        {
           Vector3 btnInactivePos = GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position;
            btnInactivePos.x = 0;
            GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position = btnInactivePos;
            ekranUst = "";
        }

        if (GlobalVariables.kameraX==0)
        {

        GUIStyle style = new GUIStyle();
        style.fontSize = Screen.height / 9; //12
        style.alignment = TextAnchor.UpperCenter;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 25, 100, 100), ekranUst, style);
        GlobalVariables.level = PlayerPrefs.GetInt("HighScore");
            GUI.color = Color.red;
        }
    }
}
