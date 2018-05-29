using UnityEngine;


public class helpButon : MonoBehaviour {
    bool levelegorebasladi = true;

    bool karistir = false;
   public static int level;
    GameObject[] hamleler=new GameObject[16];
    int hamleSayisi;
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    bool egitimeBasla = false;
    public Sprite dastNormal;
    public Sprite dastClick;
    
    Sprite[] spriteler = new Sprite[4];
    GameObject[] Button= new GameObject[16];
    GameObject[] ButtonAuto = new GameObject[16];
    public GameObject dast;
    public GameObject btnAnime;
    public AudioSource audTiklama;
    public AudioSource audAnimasyon;
    public AudioSource audLevelGecme;
    bool dastgecBaslar = false;

  
    Vector3 tiklananAutoButonKordinati = new Vector3();
    Vector3 btnInactivePos = new Vector3();
    
    bool hizHesaplandimi = false;
    Vector3 dastpos;
    Vector3 dastposBaslangic;
    Vector3 xHareketi;
    Vector3 yHareketi;
  

    void Start () {
       
        TaniSpriteleri();
        taniAutolari();
        TaniButonlari();
        dastpos= dast.transform.position;
        GlobalVariables.btnAnimePos = Button[0].transform.position - ButtonAuto[0].transform.position;
        dastposBaslangic = dastpos;

      

        
    }
	
	// Update is called once per frame

        void dastNormalSprite()
    {
        dast.GetComponent<SpriteRenderer>().sprite = dastNormal;
    }

	void Update () {

        if (GlobalVariables.howToPlaydayim)
        {
           
           
            dast.transform.position = dastposBaslangic;
            dastpos = dast.transform.position;
            levelegorebasladi = true;
            OyunuLeveleGoreBaslat();
            GlobalVariables.howToPlaydayim = false;

            dastgecBaslar = true;

        }

        if (karistir && GlobalVariables.kameraX==-77 && !GlobalVariables.howToPlaydayim)
        {
           
            sifirlaButonlari();
            OyunuLeveleGoreBaslat();
            karistir = false;
        }

        if (egitimeBasla && GlobalVariables.kameraX == -77 && !GlobalVariables.howToPlaydayim && dastgecBaslar)
        {
            hedefeGit(hamleler[hamleSayisi]);
        }

       

    }
    void OnMouseDown()
    {
        GlobalVariables.startGame = true;
        GlobalVariables.kameraX = 0;
     Vector3 kameraKoordinati= GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position;
        kameraKoordinati.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position = kameraKoordinati;
       StartScript. menuButon.SetActive(true);
        StartScript.karistirButon.SetActive(true);
        StartScript.menuHelpButon.SetActive(false);
    }

