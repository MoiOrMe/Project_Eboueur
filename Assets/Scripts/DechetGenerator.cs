using UnityEngine;

public class DechetGenerator : MonoBehaviour
{
    public GameObject[] dechetPrefabs; // Liste des d�chets � g�n�rer
    public Transform spawnPoint;       // Point d�apparition

    private GameObject currentDechet;  // R�f�rence au d�chet actuel

    void Update()
    {
        // Si aucun d�chet en sc�ne, en g�n�rer un nouveau
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
