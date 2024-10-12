using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Tausta
    public GameObject player;
    public GameObject[] background;
    private Vector2 spawnPos;
    private Vector2 spawnKoristeet;
    private Vector2 spawnEsteet;
    private float toimi = -7;
    private int tausta = 0;
    private float muutos = 300; //Muutetaan kun tiedetaan
    private float voitto = 10000; //Muutetaan kun tiedetaan
    private float loppu = 10015; //Muutetaan kun tiedetaan

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

        if (toimi < voitto)
        {
            if (transform.position.x > toimi)
            {
                int esteetIndex = Random.Range(0, esteet.Length);
                int koristeetIndex = Random.Range(0, koristeet.Length);
                int randomi1 = Random.Range(15, 30);
                int randomi2 = Random.Range(30, 50);
                int randomi3 = Random.Range(51, 60);

                spawnPos = new Vector2(player.transform.position.x + 54, -0.05f);
                spawnEsteet = new Vector2(player.transform.position.x + randomi1, -2);
                spawnKoristeet = new Vector2(player.transform.position.x + randomi2, -2);

                Instantiate(background[tausta], spawnPos, background[tausta].transform.rotation);

                Instantiate(esteet[esteetIndex], spawnEsteet, esteet[esteetIndex].transform.rotation);
                Instantiate(koristeet[koristeetIndex], spawnKoristeet, koristeet[koristeetIndex].transform.rotation);

                spawnEsteet = new Vector2(player.transform.position.x + randomi3, -2);
                Instantiate(esteet[esteetIndex], spawnEsteet, esteet[esteetIndex].transform.rotation);
                toimi = toimi + 50;

            }

            if (toimi > muutos)
            {
                tausta++;
                muutos = muutos * 2;
            }
        }

        //Viimene tausta
        if (toimi > voitto)
        {
            spawnPos = new Vector2(player.transform.position.x + 54, -0.05f);
            Instantiate(background[tausta], spawnPos, background[tausta].transform.rotation);

        }




    }
    
}
