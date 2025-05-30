using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(RectTransform), (typeof(CanvasGroup)))]
public class OperatorDragHandler : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // ���ò���
    [Header("References")]
    public Canvas rootCanvas;          // ��Canvas
    public Transform originalParent;   // ԭʼ�������Զ���ȡ��

    [Header("Settings")]
    public float returnDuration = 0.3f; // ��λ����ʱ��
    public float dragAlpha = 0.6f;      // ��קʱ͸����

    // ����ʱ״̬
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private int originalSiblingIndex;
    public bool wasPlaced;
    private Vector3 originalScale; // ������¼ԭʼ����

    public void Start()
    {
        rootCanvas=FindObjectOfType<Canvas>();
        // ��¼��ʼ����ֵ
        originalScale = transform.localScale;

    }
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent; // �Զ���¼��ʼ����
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ��¼��ʼ״̬
        originalSiblingIndex = transform.GetSiblingIndex();
        originalPosition = rectTransform.anchoredPosition;

        // ��ʱ������Canvas�㼶
        transform.SetParent(rootCanvas.transform, true);
        transform.SetAsLastSibling();

        // �Ӿ�Ч������
        canvasGroup.alpha = dragAlpha;
        canvasGroup.blocksRaycasts = false;

        wasPlaced = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ��������ƶ�������Canvas���ţ�
        rectTransform.anchoredPosition += eventData.delta / rootCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!wasPlaced)
        {
            StartCoroutine(SmoothReturn());
        }
    }

    private IEnumerator SmoothReturn()
    {
        Debug.Log("Ӧ����λ");
        // ��һ�����ָ�������ϵ
        transform.SetParent(originalParent, false);
        transform.SetSiblingIndex(originalSiblingIndex);
        //����ֵ��λ
        transform.localScale = originalScale;
        // �ڶ�����ǿ��ˢ�²���
        LayoutRebuilder.ForceRebuildLayoutImmediate(originalParent.GetComponent<RectTransform>());

        // ��������ƽ������
        float elapsed = 0f;
        Vector2 currentPos = rectTransform.anchoredPosition;

        while (elapsed < returnDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(
                currentPos,
                originalPosition,
                elapsed / returnDuration
            );
            elapsed += Time.deltaTime;
            yield return null;
        }

        // ���ն�λ
        rectTransform.anchoredPosition = originalPosition;
    }

    public void MarkAsPlaced() => wasPlaced = true;
}