using UnityEngine;
using UnityEngine.UI;

public class JournalDisplay : MonoBehaviour
{
    [Header("Placeholder")]
    public GameObject jourSkinPlaceholder;
    
    [Header("Journal Skin Images")]
    public GameObject coffeeImage;
    public GameObject defaultImage;
    public GameObject flyImage;

    void Start()
    {
        Debug.Log("=== JournalDisplay Start ===");
        ReplaceWithChosenSkin();
    }

    void ReplaceWithChosenSkin()
    {
        string chosenSkin = JournalSkinData.ChosenSkin;
        
        // Hide placeholder
        if (jourSkinPlaceholder != null)
            jourSkinPlaceholder.SetActive(false);

        // Hide all skin images first
        if (coffeeImage != null) coffeeImage.SetActive(false);
        if (defaultImage != null) defaultImage.SetActive(false);
        if (flyImage != null) flyImage.SetActive(false);

        // Check if a skin was chosen
        if (string.IsNullOrEmpty(chosenSkin))
        {
            Debug.LogWarning("No skin chosen - showing placeholder");
            if (jourSkinPlaceholder != null) jourSkinPlaceholder.SetActive(true);
            return;
        }

        // Show the correct image
        if (chosenSkin == "Coffee" && coffeeImage != null)
        {
            coffeeImage.SetActive(true);
            Debug.Log("SUCCESS: Coffee image active");
        }
        else if (chosenSkin == "Default" && defaultImage != null)
        {
            defaultImage.SetActive(true);
            Debug.Log("SUCCESS: Default image active");
        }
        else if (chosenSkin == "Fly" && flyImage != null)
        {
            flyImage.SetActive(true);
            Debug.Log("SUCCESS: Fly image active");
        }
        else
        {
            Debug.LogError($"Failed to show skin: '{chosenSkin}' - Image GameObjects may not be assigned!");
            if (jourSkinPlaceholder != null) jourSkinPlaceholder.SetActive(true);
        }
    }
}
