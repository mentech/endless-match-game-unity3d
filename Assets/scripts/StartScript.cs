using UnityEngine;




public class StartScript : MonoBehaviour {

    public static GameObject menuHelpButon;
    public static GameObject menuButon;
    public static GameObject karistirButon;
    void Start()
    {
       menuHelpButon= GameObject.FindWithTag("menuHelpBtn");
        
       menuButon = GameObject.FindWithTag("menuBtn");
       karistirButon= GameObject.FindWithTag("karistirBtn");
        menuHelpButon.SetActive(false);
        
    }


    public Canvas StartCanvas;

    public void OnGUI ()
    {
        if ( GlobalVariables.startGame )
        {

            StartScript.menuButon.SetActive(false);
            StartScript.karistirButon.SetActive(false);

            float width = Screen.width;
            float height = Screen.height;
            //GUIContent bg = new GUIContent();
            GUIStyle bg = new GUIStyle(GUI.skin.box);
            //bg.active.background = (Texture2D)Resources.Load("TransparentBackground");
            bg.normal.background= (Texture2D)Resources.Load("TransparentBackground");
            GUI.Box(new Rect(0,0,width,height), "", bg);
            



            // mentech logosu

            GUIStyle MenTech = new GUIStyle(GUI.skin.button);
            MenTech.active.background = (Texture2D)Resources.Load("back");


            MenTech.normal.background = (Texture2D)Resources.Load("mentech4");
            MenTech.hover.background = (Texture2D)Resources.Load("mentech4");


            if (GUI.Button(new Rect(width / 13, (height / 1.101f), 434 / 2.8f, 89 / 2.8f), "", MenTech))     //----------MenTech-----------
            {
                
            }


            // oyunun ismi

            GUIStyle isim = new GUIStyle(GUI.skin.button);
            isim.active.background = (Texture2D)Resources.Load("back");

            isim.alignment = TextAnchor.UpperCenter;
            isim.normal.background = (Texture2D)Resources.Load("oyunIsmi");
          isim.hover.background = (Texture2D)Resources.Load("oyunIsmi");
           

            if (GUI.Button(new Rect(width /( 2.56f), Screen.height / 25, (height / 8) * 3, height / 8), "", isim))     //----------isim----------- isim
            {
                
            }


            
            // high score   ----------------------   high score   ---------------------     high score  --------------
            GUIStyle highButtonStyle = new GUIStyle();


            highButtonStyle.fontSize = Screen.width / 20;

            highButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            highButtonStyle.alignment = TextAnchor.MiddleCenter;

           // highButtonStyle.active.background.=
           // highButtonStyle.normal.background = (Texture2D)Resources.Load("menuArkaPlan");
            //highButtonStyle.hover.background = (Texture2D)Resources.Load("menuArkaPlan");
            highButtonStyle.normal.textColor = Color.white;


            GUI.Label(new Rect(width / 8, height / 5.5f, width * 6 / 8, height / 8), " High Score : " + PlayerPrefs.GetInt("YuksekSkor"), highButtonStyle);




            // play butonunun özellikleri   ------------ play butonunun özellikleri       ---------- play butonunun özellikleri
            GUIStyle playButtonStyle = new GUIStyle(GUI.skin.button);
            
         
                playButtonStyle.fontSize = Screen.width / 23;
           
            playButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            playButtonStyle.alignment = TextAnchor.MiddleCenter;


            playButtonStyle.normal.background = (Texture2D)Resources.Load("menuArkaPlan");
            playButtonStyle.hover.background = (Texture2D)Resources.Load("menuArkaPlan");
            playButtonStyle.normal.textColor = Color.black;
            

            if (GUI.Button(new Rect(width / 8, height / 2.85714f, width*6/8, height / 8), GlobalVariables.playmi /* + " High Score : "+PlayerPrefs.GetInt("YuksekSkor")*/, playButtonStyle))
            {
                StartScript.menuButon.SetActive(true);
                StartScript.karistirButon.SetActive(true);

                GlobalVariables.startGame = false;

                if (GlobalVariables.levelegorebasladi && !GlobalVariables.loaded)
                {

                    GlobalVariables.karistir = true;

                    
                }

                
            }

            //  How To Play   -------------------   How To Play   -------------

            GUIStyle resetButtonStyle = new GUIStyle(GUI.skin.button);
            
           
                resetButtonStyle.fontSize = Screen.width / 26;
            
            resetButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            resetButtonStyle.alignment = TextAnchor.MiddleCenter;
            resetButtonStyle.normal.textColor = Color.black;
            resetButtonStyle.normal.background = (Texture2D)Resources.Load("menuArkaPlan");
            resetButtonStyle.hover.background = (Texture2D)Resources.Load("menuArkaPlan");
            if (GUI.Button(new Rect(width / 8, height / 2, (width / 8) * 2.5f, height / 8), "How To Play", resetButtonStyle))
            {
                if (GlobalVariables.level < 7)
                {
                    helpButon.level = 5;
                }
                else if (GlobalVariables.level > 6)
                {
                   helpButon. level = 6;
                }
                GlobalVariables.startGame = false;
                GlobalVariables.kameraX = -77;
                Vector3 kameraKoordinati = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position;
                kameraKoordinati.x = -77;
                GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position = kameraKoordinati;
                GlobalVariables.howToPlaydayim = true;
                menuButon.SetActive(false);
                karistirButon.SetActive(false);
                menuHelpButon.SetActive(true);
                
            }

            //  sound on of ---------------------------   sound on of   --------------------

            string sound;
         // PlayerPrefs.DeleteKey("oktay");
            if (PlayerPrefs.GetInt("oktay")==1)
            {
                GlobalVariables.sesli = true;
            }
            else if (PlayerPrefs.GetInt("oktay") == 2 )
            {
                GlobalVariables.sesli = false;
            }


            if (GlobalVariables.sesli)
            {
                sound = "sound on";

            }
            else
            {
                sound = "sound off";

            }

            GUIStyle soundButtonStyle = new GUIStyle(GUI.skin.button);


            soundButtonStyle.fontSize = Screen.width / 26;

            soundButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            soundButtonStyle.alignment = TextAnchor.MiddleCenter;
            soundButtonStyle.normal.textColor = Color.black;
            soundButtonStyle.normal.background = (Texture2D)Resources.Load("menuArkaPlan");
            soundButtonStyle.hover.background = (Texture2D)Resources.Load("menuArkaPlan");
            if (GUI.Button(new Rect(width / 1.7745f, height / 2, (width / 8) * 2.5f, height / 8), sound, soundButtonStyle))
            {
                GlobalVariables.sesli = !GlobalVariables.sesli;
                if (GlobalVariables.sesli)
                {
                    PlayerPrefs.SetInt("oktay", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("oktay", 2);
                }
            }

            //  level buton   -------------------   level buton----------

            GUIStyle levelButtonStyle = new GUIStyle(GUI.skin.button);
           
             
           
                levelButtonStyle.fontSize = Screen.width / 26;
        

            levelButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            levelButtonStyle.alignment = TextAnchor.MiddleCenter;
            levelButtonStyle.normal.textColor = Color.black;
            levelButtonStyle.normal.background = (Texture2D)Resources.Load("menuArkaPlan");
            levelButtonStyle.hover.background = (Texture2D)Resources.Load("menuArkaPlan");

            if (GUI.Button(new Rect(width/8, height / 1.53846f, (width / 8) * 2.5f, height / 8), "Go to Level 1", levelButtonStyle))
            {
               
               // GlobalVariables.karistir = true;
                PlayerPrefs.SetInt("HighScore", 1);
                GlobalVariables.level = 1;
                GlobalVariables.levelegorebasladi=true;
                
                GlobalVariables.karistirmaHakki = 1;
                GlobalVariables.sifirlaButonlari = true;
                GlobalVariables.loaded = false;
                GlobalVariables.playmi = "Play";

            }


            //  exit buton-------------------   exit buton----------

            GUIStyle exitButtonStyle = new GUIStyle(GUI.skin.button);

            exitButtonStyle.fontSize = Screen.width / 23;

            


            exitButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            exitButtonStyle.alignment = TextAnchor.MiddleCenter;
            exitButtonStyle.normal.textColor = Color.black;
            exitButtonStyle.normal.background = (Texture2D)Resources.Load("menuArkaPlan");
            exitButtonStyle.hover.background = (Texture2D)Resources.Load("menuArkaPlan");
            
            if (GUI.Button(new Rect(width / 1.7745f, height / 1.53846f, (width / 8) * 2.5f, height / 8), "Exit", exitButtonStyle))
            {

              Application.Quit();
                
            }

        }

        
    }




    


}
