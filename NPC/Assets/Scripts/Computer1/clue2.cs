using UnityEngine;


public class clue2 : MonoBehaviour
{
    public void UpdateClue()
    {
        string draftArticle = 
        "Journal Clue – Draft Article\n\n" +
        "A draft article notes that employees leave the company for “great opportunities” but rarely return.\n\n" +
        "Rumors mention financial pressures and management practices.\n\n" +
        "The author attempts to reveal these patterns but leaves the piece unfinished.";

        Journal.Instance.AddClue(draftArticle);
    }
}
