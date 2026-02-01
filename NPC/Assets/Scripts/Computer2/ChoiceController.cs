using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ChoiceController : MonoBehaviour
{
    [Header("UI")]
    public GameObject choicePanel;
    public Button rewriteButton;
    public Button noRewriteButton;

    [Header("Scenes")]
    public string endingScene1 = "Ending1";
    public string endingScene2 = "Ending2";

    [Header("Timing")]
    public float delayBeforeChoice = 6f;

    public void Start()
    {
        // hide choices at start
        choicePanel.SetActive(false);
        ShowChoicesAfterDelay();
    }

    public void ShowChoicesAfterDelay()
    {
        StartCoroutine(ShowChoicesRoutine());
    }

    private System.Collections.IEnumerator ShowChoicesRoutine()
    {
        yield return new WaitForSeconds(delayBeforeChoice);

        choicePanel.SetActive(true);

        rewriteButton.onClick.AddListener(ChooseRewrite);
        noRewriteButton.onClick.AddListener(ChooseNoRewrite);
    }

    private void ChooseRewrite()
    {
        choicePanel.SetActive(false);
        SceneManager.LoadScene(endingScene1);
    }

    private void ChooseNoRewrite()
    {
        choicePanel.SetActive(false);

        // Check if player has all required clues
        bool hasAll = Journal.Instance.TotalClues >= 3;

        Journal.Instance.ClearClues(); // reset journal

        if (hasAll)
            SceneManager.LoadScene(endingScene2);
        else
            SceneManager.LoadScene(endingScene1);
    }
}
