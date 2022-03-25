using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float speed = -3.5f;
    public Rigidbody2D fruit;
    void Start()
    {
        InvokeRepeating("SpawnFruit", 1, 1);   
    }

    // Update is called once per frame
    void Update()
    {    
    }
    void SpawnFruit()
    {
        Instantiate(fruit, new Vector3(Random.Range(-6, 6), 7, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
