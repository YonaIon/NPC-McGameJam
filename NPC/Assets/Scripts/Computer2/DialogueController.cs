using System.Collections;
using UnityEngine;
using TMPro;
using System; // Required for TextMeshPro

public class DialogueController : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    [SerializeField] private float typingSpeed = 0.05f; // Time delay 
    [SerializeField] private string fullText;
    [SerializeField] private bool wait;

    IEnumerator Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.color = new Color(0.69f, 0.83f, 1f, 1f);
            string fullText = "Oh dear, we can’t have this getting out...";
            StartCoroutine(TypeText(fullText));

            yield return new WaitForSeconds(3f);
            String fullText2 = "I mean, because it’s not up to standard. I should start over.";
            StartCoroutine(TypeText(fullText2));
        }
    }


    IEnumerator TypeText(string fullText)
    {
        // Set the text component's text to the full text
        textComponent.text = fullText;
        // Set the number of visible characters to 0 initially
        textComponent.maxVisibleCharacters = 0;

        if (wait) {
            yield return new WaitForSeconds(7f);
        }
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
