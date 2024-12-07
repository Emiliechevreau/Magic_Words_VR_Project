using UnityEngine;

public class ChildGame : MonoBehaviour
{
    public GameObject[] sunPlacementZones;  // Zones for SUN
    public GameObject[] snowPlacementZones; // Zones for SNOW
    public GameObject[] cloudPlacementZones; // Zones for CLOUD

    private int currentLevel = 0; // 0 = SUN, 1 = SNOW, 2 = CLOUD

    void Start()
    {
        ActivateCurrentLevelZones();
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
            Debug.Log("Great job! You completed the current level.");
            AdvanceToNextLevel();
        }
        else
        {
            Debug.Log("Keep trying, not all cubes are placed correctly.");
        }
    }

    private void AdvanceToNextLevel()
    {
        currentLevel++;

        if (currentLevel < 3) // We have three levels: SUN, SNOW, CLOUD
        {
            Debug.Log("Proceeding to the next level...");
            ActivateCurrentLevelZones();
        }
        else
        {
            Debug.Log("Congratulations! You've completed all levels!");
        }
    }

    private void ActivateCurrentLevelZones()
    {
        // Deactivate all zones
        DeactivateZones(sunPlacementZones);
        DeactivateZones(snowPlacementZones);
        DeactivateZones(cloudPlacementZones);

        // Activate zones for the current level
        GameObject[] currentZones = GetCurrentZones();
        foreach (GameObject zone in currentZones)
        {
            zone.SetActive(true);
        }
    }

    private void DeactivateZones(GameObject[] zones)
    {
        foreach (GameObject zone in zones)
        {
            zone.SetActive(false);
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
}