using UnityEngine;
using UnityEngine.UI;



public class ButonScript : MonoBehaviour {

    // Use this for initialization

    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public GameObject btnAnime;
    public AudioSource audTiklama;
    public AudioSource audAnimasyon;
    public AudioSource audLevelGecme;
    Sprite[] sayilar = new Sprite[4];
    GameObject[] Buttons = new GameObject[16];
    GameObject[] ButtonsAuto = new GameObject[16];

    Vector3 tiklananButonKordinati = new Vector3();
    Vector3 tiklananAutoButonKordinati = new Vector3();
    Vector3 btnInactivePos = new Vector3();


    

    void Start () {

        
            TaniSpriteleri();
            TaniButonlari();
        taniAutolari();

        GlobalVariables.btnAnimePos= Buttons[0].transform.position - ButtonsAuto[0].transform.position;

        
            
            loadGame();
        
        
      
	}
	
	// Update is called once per frame
	void Update () {


       

        if (GlobalVariables.saveGame)
        {
            saveGame();
        }
        

        if (GlobalVariables.karistir)
        {
            sifirlaButonlari();
            OyunuLeveleGoreBaslat();
            GlobalVariables.karistir = false;
        }
        if (GlobalVariables.sifirlaButonlari)
        {
            sifirlaButonlari();
            GlobalVariables.sifirlaButonlari = false;
        }

	}