    void TaniSpriteleri()
    {

        spriteler[0] = sprite0;
        spriteler[1] = sprite1;
        spriteler[2] = sprite2;
        spriteler[3] = sprite3;

        

    }
    void TaniButonlari()
    {
        Button[0] = GameObject.FindWithTag("butonHelp1");
        Button[1] = GameObject.FindWithTag("butonHelp2");
        Button[2] = GameObject.FindWithTag("butonHelp3");
        Button[3] = GameObject.FindWithTag("butonHelp4");
        Button[4] = GameObject.FindWithTag("butonHelp5");
        Button[5] = GameObject.FindWithTag("butonHelp6");
        Button[6] = GameObject.FindWithTag("butonHelp7");
        Button[7] = GameObject.FindWithTag("butonHelp8");
        Button[8] = GameObject.FindWithTag("butonHelp9");
        Button[9] = GameObject.FindWithTag("butonHelp10");
        Button[10] = GameObject.FindWithTag("butonHelp11");
        Button[11] = GameObject.FindWithTag("butonHelp12");
        Button[12] = GameObject.FindWithTag("butonHelp13");
        Button[13] = GameObject.FindWithTag("butonHelp14");
        Button[14] = GameObject.FindWithTag("butonHelp15");
        Button[15] = GameObject.FindWithTag("butonHelp16");



        //Vector2 artiX = new Vector2();
        //artiX.x = -4;
        //Vector2 artiY = new Vector2();
        //artiY.y = -4;


        for (int i = 0; i < 16; i++)
        {

            Button[i].GetComponent<SpriteRenderer>().sprite = sprite0;

        }




    }
    void taniAutolari()
    {
        ButtonAuto[0] = GameObject.FindWithTag("butonAutoHelp1");
        ButtonAuto[1] = GameObject.FindWithTag("butonAutoHelp2");
        ButtonAuto[2] = GameObject.FindWithTag("butonAutoHelp3");
        ButtonAuto[3] = GameObject.FindWithTag("butonAutoHelp4");
        ButtonAuto[4] = GameObject.FindWithTag("butonAutoHelp5");
        ButtonAuto[5] = GameObject.FindWithTag("butonAutoHelp6");
        ButtonAuto[6] = GameObject.FindWithTag("butonAutoHelp7");
        ButtonAuto[7] = GameObject.FindWithTag("butonAutoHelp8");
        ButtonAuto[8] = GameObject.FindWithTag("butonAutoHelp9");
        ButtonAuto[9] = GameObject.FindWithTag("butonAutoHelp10");
        ButtonAuto[10] = GameObject.FindWithTag("butonAutoHelp11");
        ButtonAuto[11] = GameObject.FindWithTag("butonAutoHelp12");
        ButtonAuto[12] = GameObject.FindWithTag("butonAutoHelp13");
        ButtonAuto[13] = GameObject.FindWithTag("butonAutoHelp14");
        ButtonAuto[14] = GameObject.FindWithTag("butonAutoHelp15");
        ButtonAuto[15] = GameObject.FindWithTag("butonAutoHelp16");

        for (int i = 0; i < 16; i++)
        {
            //  Debug.Log(ButtonsAuto[i].name);
        }
    }

    
    void darang()
    {
        egitimeBasla = true;
    }
  
    
    void hedefeGit(GameObject hedef)
    {
        
        if (!hizHesaplandimi)
        {
            xHareketi.x = dastpos.x - hedef.transform.position.x;
            yHareketi.y = dastpos.y - hedef.transform.position.y;

            float x = xHareketi.x;
            float y = yHareketi.y ;
            if (x*Mathf.Sign(x)+y*Mathf.Sign(y) < 4 )
            {
                for (int i = 4; i < 33; i++)
                {

                    xHareketi.x /= i * (3 / 10);
                    yHareketi.y /= i * (3 / 10);

                    if (xHareketi.x * Mathf.Sign(xHareketi.x) + yHareketi.y * Mathf.Sign(yHareketi.y) > 4 && xHareketi.x * Mathf.Sign(xHareketi.x) + yHareketi.y * Mathf.Sign(yHareketi.y)<5)
                    {
                        
                        hizHesaplandimi = true;
                        break;
                    }
                    xHareketi.x = x;
                    yHareketi.y = y;
                }
            }
            else if (x * Mathf.Sign(x) + y * Mathf.Sign(y) > 5)
            {
                for (int i = 4; i < 33; i++)
                {

                    xHareketi.x = x / (i * (3 / 10));
                    yHareketi.y = y / (i * (3 / 10));
                    if (xHareketi.x * Mathf.Sign(xHareketi.x) + yHareketi.y * Mathf.Sign(yHareketi.y) < 5&& xHareketi.x * Mathf.Sign(xHareketi.x) + yHareketi.y * Mathf.Sign(yHareketi.y)>4)
                    {
                        
                        hizHesaplandimi = true;
                        break;
                    }
                    xHareketi.x = x;
                    yHareketi.y = y;

                }
            }

            
        }
       
        
        Vector3 spawnPos = dast.gameObject.transform.position;

        spawnPos.x = Mathf.Lerp(spawnPos.x, dast.gameObject.transform.position.x - xHareketi.x*(level/10f), 1 * Time.deltaTime);
        spawnPos.y = Mathf.Lerp(spawnPos.y, dast.gameObject.transform.position.y - yHareketi.y * (level / 10f ), 1 * Time.deltaTime);
        dast.gameObject.transform.position = spawnPos;

        if (spawnPos.x< hedef.transform.position.x+1 && spawnPos.x > hedef.transform.position.x -1 && spawnPos.y < hedef.transform.position.y + 1 && spawnPos.y > hedef.transform.position.y - 1)
        {
           
            dastpos = dast.transform.position; 
            hizHesaplandimi = false;
            for (int i = 0; i < 16; i++)
            {
                if (hamleler[hamleSayisi]==Button[i])
                {
                    butonuTikla(Button[i]);
                    dast.GetComponent<SpriteRenderer>().sprite = dastClick;
                    Invoke("dastNormalSprite", 0.3f);
                    break;
                }
            }

            hamleSayisi++;  
            if (hamleSayisi!=level)
            {
               
                hedefeGit(hamleler[hamleSayisi]);
                egitimeBasla = false;
                Invoke("darang", 0.4f);
            }
            else
            {

                Invoke("bittiktenSonraDastiIlkKonum", 0.2f);
                egitimeBasla = false;
            }
        }

    }
    void bittiktenSonraDastiIlkKonum()
    {
        dast.GetComponent<SpriteRenderer>().sprite = dastNormal;
        //dast.transform.position = dastposBaslangic;
        //dastpos = dastposBaslangic;
    }
    public void sifirlaButonlari()
    {
        for (int i = 0; i < 16; i++)
        {
            ButtonAuto[i].GetComponent<SpriteRenderer>().sprite = spriteler[0];
            Button[i].GetComponent<SpriteRenderer>().sprite = spriteler[0];
        }
    }
    private void isFinish()
    {
        bool matched = true;
        for (int i = 0; i < 16; i++)
        {
            if (Button[i].GetComponent<SpriteRenderer>().sprite == ButtonAuto[i].GetComponent<SpriteRenderer>().sprite)
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


            Invoke("levelArttir", GlobalVariables.btnAnimeTime - 0.2f);
            Invoke("gecBasla", GlobalVariables.btnAnimeTime);
        }
    }

