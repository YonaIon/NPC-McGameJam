using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiceAnimation : MonoBehaviour
{
    [Header("UI")]
    public Button rollButton;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public TextMeshProUGUI diceText;

    [Header("Timing")]
    public float frameDelay = 0.2f;

    private void Start()
    {
        rollButton.onClick.AddListener(StartDiceAnimation);

        frame1.SetActive(false);
        frame2.SetActive(false);
        frame3.SetActive(false);
        diceText.gameObject.SetActive(false);
    }

    public void StartDiceAnimation()
    {
        rollButton.interactable = false;
        StartCoroutine(DiceRoutine());
    }

    private IEnumerator DiceRoutine()
    {
        frame1.SetActive(true);
        yield return new WaitForSeconds(frameDelay);

        frame1.SetActive(false);
        frame2.SetActive(true);
        yield return new WaitForSeconds(frameDelay);

        frame2.SetActive(false);
        frame3.SetActive(true);
        yield return new WaitForSeconds(frameDelay);

        frame3.SetActive(false);

        int diceValue = Random.Range(1, 5); // 1 to 4
        diceText.text = diceValue.ToString();
        diceText.gameObject.SetActive(true);
    }
}
