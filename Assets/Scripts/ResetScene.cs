using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public string scenePrincipale = "Gestion de Déchets"; // Change-le selon ton projet

    public void RetourMenuEtReset()
    {
        // Reset des variables statiques
        poutri.score = 0;
        poutri.error = 0;
        poutri.nbObjetsTries = 0;

        // Reset GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.scoreFinal = 0;
            GameManager.Instance.errorFinal = 0;
            GameManager.Instance.timerFinal = 0;

            typeof(GameManager)
                .GetField("timer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(GameManager.Instance, 0f);

            typeof(GameManager)
                .GetField("isTiming", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(GameManager.Instance, false);
        }

        // Charger la scène principale
        SceneManager.LoadScene(scenePrincipale);
    }
}
