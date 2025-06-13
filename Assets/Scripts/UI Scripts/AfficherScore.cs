using TMPro;
using UnityEngine;

public class AfficherScore : MonoBehaviour
{
    public TextMeshProUGUI texteScore;
    public TextMeshProUGUI texteError;


    void Start()
    {
        if (texteScore != null)
        {
            int score = GameManager.Instance.scoreFinal;
            texteScore.text = "Score final : " + score.ToString();
        }
        if (texteError != null)
        {
            int error = GameManager.Instance.errorFinal;
            texteError.text = "Errors final : " + error.ToString();
        }
    }
}
