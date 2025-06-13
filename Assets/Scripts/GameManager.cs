using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int scoreFinal;
    public int errorFinal;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI nbrItemText;

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + poutri.score;
        }
        if (errorText != null) 
        {
            errorText.text = "Error : " + poutri.error;
        }
        if (nbrItemText != null)
        {
            nbrItemText.text = "Item trié : " + poutri.nbObjetsTries;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnregistrerScore(int score, int error)
    {
        scoreFinal = score;
        errorFinal = error;
    }
}
