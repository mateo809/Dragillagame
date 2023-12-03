using UnityEngine;
using TMPro;

public class PlayerTextDisplay2 : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public string displayText = "Hello, Player!";

    void Start()
    {
        if (textMesh == null)
        {
            Debug.LogError("TextMesh component not assigned. Please assign a TextMesh component.");
            return;
        }

        textMesh.text = displayText;
    }

    void LateUpdate()
    {
        UpdateTextPosition();
    }

    void UpdateTextPosition()
    {
        if (textMesh != null)
        {
            
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

           
            textMesh.rectTransform.position = screenPos + new Vector3(0, 50, 0); 
        }
    }
}
