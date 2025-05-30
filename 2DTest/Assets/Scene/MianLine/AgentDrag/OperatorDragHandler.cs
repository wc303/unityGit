using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(RectTransform), (typeof(CanvasGroup)))]
public class OperatorDragHandler : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 配置参数
    [Header("References")]
    public Canvas rootCanvas;          // 主Canvas
    public Transform originalParent;   // 原始父级（自动获取）

    [Header("Settings")]
    public float returnDuration = 0.3f; // 归位动画时长
    public float dragAlpha = 0.6f;      // 拖拽时透明度

    // 运行时状态
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private int originalSiblingIndex;
    public bool wasPlaced;
    private Vector3 originalScale; // 新增记录原始缩放

    public void Start()
    {
        rootCanvas=FindObjectOfType<Canvas>();
        // 记录初始缩放值
        originalScale = transform.localScale;

    }
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent; // 自动记录初始父级
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 记录初始状态
        originalSiblingIndex = transform.GetSiblingIndex();
        originalPosition = rectTransform.anchoredPosition;

        // 临时提升到Canvas层级
        transform.SetParent(rootCanvas.transform, true);
        transform.SetAsLastSibling();

        // 视觉效果设置
        canvasGroup.alpha = dragAlpha;
        canvasGroup.blocksRaycasts = false;

        wasPlaced = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 跟随鼠标移动（考虑Canvas缩放）
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
        Debug.Log("应当归位");
        // 第一步：恢复父级关系
        transform.SetParent(originalParent, false);
        transform.SetSiblingIndex(originalSiblingIndex);
        //缩放值归位
        transform.localScale = originalScale;
        // 第二步：强制刷新布局
        LayoutRebuilder.ForceRebuildLayoutImmediate(originalParent.GetComponent<RectTransform>());

        // 第三步：平滑动画
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

        // 最终定位
        rectTransform.anchoredPosition = originalPosition;
    }

    public void MarkAsPlaced() => wasPlaced = true;
}