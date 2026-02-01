using UnityEngine;

public class FlyAnimation : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0); // move right
    public float speed = 300f;

    private RectTransform rectTransform;
    private bool isFlying;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartFlying()
    {
        Debug.Log("Fly started");
        gameObject.SetActive(true);
        isFlying = true;
    }

    void Update()
    {
        if (!isFlying) return;

        rectTransform.anchoredPosition += direction.normalized * speed * Time.deltaTime;
    }
}
