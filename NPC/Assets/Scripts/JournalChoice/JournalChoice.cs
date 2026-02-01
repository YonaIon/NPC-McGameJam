using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class JournalChoice : MonoBehaviour
{
    public GameObject journalChoiceUI;
    public Button coffeeButton;
    public Button defaultButton;
    public Button flyButton;

    void Start()
    {
        if (coffeeButton != null)
            coffeeButton.onClick.AddListener(() => SelectJournalSkin("Coffee"));
        
        if (defaultButton != null)
            defaultButton.onClick.AddListener(() => SelectJournalSkin("Default"));
        
        if (flyButton != null)
            flyButton.onClick.AddListener(() => SelectJournalSkin("Fly"));
            
        // Check if journal is already customized
        if (Journal.Instance != null && Journal.Instance.IsCustomized)
        {
            // Hide the choice UI if already customized
            if (journalChoiceUI != null)
                journalChoiceUI.SetActive(false);
        }
    }

    public void LoadNextScene()
        {
            Debug.Log("Button Pressed");
            SceneManager.LoadScene("CoffeeScene");
        }

    public void OpenJournalChoice()
    {
        // Only open if journal hasn't been customized yet
        if (Journal.Instance != null && !Journal.Instance.IsCustomized)
        {
            journalChoiceUI.SetActive(true);
        }
        else
        {
            Debug.Log("Journal has already been customized.");
        }
    }
    
    /// <summary>
    /// Selects and permanently sets the journal skin
    /// </summary>
    public void SelectJournalSkin(string skinName)
    {
        if (Journal.Instance != null)
        {
            Journal.Instance.SetJournalSkin(skinName);
            
            if (journalChoiceUI != null)
                journalChoiceUI.SetActive(false);
                
            Debug.Log($"Journal skin '{skinName}' selected and set permanently.");
        }
        else
        {
            Debug.LogError("Journal instance not found!");
        }
    }
}
