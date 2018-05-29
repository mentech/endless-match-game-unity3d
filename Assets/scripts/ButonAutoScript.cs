using UnityEngine;



public class ButonAutoScript : MonoBehaviour {

    // Use this for initialization
    
   // Vector3 btnPosition = new Vector3();
    Vector3 btnPositionStop = new Vector3();


    
    void Start () {

        btnPositionStop = this.gameObject.transform.position -GlobalVariables.btnAnimePos;
        Invoke("yokEdici", GlobalVariables.btnAnimeTime);
	}
	
	// Update is called once per frame
	void Update () {


        if (this.gameObject.transform.position.x == btnPositionStop.x||this.gameObject.transform.position.x>btnPositionStop.x)
        {
        Vector3 spawnPos = this.gameObject.transform.position;
        
        spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x-3, 1* Time.deltaTime); 
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
        if (this.gameObject.transform.position.x == btnPositionStop.x || this.gameObject.transform.position.x > btnPositionStop.x)
        {
            Vector3 spawnPos = this.gameObject.transform.position;

            spawnPos.x = Mathf.Lerp(spawnPos.x, this.gameObject.transform.position.x - 3, 1 * Time.deltaTime);
            this.gameObject.transform.position = spawnPos;
        }
    }

    void yokEdici()
    {

        Destroy(this.gameObject);
        

    }



   




}
