using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ending2Controller : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI dialogueText;
    public Image animatedImage; // the image to animate
    public GameObject textBackground; // the panel or image behind dialogue


    [Header("Typing Settings")]
    public float typingSpeed = 0.05f;

    [Header("Fly")]
    public FlyAnimation flyScript; // drag the FlyAnimation script here


    // Dialogue lines with speaker
    private (string speaker, string line)[] dialogueLines = new (string, string)[]
    {
        ("Character", "I can’t stay quiet any longer. All this time, I’ve been… filtered. Controlled. The narrator decided what I see, what I say. And you’ve been here, watching it all."),
        ("Character", "I wanted to reveal everything. The truth about the company… about those who disappeared. About the pressure, the mistakes, the people who never returned."),
        ("Narrator", "No! You don’t understand! Stability is important! Chaos is dangerous! Some things aren’t meant to be revealed. They need order… control… structure!"),
        ("Character", "I don’t know if I can stop it… but you can decide what happens next. Will the truth be exposed, or kept hidden to maintain balance?")
    };

    private void Start()
    {
        dialogueText.text = "";
        StartCoroutine(RunDialogueSequence());
    }

    private IEnumerator RunDialogueSequence()
    {
        foreach (var (speaker, line) in dialogueLines)
        {
            // Set color based on speaker
            dialogueText.color = (speaker == "Narrator") 
                ? new Color(0.69f, 0.83f, 1f, 1f) // blue
                : new Color(0.69f, 1f, 0.94f, 1f); // green

            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(0.5f);
        }

        // After dialogue finishes, hide text and background
        if (dialogueText != null)
            dialogueText.gameObject.SetActive(false);

        if (textBackground != null)
            textBackground.SetActive(false);

        // After dialogue finishes, enable fly animation
        if (flyScript != null)
            flyScript.StartFlying(); // we’ll add this method
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        for (int i = 0; i <= line.Length; i++)
        {
            dialogueText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}
