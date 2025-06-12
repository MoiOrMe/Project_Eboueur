using UnityEngine;

public class DechetGenerator : MonoBehaviour
{
    public GameObject[] dechetPrefabs; // Liste de prefabs de déchets
    public Transform spawnPoint;       // Position d’apparition

    private float spawnDelay = 0.1f;   // Délai fixe : 0.5 seconde
    private float timer;

    void Start()
    {
        timer = spawnDelay;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnRandomDechet();
            timer = spawnDelay;
        }
    }

    void SpawnRandomDechet()
    {
        if (dechetPrefabs.Length == 0) return;

        int index = Random.Range(0, dechetPrefabs.Length);
        GameObject prefab = dechetPrefabs[index];

        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
