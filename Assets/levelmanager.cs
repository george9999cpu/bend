using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;   // set by Checkpoint.cs when touched
    public Transform player;               // drag your Player here in Inspector
    public Transform defaultSpawn;         // optional: drag a start point here

    public void RespawnPlayer()
    {
        if (player == null)
        {
            Debug.LogError("LevelManager: Player reference not set.");
            return;
        }

        Vector3 targetPos;
        if (CurrentCheckpoint != null)
            targetPos = CurrentCheckpoint.transform.position;
        else if (defaultSpawn != null)
            targetPos = defaultSpawn.position;
        else
        {
            Debug.LogWarning("LevelManager: No checkpoint/defaultSpawn set.");
            return;
        }

        // move player
        player.position = targetPos;

        // stop leftover velocity
        var rb = player.GetComponent<Rigidbody2D>();
        if (rb) rb.velocity = Vector2.zero;
    }
}

