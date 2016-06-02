using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour
{

    public GameObject car;
    public float spawnTime;
    public GameObject[] spawnPoints;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("spawnCar", spawnTime, spawnTime);
     }

    void spawnCar()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        if (spawnPoints[spawnIndex] != null)
        {
            Instantiate(car, spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
        }

    }
}
