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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Starter();
    }
    
    public void Starter()
    {
        Clue1.SetActive(false);
        Clue2.SetActive(false);
        Clue3.SetActive(false);
        
        for (int i = 0; i < Journal.Instance.TotalClues; i++)
        {
            string clueText = Journal.Instance.GetClue(i);
            
            if (i == 0) {
                Text textComponent1 = Clue1.GetComponent<Text>();
                if (textComponent1 != null) {
                    textComponent1.text = clueText;
                } else {
                    TextMeshProUGUI tmpComponent1 = Clue1.GetComponent<TextMeshProUGUI>();
                    if (tmpComponent1 != null) {
                        tmpComponent1.text = clueText;
                    }
                }
                Clue1.SetActive(true);
            }
            else if (i == 1) {
                Text textComponent2 = Clue2.GetComponent<Text>();
                if (textComponent2 != null) {
                    textComponent2.text = clueText;
                } else {
                    TextMeshProUGUI tmpComponent2 = Clue2.GetComponent<TextMeshProUGUI>();
                    if (tmpComponent2 != null) {
                        tmpComponent2.text = clueText;
                    }
                }
                Clue2.SetActive(true);
            }
            else if (i == 2) {
                Text textComponent3 = Clue3.GetComponent<Text>();
                if (textComponent3 != null) {
                    textComponent3.text = clueText;
                } else {
                    TextMeshProUGUI tmpComponent3 = Clue3.GetComponent<TextMeshProUGUI>();
                    if (tmpComponent3 != null) {
                        tmpComponent3.text = clueText;
                    }
                }
                Clue3.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
