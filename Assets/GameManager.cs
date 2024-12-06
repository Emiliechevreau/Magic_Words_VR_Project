using System.Collections.Generic;
using UnityEngine;

public class WordGameManager : MonoBehaviour
{
    // Le mot � valider
    private string wordToMatch = "CLOUD";

    // Liste des cubes de lettres (drag & drop dans l'�diteur)
    public List<GameObject> letter;

    // Bouton de validation
    public GameObject validateButton;

    private void Start()
    {
        UpdateWordUI();
    }

    // V�rifie si le mot form� est correct
    public void ValidateWord()
    {
        string formedWord = GetCurrentWord();

        if (formedWord == wordToMatch)
        {
            Debug.Log("Correct word! You completed the word 'CLOUD'.");
            EndGame();
        }
        else
        {
            Debug.Log("Wrong word, try again!");
        }
    }

    // R�cup�re le mot form� par les cubes dans l'ordre
    private string GetCurrentWord()
    {
        string formedWord = "";

        // Parcourt les cubes pour r�cup�rer les lettres
        foreach (GameObject cube in letter)
        {
            Letter letterCube = cube.GetComponent<Letter>();
            if (letterCube != null)
            {
                formedWord += letterCube.letter;
            }
        }

        return formedWord;
    }

    // Termine le jeu une fois le mot valid�
    private void EndGame()
    {
        Debug.Log("End of the game, congratulations!");
        validateButton.SetActive(false); // D�sactive le bouton de validation
    }

    // Met � jour l'interface avec le mot � cr�er
    private void UpdateWordUI()
    {
        Debug.Log($"Word to create: {wordToMatch}");
    }
}
