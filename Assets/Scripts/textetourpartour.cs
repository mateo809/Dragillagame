using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TemporaryText : MonoBehaviour
{
    public Text displayText;
    public float displayDuration = 5.0f;

    void Start()
    {
        // Assurez-vous que l'objet Text est assigné dans l'inspecteur Unity
        if (displayText == null)
        {
            Debug.LogError("Veuillez assigner l'objet Text dans l'inspecteur Unity.");
        }
    }

    // Méthode pour afficher un texte temporairement
    public void DisplayTemporaryText(string text)
    {
        StartCoroutine(ShowTextCoroutine(text));
    }

    // Coroutine pour afficher le texte temporairement
    IEnumerator ShowTextCoroutine(string text)
    {
        // Affiche le texte
        displayText.text = text;
        displayText.enabled = true;

        // Attend pendant la durée spécifiée
        yield return new WaitForSeconds(displayDuration);

        // Désactive le texte après la durée spécifiée
        displayText.enabled = false;
    }
}
