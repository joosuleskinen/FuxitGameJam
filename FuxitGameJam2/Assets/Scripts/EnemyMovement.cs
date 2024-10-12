using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 7.0f;
    public float MinDistance = 10.0f;
    private float SpeedModifier;
    private float DistanceToPlayer;
    public Rigidbody2D Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpeedModifier = MinDistance / 10;
        DistanceToPlayer = Vector2.Distance(Player.transform.position, transform.position);
        Debug.Log(DistanceToPlayer);


        if (DistanceToPlayer < MinDistance)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed*SpeedModifier);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed * (DistanceToPlayer / 10));
        }
    }
}
