using System.Collections;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class TypingAnimationCoffeeSecret : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    [SerializeField] private float typingSpeed = 0.07f; // Time delay 
    // [SerializeField] private string fullText;
    // [SerializeField] private bool wait;

    IEnumerator Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            yield return new WaitForSeconds(7f);

            string fullText = "Have you heard from them lately?";
            StartCoroutine(TypeText(fullText));

            yield return new WaitForSeconds(5f);
            string fullText2 = "No… but they said something about a new opportunity.";
            StartCoroutine(TypeText(fullText2));


            yield return new WaitForSeconds(7f);
            string fullText3 = "Yeah. Probably just busy.";
            StartCoroutine(TypeText(fullText3));
        }
    }

    IEnumerator TypeText(string fullText)
    {
        // Set the text component's text to the full text
        textComponent.text = fullText;
        // Set the number of visible characters to 0 initially
        textComponent.maxVisibleCharacters = 0;

        // if (wait) {
        //     yield return new WaitForSeconds(7f);
        // }
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
