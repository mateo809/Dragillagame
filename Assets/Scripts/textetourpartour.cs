using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TemporaryText : MonoBehaviour
{
    public Text displayText;
    public float displayDuration = 5.0f;

    void Start()
    {
        // Assurez-vous que l'objet Text est assign� dans l'inspecteur Unity
        if (displayText == null)
        {
            Debug.LogError("Veuillez assigner l'objet Text dans l'inspecteur Unity.");
        }
    }

    // M�thode pour afficher un texte temporairement
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

        // Attend pendant la dur�e sp�cifi�e
        yield return new WaitForSeconds(displayDuration);

        // D�sactive le texte apr�s la dur�e sp�cifi�e
        displayText.enabled = false;
    }
}
