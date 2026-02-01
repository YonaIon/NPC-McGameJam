using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class EndingSceneRestart : MonoBehaviour
{
    public float textDelay = 1.5f;
    public float restartDelay = 6f;
    public GameObject wakeUpButton;

    private void Start()
    {
        Journal.Instance.ClearClues();
        StartCoroutine(PlayEnding());
    }

    public void OnWakeUpButtonClicked()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Startup");
    }

    private IEnumerator PlayEnding()
    {
        // Wait before showing text
        yield return new WaitForSeconds(textDelay);

        // Wait before restarting
        yield return new WaitForSeconds(restartDelay);

         yield return new WaitForSeconds(2);
        wakeUpButton.SetActive(true);

    }


}
