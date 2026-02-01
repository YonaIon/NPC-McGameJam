using UnityEngine;

/// <summary>
/// Simple static class to hold the skin choice across scenes.
/// This persists as long as the game is running.
/// </summary>
public static class JournalSkinData
{
    private static string _chosenSkin = "";
    
    public static string ChosenSkin
    {
        get
        {
            Debug.Log($"[JournalSkinData] GET ChosenSkin: '{_chosenSkin}'");
            return _chosenSkin;
        }
        set
        {
            Debug.Log($"[JournalSkinData] SET ChosenSkin: '{value}' (was: '{_chosenSkin}')");
            _chosenSkin = value;
        }
    }
    
    public static bool HasChosenSkin => !string.IsNullOrEmpty(_chosenSkin);
}
