using UnityEngine;
using UnityEngine.UI;

public class ChildGame : MonoBehaviour
{
    public GameObject[] sunPlacementZones;  // Zones pour SUN
    public GameObject[] snowPlacementZones; // Zones pour SNOW
    public GameObject[] cloudPlacementZones; // Zones pour CLOUD

    private int currentLevel = 0; // 0 = SUN, 1 = SNOW, 2 = CLOUD

    // Références aux images
    public GameObject sunImage;
    public GameObject snowImage;
    public GameObject cloudImage;

    void Start()
    {
        ActivateCurrentLevelZones();
        UpdateLevelImage(); // Initialisation de l'image au démarrage
    }

    public void CheckLevelCompletion()
    {
        GameObject[] currentZones = GetCurrentZones();

        bool allCorrect = true;
        foreach (GameObject zone in currentZones)
        {
            PlacementZone placementZone = zone.GetComponent<PlacementZone>();
            if (!placementZone.IsCorrect())
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            AdvanceToNextLevel();
        }
        else
        {
            // Si le niveau n'est pas terminé correctement, rien ne se passe
        }
    }

    private void AdvanceToNextLevel()
    {
        currentLevel++;

        if (currentLevel < 3) // 3 niveaux : SUN, SNOW, CLOUD
        {
            ActivateCurrentLevelZones();
            UpdateLevelImage(); // Mise à jour de l'image lorsque passage au niveau suivant
        }
        else
        {
            // Logique quand le jeu est terminé, si nécessaire
        }
    }

    private void ActivateCurrentLevelZones()
    {
        // Activer uniquement les zones pour le niveau actuel
        GameObject[] currentZones = GetCurrentZones();
        foreach (GameObject zone in currentZones)
        {
            zone.SetActive(true);
        }
    }

    private GameObject[] GetCurrentZones()
    {
        switch (currentLevel)
        {
            case 0: return sunPlacementZones;
            case 1: return snowPlacementZones;
            case 2: return cloudPlacementZones;
            default: return new GameObject[0];
        }
    }

    // Fonction pour changer l'image en fonction du niveau
    private void UpdateLevelImage()
    {
        switch (currentLevel)
        {
            case 0:
                sunImage.SetActive(true);
                snowImage.SetActive(false);
                cloudImage.SetActive(false);
                break;

            case 1:
                sunImage.SetActive(false);
                snowImage.SetActive(true);
                cloudImage.SetActive(false);
                break;

            case 2:
                sunImage.SetActive(false);
                snowImage.SetActive(false);
                cloudImage.SetActive(true);
                break;

            default:
                break;
        }
    }
}