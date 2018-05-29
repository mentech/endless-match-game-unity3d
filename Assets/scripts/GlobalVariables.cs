using UnityEngine;


public class GlobalVariables : MonoBehaviour {


    public static int level = 1;
    public static int karistirmaHakki = 1;
    public static int kameraX=0;
    public static bool levelegorebasladi =true;
    public static bool levelgecildi = true;
    public static bool saveGame = false;

    public static bool karistir = false;
    public static bool loaded = false;
    public static bool howToPlaydayim = false;

    public static bool sesli = true;
    public static bool sifirlaButonlari = false;

    public static bool startGame = true;
   
    public static bool automode = true;
    public static int btnAnimeTime = 2;
    public static Vector3 btnAnimePos;
    public static string playmi = "Play";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
