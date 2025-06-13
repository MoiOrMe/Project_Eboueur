using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class DechetLabel : MonoBehaviour
{
    public GameObject texte;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        if (texte != null)
            texte.SetActive(false);

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        AfficherTexte();
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        MasquerTexte();
    }

    public void AfficherTexte()
    {
        if (texte != null)
            texte.SetActive(true);
    }

    public void MasquerTexte()
    {
        if (texte != null)
            texte.SetActive(false);
    }
}
