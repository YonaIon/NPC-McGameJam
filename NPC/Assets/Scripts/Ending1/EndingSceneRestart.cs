using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class EndingSceneRestart : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI endingText;

    [TextArea(5, 10)]
    public string endingMessage;

    [Header("Timing")]
    public float textDelay = 1.5f;
    public float restartDelay = 6f;

    [Header("Scenes")]
    public string firstSceneName = "Scene01";

    private void Start()
    {
        StartCoroutine(PlayEnding());
    }

    private IEnumerator PlayEnding()
    {
        // Wait before showing text
        yield return new WaitForSeconds(textDelay);

        // Wait before restarting
        yield return new WaitForSeconds(restartDelay);

        RestartGame();
    }

    private void RestartGame()
    {
        // Reset global data
        Journal.Instance.ClearClues();

        // Load first scene
        SceneManager.LoadScene(firstSceneName);
    }
}
