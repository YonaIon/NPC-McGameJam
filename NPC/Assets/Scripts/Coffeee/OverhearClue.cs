using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; // Use this if you are using TextMesh Pro



public class OverhearClue : MonoBehaviour, IPointerClickHandler {

    [SerializeField] private GameObject secret;


    public void OnPointerClick(PointerEventData eventData)
    {
        secret.SetActive(false);

        Journal.Instance.Clue1Added = true;
        
        // Debug: Check how many clues are now in the journal
        Debug.Log($"Journal now has {Journal.Instance.TotalClues} clues");
    }
}
