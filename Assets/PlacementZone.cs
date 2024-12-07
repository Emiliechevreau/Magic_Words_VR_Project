using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementZone : MonoBehaviour
{
    public string expectedLetter; // La lettre attendue pour cette zone
    private bool isCorrect = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Cube cube = other.GetComponent<Cube>();
            if (cube != null && cube.letter == expectedLetter)
            {
                Debug.Log($"Correct cube '{cube.letter}' placed in zone '{expectedLetter}'");
                isCorrect = true;

                // Verrouiller la position du cube
                other.transform.position = transform.position;
                other.GetComponent<Rigidbody>().isKinematic = true; // Désactiver la physique
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Cube cube = other.GetComponent<Cube>();
            if (cube != null && cube.letter == expectedLetter)
            {
                Debug.Log($"Cube '{cube.letter}' removed from zone '{expectedLetter}'");
                isCorrect = false;

                // Réactiver la physique si le cube sort de la zone
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }
}