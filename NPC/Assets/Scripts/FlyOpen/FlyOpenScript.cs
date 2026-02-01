using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // For Text component
using TMPro; // For TextMeshPro component (if using TextMeshPro)

public class FlyOpenScript : MonoBehaviour
{
    public GameObject Clue1;
    public GameObject Clue2;
    public GameObject Clue3;
    
    private int lastClueCount = 0; // Track how many clues we've displayed
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Starter();
        lastClueCount = Journal.Instance.TotalClues; // Remember initial clue count
    }
    
    public void Starter()
    {
        // Check if Journal exists
        if (Journal.Instance == null)
        {
            Debug.LogError("Journal.Instance is null!");
            return;
        }
        
        // Hide all clues first (with null checks)
        if (Clue1 != null) Clue1.SetActive(false);
        if (Clue2 != null) Clue2.SetActive(false);
        if (Clue3 != null) Clue3.SetActive(false);
        
        // Check if muffled conversation clue exists - if yes, show Clue1
        bool hasClue1 = Journal.Instance.Clue1Added;
        if (Clue1 != null) Clue1.SetActive(hasClue1);
        
        // Check if draft article clue exists - if yes, show Clue2  
        bool hasClue2 = Journal.Instance.Clue2Added;
        if (Clue2 != null) Clue2.SetActive(hasClue2);
        
        // Check if clue3 exists - if yes, show Clue3 (when you add clue3)
        bool hasClue3 = Journal.Instance.Clue3Added;
        if (Clue3 != null) Clue3.SetActive(hasClue3);
        
        Debug.Log($"Clue flags - Clue1: {hasClue1}, Clue2: {hasClue2}, Clue3: {hasClue3}");
    }
    
    void Update()
    {
        // Check if new clues have been added
        if (Journal.Instance != null && Journal.Instance.TotalClues != lastClueCount)
        {
            Starter(); // Refresh the display
            lastClueCount = Journal.Instance.TotalClues; // Update our count
        }
    }
}