    void OnMouseDown()
    {
        //tıklanan butonun sayısını 1 arttırır
       
        if (GlobalVariables.sesli)
        {
            audTiklama.Play();
        }
       
        for (int i = 0; i < 4; i++)
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == sayilar[i])
            {
               
                gameObject.GetComponent<SpriteRenderer>().sprite = sayilar[(i + 1)%4];
                i = 5;
            }
           
        }

        tiklananButonKordinati= gameObject.GetComponent<Transform>().position;
        // ----------------------------------tıklanan butonun etrafındaki butonları kontrol eder------------------------------------

        Vector3 ButonKordinati = new Vector3();
        Sprite spriteButon = new Sprite();



        for (int i = 0; i < 16; i++)
        {

            

            ButonKordinati = Buttons[i].GetComponent<Transform>().position;
            spriteButon = Buttons[i].GetComponent<SpriteRenderer>().sprite;
            // sol butonu arttırır
            if (ButonKordinati.x + 4 == tiklananButonKordinati.x && ButonKordinati.y==tiklananButonKordinati.y && spriteButon != sprite0 )
            {
                
                for (int j = 0; j < 4; j++)
                {
                    if (spriteButon == sayilar[j])
                    {
                        Buttons[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                        j = 5;
                          }
                }
            }

            // sağ butonu arttırır
           else if (ButonKordinati.x - 4 == tiklananButonKordinati.x && ButonKordinati.y == tiklananButonKordinati.y && spriteButon != sprite0)
            {
                

                for (int j = 0; j < 4; j++)
                {
                    if (spriteButon == sayilar[j])
                    {

                        Buttons[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                        j = 5;
                         }
                }
            }

            // alt butonu arttırır
           else if (ButonKordinati.x  == tiklananButonKordinati.x && ButonKordinati.y+4 == tiklananButonKordinati.y && spriteButon != sprite0)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (spriteButon == sayilar[j])
                    {
                        Buttons[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                        j = 5;
                    }
                }
            }

            // üst butonu arttırır
           else if (ButonKordinati.x == tiklananButonKordinati.x && ButonKordinati.y-4 == tiklananButonKordinati.y && spriteButon != sprite0)
            {
                
                for (int j = 0; j < 4; j++)
                {
                    if (spriteButon == sayilar[j])
                    {
                        Buttons[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                        j = 5;
                    }
                }
            }
   

        }


        
        isFinish();



        // ----------------------------------------click burada bitiyorr-------------------------------------


    }
    int kontrol = 1;
    public void OyunuLeveleGoreBaslat()
    {
        if (GlobalVariables.levelegorebasladi)
        {
            GlobalVariables.levelegorebasladi = false;
            

            int okt = 0;
            

            for (int saydir = 0; saydir < GlobalVariables.level; saydir++)
            {

               
               System.Random rnd = new System.Random();
                int[] intler = new int[16];
                int k = 0;
                int b;
                bool exist;
                while (k != intler.Length)
                {
                    exist = false;
                    b = (rnd.Next(16) + 1);
                    for (int j = 0; j < intler.Length; j++)
                        if (intler[j] == b) { exist = true; }
                    if (!exist) { intler[k++] = b; }
                }



                if (intler[saydir % 16] > 15)
                {
                    okt = intler[saydir % 16] - 2;
                }
                else
                {
                    okt = intler[saydir % 16];
                }


                if (okt == kontrol)
                {
                    if (intler[(saydir + 1) % 16] > 15)
                    {
                        okt = intler[(saydir + 1) % 16] - 2;
                    }
                    else
                    {
                        okt = intler[(saydir+1) % 16];
                    }
                }


                kontrol = okt;



                for (int i = 0; i < 4; i++)
                {
                    if (ButtonsAuto[okt].GetComponent<SpriteRenderer>().sprite == sayilar[i])
                    {

                        ButtonsAuto[okt].GetComponent<SpriteRenderer>().sprite = sayilar[(i + 1) % 4];
                        i = 5;
                    }

                }

                tiklananAutoButonKordinati = ButtonsAuto[okt].GetComponent<Transform>().position;
                // ----------------------------------tıklanan butonun etrafındaki butonları kontrol eder------------------------------------

               

                Vector3 ButonKordinati = new Vector3();
                Sprite spriteButon = new Sprite();


                for (int i = 0; i < 16; i++)
                {



                    ButonKordinati = ButtonsAuto[i].GetComponent<Transform>().position;
                    spriteButon = ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite;
                    // sol butonu arttırır
                    if (ButonKordinati.x + 4 == tiklananAutoButonKordinati.x && ButonKordinati.y == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {

                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == sayilar[j])
                            {
                                ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                                j = 5;
                                
                            }
                        }
                    }

                    // sağ butonu arttırır
                    else if (ButonKordinati.x - 4 == tiklananAutoButonKordinati.x && ButonKordinati.y == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {


                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == sayilar[j])
                            {

                                ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                                j = 5;
                                
                            }
                        }
                    }

                    // alt butonu arttırır
                    else if (ButonKordinati.x == tiklananAutoButonKordinati.x && ButonKordinati.y + 4 == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {
                        
                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == sayilar[j])
                            {
                                ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                                j = 5;
                            }
                        }
                    }

                    // üst butonu arttırır
                    else if (ButonKordinati.x == tiklananAutoButonKordinati.x && ButonKordinati.y - 4 == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {
                        
                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == sayilar[j])
                            {
                                ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite = sayilar[(j + 1) % 4];
                                j = 5;
                            }
                        }
                    }


                }

            }

            if (GlobalVariables.level>9 && GlobalVariables.level<20)
            {
                int doluSayisi = 0;

                for (int i = 0; i < 16; i++)
                {
                    if (ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite !=sprite0)
                    {
                        doluSayisi++;

                    }
                }

                if (doluSayisi<7)
                {
                    sifirlaButonlari();
                    GlobalVariables.levelegorebasladi = true;
                    OyunuLeveleGoreBaslat();
                }
            }

           else if (GlobalVariables.level > 19 && GlobalVariables.level < 30)
            {
                int doluSayisi = 0;

                for (int i = 0; i < 16; i++)
                {
                    if (ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite != sprite0)
                    {
                        doluSayisi++;

                    }
                }

                if (doluSayisi < 8)
                {
                    sifirlaButonlari();
                    GlobalVariables.levelegorebasladi = true;
                    OyunuLeveleGoreBaslat();
                }
            }

            else if (GlobalVariables.level > 29 && GlobalVariables.level < 40)
            {
                int doluSayisi = 0;

                for (int i = 0; i < 16; i++)
                {
                    if (ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite != sprite0)
                    {
                        doluSayisi++;

                    }
                }

                if (doluSayisi < 9)
                {
                    sifirlaButonlari();
                    GlobalVariables.levelegorebasladi = true;
                    OyunuLeveleGoreBaslat();
                }
            }
            else if (GlobalVariables.level > 39 && GlobalVariables.level < 50)
            {
                int doluSayisi = 0;

                for (int i = 0; i < 16; i++)
                {
                    if (ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite != sprite0)
                    {
                        doluSayisi++;

                    }
                }

                if (doluSayisi < 10)
                {
                    sifirlaButonlari();
                    GlobalVariables.levelegorebasladi = true;
                    OyunuLeveleGoreBaslat();
                }
            }

            else if (GlobalVariables.level >  49)
            {
                int doluSayisi = 0;

                for (int i = 0; i < 16; i++)
                {
                    if (ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite != sprite0)
                    {
                        doluSayisi++;

                    }
                }

                if (doluSayisi < 11)
                {
                    sifirlaButonlari();
                    GlobalVariables.levelegorebasladi = true;
                    OyunuLeveleGoreBaslat();
                }
            }

            GlobalVariables.saveGame = true;
        }
    }



    private void isFinish()
    {
        bool matched = true;
        for (int i = 0; i < 16; i++)
        {
            if (Buttons[i].GetComponent<SpriteRenderer>().sprite == ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite )
            {
                
            }
            else
            {
                matched = false;
                break;
            }
        }


        if (matched)
        {
            if (GlobalVariables.sesli)
            {
                audAnimasyon.Play();
                Invoke("levelGecmeAudio", 0.76f);
            }
            
            btnInactivePos = GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position;
            btnInactivePos.x = 0;
            GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position = btnInactivePos;
            btnAnimasyon();
           
            
            Invoke("levelArttir", GlobalVariables.btnAnimeTime-0.2f);
            Invoke("gecBasla", GlobalVariables.btnAnimeTime);
        }
    }

    void TaniSpriteleri()
    {
       
            sayilar[0] = sprite0;
            sayilar[1] = sprite1;
            sayilar[2] = sprite2;
            sayilar[3] = sprite3;

        

    }
    void TaniButonlari()
    {
        Buttons[0] = GameObject.FindWithTag("buton1");
        Buttons[1] = GameObject.FindWithTag("buton2");
        Buttons[2] = GameObject.FindWithTag("buton3");
        Buttons[3] = GameObject.FindWithTag("buton4");
        Buttons[4] = GameObject.FindWithTag("buton5");
        Buttons[5] = GameObject.FindWithTag("buton6");
        Buttons[6] = GameObject.FindWithTag("buton7");
        Buttons[7] = GameObject.FindWithTag("buton8");
        Buttons[8] = GameObject.FindWithTag("buton9");
        Buttons[9] = GameObject.FindWithTag("buton10");
        Buttons[10] = GameObject.FindWithTag("buton11");
        Buttons[11] = GameObject.FindWithTag("buton12");
        Buttons[12] = GameObject.FindWithTag("buton13");
        Buttons[13] = GameObject.FindWithTag("buton14");
        Buttons[14] = GameObject.FindWithTag("buton15");
        Buttons[15] = GameObject.FindWithTag("buton16");


        
        //Vector2 artiX = new Vector2();
        //artiX.x = -4;
        //Vector2 artiY = new Vector2();
        //artiY.y = -4;
        

        for (int i = 0; i < 16; i++)
        {
            
            Buttons[i].GetComponent<SpriteRenderer>().sprite = sprite0;
           
        }




    }
    void taniAutolari()
    {
        ButtonsAuto[0] = GameObject.FindWithTag("butonAuto1");
        ButtonsAuto[1] = GameObject.FindWithTag("butonAuto2");
        ButtonsAuto[2] = GameObject.FindWithTag("butonAuto3");
        ButtonsAuto[3] = GameObject.FindWithTag("butonAuto4");
        ButtonsAuto[4] = GameObject.FindWithTag("butonAuto5");
        ButtonsAuto[5] = GameObject.FindWithTag("butonAuto6");
        ButtonsAuto[6] = GameObject.FindWithTag("butonAuto7");
        ButtonsAuto[7] = GameObject.FindWithTag("butonAuto8");
        ButtonsAuto[8] = GameObject.FindWithTag("butonAuto9");
        ButtonsAuto[9] = GameObject.FindWithTag("butonAuto10");
        ButtonsAuto[10] = GameObject.FindWithTag("butonAuto11");
        ButtonsAuto[11] = GameObject.FindWithTag("butonAuto12");
        ButtonsAuto[12] = GameObject.FindWithTag("butonAuto13");
        ButtonsAuto[13] = GameObject.FindWithTag("butonAuto14");
        ButtonsAuto[14] = GameObject.FindWithTag("butonAuto15");
        ButtonsAuto[15] = GameObject.FindWithTag("butonAuto16");

        for (int i = 0; i < 16; i++)
        {
          //  Debug.Log(ButtonsAuto[i].name);
        }
    }

    public void sifirlaButonlari()
    {
        for (int i = 0; i < 16; i++)
        {
            ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite = sayilar[0];
            Buttons[i].GetComponent<SpriteRenderer>().sprite = sayilar[0];
        }
    }
    void levelArttir()
    {
        GlobalVariables.level++;
    }
    void gecBasla()
    {
        
        sifirlaButonlari();
       

       
        GlobalVariables.levelegorebasladi = true;
        OyunuLeveleGoreBaslat();
       
        PlayerPrefs.SetInt("karistir", 1);
        GameObject.FindGameObjectWithTag("karistirTxt").GetComponent<Text>().text = "Shuffle (" + PlayerPrefs.GetInt("karistir") + ")";

        btnInactivePos = GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position;
        btnInactivePos.x = 555;
        GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position = btnInactivePos;
    }
    void levelGecmeAudio()
    {
        audLevelGecme.Play();
    }
    void btnAnimasyon()
    {
        for (int i = 0; i < 16; i++)
        {
            if (Buttons[i].GetComponent<SpriteRenderer>().sprite !=sprite0 && Buttons[i].GetComponent<SpriteRenderer>().sprite == ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite)
            {
                btnAnime.GetComponent<SpriteRenderer>().sprite = Buttons[i].GetComponent<SpriteRenderer>().sprite;
                Instantiate(btnAnime, Buttons[i].GetComponent<Transform>().position, Quaternion.identity);
                Buttons[i].GetComponent<SpriteRenderer>().sprite = sprite0;
            }
           
        }
    }

    void saveGame()
    {
        PlayerPrefs.SetInt("saveGame" , PlayerPrefs.GetInt("HighScore"));

        for (int i = 0; i < 16; i++)
        {
            PlayerPrefs.SetInt("autoButon" + i, 0);
            for (int j = 0; j < 4; j++)
            {

                if (ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite == sayilar[j])
                {
                    PlayerPrefs.SetInt("autoButon"+i, j);
                }
            }
        }
        GlobalVariables.saveGame = false;
    }
    void loadGame()
    {
        if (PlayerPrefs.GetInt("HighScore")== PlayerPrefs.GetInt("saveGame") && PlayerPrefs.GetInt("HighScore") > 1)
        {

            for (int i = 0; i < 16; i++)
            {
                ButtonsAuto[i].GetComponent<SpriteRenderer>().sprite = sayilar[PlayerPrefs.GetInt("autoButon"+i)];
            }
            GlobalVariables.loaded = true;
        }
    }

    



}
