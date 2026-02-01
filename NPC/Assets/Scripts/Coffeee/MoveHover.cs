using UnityEngine;
using UnityEngine.EventSystems;

public class MoveHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverOffset;
    public float moveSpeed;

    private Vector3 originalPos;
    private Vector3 targetPos;

    void Start()
    {
        originalPos = transform.position;
        targetPos = originalPos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetPos = originalPos + hoverOffset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetPos = originalPos;
    }
}
