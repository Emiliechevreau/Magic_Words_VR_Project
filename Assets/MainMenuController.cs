using UnityEngine;
using UnityEngine.SceneManagement;  // Nécessaire pour charger une scène

public class MainMenuController : MonoBehaviour
{
    // Cette fonction sera appelée lorsqu'on clique sur le bouton
    public void StartGame()
    {
        // Charge la scène principale (assure-toi que la scène est ajoutée à la Build Settings)
        SceneManager.LoadScene("Emilie Room"); // Remplace "MainScene" par le nom exact de ta scène principale
    }
}