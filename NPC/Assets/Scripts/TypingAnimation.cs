using System.Collections;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class TypewriterEffect : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    [SerializeField] private float typingSpeed = 0.05f; // Time delay 
    [SerializeField] private string fullText;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            StartCoroutine(TypeText(fullText));
        }
    }

    IEnumerator TypeText(string fullText)
    {
        // Set the text component's text to the full text
        textComponent.text = fullText;
        // Set the number of visible characters to 0 initially
        textComponent.maxVisibleCharacters = 0;

        // Loop through each character
        for (int i = 0; i <= fullText.Length; i++)
        {
            // Update the maximum visible characters
            textComponent.maxVisibleCharacters = i;
            // Wait for the specified typing speed before the next character
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
