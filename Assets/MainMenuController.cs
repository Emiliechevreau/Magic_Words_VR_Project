using UnityEngine;
using UnityEngine.SceneManagement;  // N�cessaire pour charger une sc�ne

public class MainMenuController : MonoBehaviour
{
    // Cette fonction sera appel�e lorsqu'on clique sur le bouton
    public void StartGame()
    {
        // Charge la sc�ne principale (assure-toi que la sc�ne est ajout�e � la Build Settings)
        SceneManager.LoadScene("Emilie Room"); // Remplace "MainScene" par le nom exact de ta sc�ne principale
    }
}