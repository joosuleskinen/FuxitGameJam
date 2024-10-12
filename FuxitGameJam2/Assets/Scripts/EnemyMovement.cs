using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float Speed = 7.0f;
    private float MinDistance = 3.0f;
    private float SpeedModifier;
    private float DistanceToPlayer;
    public GameObject Player;
    
    // Start is called before the first frame update
    void FixedUpdate()
    {
        SpeedModifier = MinDistance / 10;
        DistanceToPlayer = Vector2.Distance(Player.transform.position, transform.position);
        Debug.Log(DistanceToPlayer);

        if (DistanceToPlayer < MinDistance)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed * SpeedModifier);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed * (DistanceToPlayer / 10));
        }
    }

    // Update is called once per frame
  
}
