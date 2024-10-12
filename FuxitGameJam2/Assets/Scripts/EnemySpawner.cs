using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject monster;
    private void OnTriggerExit2D(Collider2D collision)
    {
        monster.SetActive(true);
    }
}
