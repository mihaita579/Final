using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Destroyoncl : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(obj: gameObject);
        Destroy(other.gameObject);
        gameManager.UpdateScore(1);

    }

}


