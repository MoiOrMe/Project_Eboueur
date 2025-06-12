using TMPro;
using UnityEngine;

public class AfficherScore : MonoBehaviour
{
    public TextMeshProUGUI texteScore;

    void Start()
    {
        if (texteScore != null)
        {
            int score = GameManager.Instance.scoreFinal;
            texteScore.text = "Score final : " + score.ToString();
        }
    }
}
