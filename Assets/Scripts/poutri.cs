using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class poutri : MonoBehaviour
{
    public string acceptedTag;
    public static int score = 0;
    public static int error = 0;
    public static int nbObjetsTries = 0; // Compteur global de tri correct

    public Renderer boutonRenderer;
    public Material materialCorrect;
    public Material materialIncorrect;
    private Material originalMaterial;

    public GameObject texteCorrect;
    public GameObject texteIncorrect;

    public AudioSource audioSource;
    public AudioClip sonCorrect;
    public AudioClip sonIncorrect;
    public AudioClip sonFin; // Son à jouer quand les 10 objets sont triés

    void Start()
    {
        if (boutonRenderer != null)
            originalMaterial = boutonRenderer.material;

        if (texteCorrect != null) texteCorrect.SetActive(false);
        if (texteIncorrect != null) texteIncorrect.SetActive(false);
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
                StartCoroutine(ShowText(texteCorrect));
                PlaySound(sonCorrect);

                Destroy(other.gameObject);

            }
            else
            {
                score -= 1;
                error += 1;
                StartCoroutine(FlashButtonMaterial(materialIncorrect));
                StartCoroutine(ShowText(texteIncorrect));
                PlaySound(sonIncorrect);

                Destroy(other.gameObject);

            }

            nbObjetsTries += 1;
            if (nbObjetsTries >= 10)
            {
                StartCoroutine(ChangementDeScene());
            }
        }
    }

    private IEnumerator FlashButtonMaterial(Material tempMaterial)
    {
        if (boutonRenderer != null && tempMaterial != null)
        {
            boutonRenderer.material = tempMaterial;
            yield return new WaitForSeconds(1f);
            boutonRenderer.material = originalMaterial;
        }
    }

    private IEnumerator ShowText(GameObject textObj)
    {
        if (textObj != null)
        {
            textObj.SetActive(true);
            yield return new WaitForSeconds(1f);
            textObj.SetActive(false);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private IEnumerator ChangementDeScene()
    {
        GameManager.Instance.EnregistrerScore(score, error);
        PlaySound(sonFin);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("end");
    }
}
