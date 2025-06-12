using UnityEngine;

public class poutri : MonoBehaviour
{
    public string acceptedTag; // "Verre", "Alimentaire" ou "Emballage"
    public static int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag == "Verre" || tag == "Alimentaire" || tag == "Emballage")
        {
            if (tag == acceptedTag)
            {
                score += 1;
                Destroy(other.gameObject);
            }
            else
            {
                score -= 1;
                Destroy(other.gameObject);
            }
        }
    }
}
