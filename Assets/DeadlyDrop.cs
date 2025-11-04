using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyDrop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Lake trigger hit by: {other.name}, tag: {other.tag}");
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<levelmanager>().RespawnPlayer();
            Debug.Log("Hit lake → Respawn");
        }
    }
}