    void btnAnimasyon()
    {
        for (int i = 0; i < 16; i++)
        {
            if (Button[i].GetComponent<SpriteRenderer>().sprite != sprite0 && Button[i].GetComponent<SpriteRenderer>().sprite == ButtonAuto[i].GetComponent<SpriteRenderer>().sprite)
            {
                btnAnime.GetComponent<SpriteRenderer>().sprite = Button[i].GetComponent<SpriteRenderer>().sprite;
                Instantiate(btnAnime, Button[i].GetComponent<Transform>().position, Quaternion.identity);
                Button[i].GetComponent<SpriteRenderer>().sprite = sprite0;
            }

        }
    }


    int kontrol = 1;
    public void OyunuLeveleGoreBaslat()
    {
        if (levelegorebasladi)
        {
            sifirlaButonlari();
             levelegorebasladi = false;

            hamleSayisi = 0;
            int okt = 0;



            for (int saydir = 0; saydir <  level; saydir++)
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
                        okt = intler[(saydir + 1) % 16];
                    }
                }


                kontrol = okt;



                for (int i = 0; i < 4; i++)
                {
                    if (ButtonAuto[okt].GetComponent<SpriteRenderer>().sprite == spriteler[i])
                    {

                        ButtonAuto[okt].GetComponent<SpriteRenderer>().sprite = spriteler[(i + 1) % 4];
                        hamleler[hamleSayisi] = Button[okt];
                        hamleSayisi++;
                        i = 5;
                    }

                }

                tiklananAutoButonKordinati = ButtonAuto[okt].GetComponent<Transform>().position;
                // ----------------------------------tıklanan butonun etrafındaki butonları kontrol eder------------------------------------

                Debug.Log(ButtonAuto[okt].name);

                Vector3 ButonKordinati = new Vector3();
                Sprite spriteButon = new Sprite();


