using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowHighlighter : MonoBehaviour
{
    public XRRayInteractor rayInteractor;

    public GameObject flecheEmballage;
    public GameObject flecheVerre;
    public GameObject flecheAlimentaire;

    void Start()
    {
        rayInteractor.selectEntered.AddListener(OnGrab);
        rayInteractor.selectExited.AddListener(OnRelease);

        // Tout désactiver au démarrage
        DisableAllArrows();
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        GameObject grabbed = args.interactableObject.transform.gameObject;
        string tag = grabbed.tag;

        DisableAllArrows();

        switch (tag)
        {
            case "Emballage":
                flecheEmballage.SetActive(true);
                break;
            case "Verre":
                flecheVerre.SetActive(true);
                break;
            case "Alimentaire":
                flecheAlimentaire.SetActive(true);
                break;
            default:
                break; // Aucun affichage si le tag n'est pas reconnu
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        DisableAllArrows();
    }

    void DisableAllArrows()
    {
        flecheEmballage.SetActive(false);
        flecheVerre.SetActive(false);
        flecheAlimentaire.SetActive(false);
    }
}
