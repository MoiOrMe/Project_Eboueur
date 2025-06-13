using UnityEngine;

public class AideVisuelleManager : MonoBehaviour
{
    public static AideVisuelleManager Instance;

    public bool aideActive = true;
    public void ToggleAideVisuelle(bool isOn)
    {
        Debug.Log("Toggle reçu : " + isOn);
        aideActive = isOn;
    }

}
