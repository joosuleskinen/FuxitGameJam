using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Tausta
    public GameObject player;
    public GameObject background;
    private Vector2 spawnPos;
    private Vector2 spawnKoristeet;
    private float toimi = -7;

    //Esteet
    public GameObject[] esteet;

    //Koristeet
    public GameObject[] koristeet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

          

            if (transform.position.x > toimi)
            {
            int esteetIndex = Random.Range(0, esteet.Length);
            int koristeetIndex = Random.Range(0, koristeet.Length);
            spawnPos = new Vector2(player.transform.position.x+40, 0);
            spawnKoristeet = new Vector2(player.transform.position.x + 35, 0.64f);
            Instantiate(background, spawnPos, background.transform.rotation);
            Instantiate(esteet[esteetIndex], spawnPos, esteet[esteetIndex].transform.rotation );
            Instantiate(koristeet[koristeetIndex], spawnPos, koristeet[koristeetIndex].transform.rotation);
            toimi = toimi + 20;
            
            }

            
       
    }
    
}
