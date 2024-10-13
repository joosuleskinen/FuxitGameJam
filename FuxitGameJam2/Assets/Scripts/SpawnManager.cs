using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    private float muutos = 143; //Muutetaan kun tiedetaan taii 858
    private float voitto = 715; //Muutetaan kun tiedetaan
    private bool apua = true;

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

        if (toimi < voitto && apua ==true)
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

            //Ei tomi, pitäis rikkoo turhat pois
            if (gameObject.transform.position.x < player.transform.position.x - 120)
            {
                Destroy(gameObject);
            }

            if (toimi > muutos)
            {
                tausta++;
                muutos = muutos +143;
            }
            if (toimi > voitto)
            {
                apua =false;
            }
        }

        //Viimene tausta

        if (apua == false)
        {
            spawnPos = new Vector2(player.transform.position.x + 140, -0.05f);
            Instantiate(background[9], spawnPos, background[9].transform.rotation);
            spawnPos = new Vector2(player.transform.position.x + 125, -0.05f);
            Instantiate(background[8], spawnPos, background[8].transform.rotation);
            spawnPos = new Vector2(player.transform.position.x + 125, -0.05f);
            Instantiate(background[7], spawnPos, background[7].transform.rotation);
            spawnPos = new Vector2(player.transform.position.x + 97, -0.05f);
            Instantiate(background[6], spawnPos, background[6].transform.rotation);
            spawnPos = new Vector2(player.transform.position.x + 85, -0.05f);
            Instantiate(background[5], spawnPos, background[5].transform.rotation);

            
            apua= true;
        }

    }
    
}
