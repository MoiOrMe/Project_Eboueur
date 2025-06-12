using UnityEngine;
using System.Collections;

public class poutri : MonoBehaviour
{
    public string acceptedTag;              // Tag accept� : "Verre", "Alimentaire", "Emballage"
    public static int score = 0;

    public Renderer boutonRenderer;         // Renderer du bouton � colorer
    public Material materialCorrect;        // Mat�riau vert
    public Material materialIncorrect;      // Mat�riau rouge

    private Material originalMaterial;      // Mat�riau initial du bouton

    void Start()
    {
        if (boutonRenderer != null)
            originalMaterial = boutonRenderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag == "Verre" || tag == "Alimentaire" || tag == "Emballage")
        {
            if (tag == acceptedTag)
            {
                score += 1;
                StartCoroutine(FlashButtonMaterial(materialCorrect));
                Destroy(other.gameObject);
            }
            else
            {
                score -= 1;
                StartCoroutine(FlashButtonMaterial(materialIncorrect));
            }
        }
    }

    private IEnumerator FlashButtonMaterial(Material tempMaterial)
    {
        if (boutonRenderer != null && tempMaterial != null)
        {
            boutonRenderer.material = tempMaterial;
            yield return new WaitForSeconds(0.5f);
            boutonRenderer.material = originalMaterial;
        }
    }
}
