using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class JournalDisplay : MonoBehaviour
{
    public Button coffeeButton;
    public Button defaultButton;
    public Button flyButton;

    void Start()
    {
        Debug.Log("=== JournalDisplay Start ===");
        ShowOnlySelectedButton();
    }

    void ShowOnlySelectedButton()
    {
        string chosenSkin = JournalSkinData.ChosenSkin;
        Debug.Log($"Chosen skin: {chosenSkin}");
        
        // Hide all buttons first
        if (coffeeButton != null) coffeeButton.gameObject.SetActive(false);
        if (defaultButton != null) defaultButton.gameObject.SetActive(false);
        if (flyButton != null) flyButton.gameObject.SetActive(false);
        
        // Show only the button for the selected skin
        if (chosenSkin == "Coffee" && coffeeButton != null)
        {
            coffeeButton.gameObject.SetActive(true);
        }
        else if (chosenSkin == "Default" && defaultButton != null)
        {
            defaultButton.gameObject.SetActive(true);
        }
        else if (chosenSkin == "Fly" && flyButton != null)
        {
            flyButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError($"Unknown or missing skin: '{chosenSkin}' - showing all buttons");
            // Fallback: show all buttons if something went wrong
            if (coffeeButton != null) coffeeButton.gameObject.SetActive(true);
            if (defaultButton != null) defaultButton.gameObject.SetActive(true);
            if (flyButton != null) flyButton.gameObject.SetActive(true);
        }
    }

    public void LoadCoffeeOpen()
    {
        Debug.Log("Coffee button clicked - Loading CoffeeOpen scene");
        SceneManager.LoadScene("CoffeeOpen");
    }

    public void LoadDefaultOpen()
    {
        Debug.Log("Default button clicked - Loading DefaultOpen scene");
        SceneManager.LoadScene("DefaultOpen");
    }

    public void LoadFlyOpen()
    {
        Debug.Log("Fly button clicked - Loading FlyOpen scene");
        SceneManager.LoadScene("FlyOpen");
    }
}
