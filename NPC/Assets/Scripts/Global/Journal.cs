using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Journal", menuName = "Scriptable Objects/Journal")]
public class Journal : ScriptableObject
{

    [SerializeField] private string journalName;
    [SerializeField] private bool isJournalCustomized = false;
    
    [Header("Journal Entries")]
    [SerializeField] private List<string> clues = new List<string>();
    
    [SerializeField] private bool isEyeActive = false;
    
    // Static instance for easy access across scenes
    private static Journal instance;
    public static Journal Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Loading Journal from Resources...");
                instance = Resources.Load<Journal>("Journal");
                if (instance == null)
                {
                    Debug.LogError("Journal ScriptableObject not found in Resources folder!");
                }
                else
                {
                    Debug.Log($"Journal loaded successfully. Current skin: '{instance.journalName}', Customized: {instance.isJournalCustomized}");
                }
            }
            return instance;
        }
    }
    
    public string JournalName 
    { 
        get 
        { 
            Debug.Log($"Getting JournalName: '{journalName}'");
            return journalName; 
        } 
    }
    public bool IsEyeActive => isEyeActive;
    public int TotalClues => clues.Count;
    public bool IsCustomized => isJournalCustomized;
    
    /// <summary>
    /// Sets the journal skin. Can only be called once during customization.
    /// Valid options: "Coffee", "Default", "Fly"
    /// </summary>
    public void SetJournalSkin(string skinName)
    {
        Debug.Log($"SetJournalSkin called with: '{skinName}', Currently customized: {isJournalCustomized}");
        
        if (!isJournalCustomized)
        {
            // Validate skin name matches available skins
            if (skinName == "Coffee" || skinName == "Default" || skinName == "Fly")
            {
                string oldName = journalName;
                journalName = skinName;
                isJournalCustomized = true;
                Debug.Log($"Journal skin changed from '{oldName}' to '{journalName}' - Customized: {isJournalCustomized}");
                
                // Force save the ScriptableObject
                #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
                #endif
            }
            else
            {
                Debug.LogError($"Invalid journal skin: {skinName}. Valid options are: Coffee, Default, Fly");
            }
        }
        else
        {
            Debug.LogWarning("Journal skin has already been set and cannot be changed.");
        }
        {
            Debug.LogWarning("Journal skin has already been set and cannot be changed.");
        }
}
    
    /// <summary>
    /// Gets the path to the selected journal skin texture.
    /// </summary>
    public string GetSkinTexturePath()
    {
        return $"JournalSkins/{journalName}";
    }
    
    /// <summary>
    /// Adds a new clue to the journal.
    /// </summary>
    public void AddClue(string clue)
    {
        if (!string.IsNullOrEmpty(clue) && !clues.Contains(clue))
        {
            clues.Add(clue);
            Debug.Log($"Added clue: {clue}");
        }
    }
    
    /// <summary>
    /// Gets all current clues as an array.
    /// </summary>
    public string[] GetClues()
    {
        return clues.ToArray();
    }
    
    /// <summary>
    /// Gets a specific clue by index.
    /// </summary>
    public string GetClue(int index)
    {
        if (index >= 0 && index < clues.Count)
        {
            return clues[index];
        }
        return null;
    }
    
    /// <summary>
    /// Removes a clue by index.
    /// </summary>
    public void RemoveClue(int index)
    {
        if (index >= 0 && index < clues.Count)
        {
            string removedClue = clues[index];
            clues.RemoveAt(index);
            Debug.Log($"Removed clue: {removedClue}");
        }
    }
    
    /// <summary>
    /// Removes a clue by content.
    /// </summary>
    public void RemoveClue(string clue)
    {
        if (clues.Remove(clue))
        {
            Debug.Log($"Removed clue: {clue}");
        }
    }
    
    /// <summary>
    /// Modifies an existing clue. Only available when the eye is active.
    /// </summary>
    public void ModifyClue(int index, string newClue)
    {
        if (isEyeActive && index >= 0 && index < clues.Count)
        {
            string oldClue = clues[index];
            clues[index] = newClue;
            Debug.Log($"Modified clue from '{oldClue}' to '{newClue}'");
        }
        else if (!isEyeActive)
        {
            Debug.LogWarning("Cannot modify clues when the eye is not active.");
        }
    }
    
    /// <summary>
    /// Activates or deactivates the eye functionality.
    /// </summary>
    public void SetEyeActive(bool active)
    {
        isEyeActive = active;
        Debug.Log($"Eye is now {(active ? "active" : "inactive")}");
    }
    
    /// <summary>
    /// Clears all clues from the journal.
    /// </summary>
    public void ClearClues()
    {
        clues.Clear();
        Debug.Log("All clues cleared from journal.");
    }
    
    /// <summary>
    /// Checks if the journal contains a specific clue.
    /// </summary>
    public bool HasClue(string clue)
    {
        return clues.Contains(clue);
    }
    
    /// <summary>
    /// Legacy method for compatibility
    /// </summary>
    public int GetTotalEntries()
    {
        return clues.Count;
    }
    
    private void OnEnable()
    {
        // Ensure this instance persists across scene loads
        if (instance == null)
        {
            instance = this;
        }
    }
}
