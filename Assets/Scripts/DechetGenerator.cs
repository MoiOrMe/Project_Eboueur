using UnityEngine;

public class DechetGenerator : MonoBehaviour
{
    public GameObject[] dechetPrefabs; // Liste des déchets à générer
    public Transform spawnPoint;       // Point d’apparition

    private GameObject currentDechet;  // Référence au déchet actuel

    void Update()
    {
        // Si aucun déchet en scène, en générer un nouveau
        if (currentDechet == null)
        {
            SpawnRandomDechet();
        }
    }

    void SpawnRandomDechet()
    {
        if (dechetPrefabs.Length == 0) return;

        int index = Random.Range(0, dechetPrefabs.Length);
        GameObject prefab = dechetPrefabs[index];

        currentDechet = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