                for (int i = 0; i < 16; i++)
                {



                    ButonKordinati = ButtonAuto[i].GetComponent<Transform>().position;
                    spriteButon = ButtonAuto[i].GetComponent<SpriteRenderer>().sprite;
                    // sol butonu arttırır
                    if (ButonKordinati.x + 4 == tiklananAutoButonKordinati.x && ButonKordinati.y == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {

                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == spriteler[j])
                            {
                                ButtonAuto[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                                j = 5;
                                
                            }
                        }
                    }

                    // sağ butonu arttırır
                    else if (ButonKordinati.x - 4 == tiklananAutoButonKordinati.x && ButonKordinati.y == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {


                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == spriteler[j])
                            {

                                ButtonAuto[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                                j = 5;
                                
                            }
                        }
                    }

                    // alt butonu arttırır
                    else if (ButonKordinati.x == tiklananAutoButonKordinati.x && ButonKordinati.y + 4 == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {
                       
                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == spriteler[j])
                            {
                                ButtonAuto[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                                j = 5;
                            }
                        }
                    }

                    // üst butonu arttırır
                    else if (ButonKordinati.x == tiklananAutoButonKordinati.x && ButonKordinati.y - 4 == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                    {
                        
                        for (int j = 0; j < 4; j++)
                        {
                            if (spriteButon == spriteler[j])
                            {
                                ButtonAuto[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                                j = 5;
                            }
                        }
                    }


                }

            }

            if (level > 2)
            {
                int doluSayisi = 0;

                for (int i = 0; i < 16; i++)
                {
                    if (ButtonAuto[i].GetComponent<SpriteRenderer>().sprite != sprite0)
                    {
                        doluSayisi++;

                    }
                }

                if (doluSayisi !=level)
                {
                    sifirlaButonlari();
                    levelegorebasladi = true;
                    OyunuLeveleGoreBaslat();
                }
            }

           

            hamleSayisi = 0;
            egitimeBasla = true;
        }
    }
    void levelGecmeAudio()
    {
        audLevelGecme.Play();
    }
    void levelArttir()
    {
        

        if (level == 4)
        {
            GlobalVariables.kameraX = 0;
            Vector3 kameraKoordinati = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position;
            kameraKoordinati.x = 0;
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().transform.position = kameraKoordinati;
            GlobalVariables.startGame = true;
            StartScript.menuHelpButon.SetActive(false);
            StartScript.menuButon.SetActive(true);
            StartScript.karistirButon.SetActive(true);
        }
      
    }

    void butonuTikla(GameObject tiklananBtn)
    {

        if (GlobalVariables.sesli)
        {
            audTiklama.Play();
        }

        for (int ik = 0; ik < 4; ik++)
            {
                if (tiklananBtn.GetComponent<SpriteRenderer>().sprite == spriteler[ik])
                {
                    tiklananBtn.GetComponent<SpriteRenderer>().sprite = spriteler[(ik + 1) % 4];
                   
                    ik = 5;
                }
            }

            tiklananAutoButonKordinati = tiklananBtn.GetComponent<Transform>().position;
            // ----------------------------------tıklanan butonun etrafındaki butonları kontrol eder------------------------------------

            

            Vector3 ButonKordinati = new Vector3();
            Sprite spriteButon = new Sprite();


            for (int i = 0; i < 16; i++)
            {



                ButonKordinati = Button[i].GetComponent<Transform>().position;
                spriteButon = Button[i].GetComponent<SpriteRenderer>().sprite;
                // sol butonu arttırır
                if (ButonKordinati.x + 4 == tiklananAutoButonKordinati.x && ButonKordinati.y == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (spriteButon == spriteler[j])
                        {
                            Button[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                            j = 5;
                           
                        }
                    }
                }

                // sağ butonu arttırır
                else if (ButonKordinati.x - 4 == tiklananAutoButonKordinati.x && ButonKordinati.y == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                {


                    for (int j = 0; j < 4; j++)
                    {
                        if (spriteButon == spriteler[j])
                        {

                            Button[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                            j = 5;
                            
                        }
                    }
                }

                // alt butonu arttırır
                else if (ButonKordinati.x == tiklananAutoButonKordinati.x && ButonKordinati.y + 4 == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                {
                   
                    for (int j = 0; j < 4; j++)
                    {
                        if (spriteButon == spriteler[j])
                        {
                            Button[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                            j = 5;
                        }
                    }
                }

                // üst butonu arttırır
                else if (ButonKordinati.x == tiklananAutoButonKordinati.x && ButonKordinati.y - 4 == tiklananAutoButonKordinati.y && spriteButon != sprite0)
                {
                  
                    for (int j = 0; j < 4; j++)
                    {
                        if (spriteButon == spriteler[j])
                        {
                            Button[i].GetComponent<SpriteRenderer>().sprite = spriteler[(j + 1) % 4];
                            j = 5;
                        }
                    }
                }


            }

        isFinish();
        
    }

    void gecBasla()
    {
        
        sifirlaButonlari();
       

       
      levelegorebasladi = true;
        OyunuLeveleGoreBaslat();
       
        btnInactivePos = GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position;
        btnInactivePos.x = 555;
        GameObject.FindWithTag("btnInactive").GetComponent<Transform>().position = btnInactivePos;
    }

    public Font font;
    void OnGUI()
    {
        if (GlobalVariables.kameraX==-77)
        {

        
        GUIStyle style = new GUIStyle();
        style.fontSize = Screen.height / 9; //12
        style.alignment = TextAnchor.UpperCenter;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 25, 100, 100), "How to Play ? " , style);

        }
    }
}
