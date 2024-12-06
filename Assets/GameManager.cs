using System.Collections.Generic;
using UnityEngine;

public class WordGameManager : MonoBehaviour
{
    // Le mot à valider
    private string wordToMatch = "CLOUD";

    // Liste des cubes de lettres (drag & drop dans l'éditeur)
    public List<GameObject> letter;

    // Bouton de validation
    public GameObject validateButton;

    private void Start()
    {
        UpdateWordUI();
    }

    // Vérifie si le mot formé est correct
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

    // Récupère le mot formé par les cubes dans l'ordre
    private string GetCurrentWord()
    {
        string formedWord = "";

        // Parcourt les cubes pour récupérer les lettres
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

    // Termine le jeu une fois le mot validé
    private void EndGame()
    {
        Debug.Log("End of the game, congratulations!");
        validateButton.SetActive(false); // Désactive le bouton de validation
    }

    // Met à jour l'interface avec le mot à créer
    private void UpdateWordUI()
    {
        Debug.Log($"Word to create: {wordToMatch}");
    }
}
