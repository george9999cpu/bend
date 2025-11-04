using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log($"Checkpoint trigger hit by: {other.name}, tag: {other.tag}");
    if (other.CompareTag("Player"))
    {
        FindObjectOfType<levelmanager>().CurrentCheckpoint = gameObject;
        Debug.Log("Checkpoint set to: " + name);
    }
}

}

