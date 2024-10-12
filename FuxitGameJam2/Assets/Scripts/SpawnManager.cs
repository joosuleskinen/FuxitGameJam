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
    private Vector2 spawnEsteet;
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
            int randomi1 = Random.Range(15, 30);
            int randomi2 = Random.Range(30, 50);
            int randomi3 = Random.Range(51, 60);

            spawnPos = new Vector2(player.transform.position.x+54, -0.05f);
            spawnEsteet = new Vector2(player.transform.position.x + randomi1, -2);
            spawnKoristeet = new Vector2(player.transform.position.x + randomi2, -2);

            Instantiate(background, spawnPos, background.transform.rotation);
            Instantiate(esteet[esteetIndex], spawnEsteet, esteet[esteetIndex].transform.rotation );
            Instantiate(koristeet[koristeetIndex], spawnKoristeet, koristeet[koristeetIndex].transform.rotation);

            spawnEsteet = new Vector2(player.transform.position.x + randomi3, -2);
            Instantiate(esteet[esteetIndex], spawnEsteet, esteet[esteetIndex].transform.rotation);
            toimi = toimi + 50;
            
            }

            
       
    }
    
}
