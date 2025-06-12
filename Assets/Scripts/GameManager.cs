using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int scoreFinal;

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

    public void EnregistrerScore(int score)
    {
        scoreFinal = score;
    }
}
