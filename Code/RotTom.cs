using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTom : MonoBehaviour
{
    public GameObject BasketObj;
    public float speed = -4.5f;
    public Rigidbody2D rottom;
    void Start()
    {
        InvokeRepeating("SpawnRottom",0.5f, 1);
    }
    void Update() {}

    void SpawnRottom()
    {
        Instantiate(rottom, new Vector3(Random.Range(-6, 6), 7, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
