using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghostPrefab;   // drag the GhostEnemy prefab here
    public Transform spawnPos;       // where the ghost will appear

    private bool spawned = false;    // prevents multiple spawns

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!spawned && other.CompareTag("Player"))
        {
            Instantiate(ghostPrefab, spawnPos.position, Quaternion.identity);
            spawned = true;
        }
    }
}
