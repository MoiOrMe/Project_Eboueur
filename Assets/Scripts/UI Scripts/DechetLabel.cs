using UnityEngine;

public class DechetLabel : MonoBehaviour
{
    public GameObject texte; 

    private void Start()
    {
        if (texte != null)
            texte.SetActive(false); 
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
