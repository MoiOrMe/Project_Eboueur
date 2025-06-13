using UnityEngine;

public class ReconnectGameManagerUI : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ReconnectUI();
        }
    }
}
