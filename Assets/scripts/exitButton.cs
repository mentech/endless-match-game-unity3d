using UnityEngine;
using UnityEngine.UI;

public class exitButton : MonoBehaviour {

    // Use this for initialization

    public AudioSource audYanlis;

	void Start () {

       // GameObject okt= GameObject.FindWithTag("menuBtn");
        
        if (!PlayerPrefs.HasKey("karistir"))
        {
            PlayerPrefs.SetInt("karistir", 1);
        }
        if (this.name== "karistir")
        {
            this.GetComponentInChildren<Text>().text = "Shuffle (" + PlayerPrefs.GetInt("karistir") + ")";
        }

        
    }
	
	// Update is called once per frame
	void Update () {

        if (!GlobalVariables.startGame && this.name=="menu")
        {
            this.enabled = true;
        }

    }
    void OnMouseDown()
    {
        
        if (this.name == "menu")
        {
            GlobalVariables.startGame = true;
            GlobalVariables.playmi = "Resume";
            StartScript.menuButon.SetActive(false);
            StartScript.karistirButon.SetActive(false);

        }
        if (this.name == "autolar")
        {

            yanlisSes();
        }
        if (this.name == "karistir")
        {
           
            
            if (PlayerPrefs.GetInt("karistir") >0)
            {
               // GlobalVariables.karistirmaHakki = PlayerPrefs.GetInt("karistir");
                karistir();
            }
          
            kalanHak();
            

        }
       
    }

    void karistir()
    {
        GlobalVariables.levelegorebasladi = true;
        GlobalVariables.karistir = true;
        
        PlayerPrefs.SetInt("karistir", PlayerPrefs.GetInt("karistir")-1);


    }
    void kalanHak()
    {
        this.GetComponentInChildren<Text>().text = "Shuffle (" + PlayerPrefs.GetInt("karistir") + ")";
        
    }
    void yanlisSes()
    {
        audYanlis.Play();
    }

   


}
