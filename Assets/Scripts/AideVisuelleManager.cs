using UnityEngine;

public class AideVisuelleManager : MonoBehaviour
{
    public static AideVisuelleManager Instance;

    public bool aideActive = true;

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

    public void ToggleAideVisuelle()
    {
        aideActive = !aideActive;
    }
}
