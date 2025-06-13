using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float timer;
    private bool isTiming = false;

    public int scoreFinal;
    public int errorFinal;
    public float timerFinal;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI nbrItemText;
    public TextMeshProUGUI timeText;

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
        if (isTiming)
        {
            timer += Time.deltaTime;
            if (timeText != null)
            {
                timeText.text = "Temps : " + timer.ToString("F2") + "s";
            }
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
        GameManager.Instance.timerFinal = GameManager.Instance.GetFinalTime();
    }

    public float GetFinalTime()
    {
        return timer;
    }

    public void StartTimer()
    {
        timer = 0f;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    public void ReconnectUI()
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        errorText = GameObject.Find("ErrorText")?.GetComponent<TextMeshProUGUI>();
        nbrItemText = GameObject.Find("NbrItemText")?.GetComponent<TextMeshProUGUI>();
        timeText = GameObject.Find("TimeText")?.GetComponent<TextMeshProUGUI>();
    }

}
