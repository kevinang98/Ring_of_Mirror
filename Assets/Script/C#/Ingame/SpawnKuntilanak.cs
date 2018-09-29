using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnKuntilanak : MonoBehaviour
{

    public Transform[] patrolPoint;
    public Transform currentPatrolPoints;
    public int currentPatrolIndexs;
    public Transform KuntiPrefab;
    public Transform spawnPoint;
    public bool musuh;
    public float spawn = 1;

    void Start()
    {
        currentPatrolIndexs = 0;
        currentPatrolPoints = patrolPoint[currentPatrolIndexs];   
    }

    public void spawnKunti()
    {
        Instantiate(KuntiPrefab);
    }

    void Update()
    {
        currentPatrolPoints = patrolPoint[currentPatrolIndexs];
        musuh = FindObjectOfType<Movement>().enemy;

        if (musuh == true && spawn == 1)
        {
            spawnKunti();
            spawn++;
        }
    }
}