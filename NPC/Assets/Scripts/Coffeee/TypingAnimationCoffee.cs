using System.Collections;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class TypewriterEffectCoffee : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    [SerializeField] private float typingSpeed = 0.05f; // Time delay 
    // [SerializeField] private string fullText;
    [SerializeField] private bool wait;

    IEnumerator Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.color = new Color(0.69f, 0.83f, 1f, 1f);
            string fullText = "Early morning, early coffee-";
            StartCoroutine(TypeText(fullText));

            yield return new WaitForSeconds(2.2f);
            textComponent.color = new Color(0.69f, 1f, 0.94f, 0.5f);
            textComponent.text = "We've got no time";

            yield return new WaitForSeconds(3f);
            textComponent.color = new Color(0.69f, 0.83f, 1f, 1f);
            string fullText2 = "Ahem, alright, coffee first. Now we can start!";
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
