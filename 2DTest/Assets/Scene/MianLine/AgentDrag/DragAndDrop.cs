using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject characterPrefab; // 角色Prefab
    public GameObject previewPrefab; // 角色预览Prefab

    public Tilemap placeableTilemap;   // 可放置的Tilemap层
    private GameObject previewInstance;
    private bool isValidPosition;

    public Color validColor = new Color(1, 1, 1, 0.5f);
    public Color invalidColor = new Color(1, 0, 0, 0.3f);

    private Sprite characterSprite;

    private bool isDragging;

    public  OperatorDragHandler operatorDragHandler;

    void Start()
    {
        // 从Prefab提取Sprite（只需执行一次）
        characterSprite = characterPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 创建纯视觉预览对象
        previewInstance = new GameObject("DragPreview");
        SpriteRenderer renderer = previewInstance.AddComponent<SpriteRenderer>();
        renderer.sprite = characterSprite;
        renderer.sortingOrder = 999; // 确保显示在最上层
        isDragging = true;
        Debug.Log("视觉对象创建");
    }


    public void OnDrag(PointerEventData eventData)
    {
        Time.timeScale = 0.1f;
        // 获取鼠标屏幕坐标（注意Z轴处理）
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = Camera.main.nearClipPlane + 1f; // 关键：确保深度在摄像机可见范围内

        // 转换为世界坐标并强制Z轴归零
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;

        // 转换为Tilemap坐标
        Vector3Int cellPos = placeableTilemap.WorldToCell(worldPos);
        Vector3 cellCenter = placeableTilemap.GetCellCenterWorld(cellPos);

        // 更新预览位置
        previewInstance.transform.position = cellCenter;

        // 检测是否可放置（新增范围校验）
        BoundsInt bounds = placeableTilemap.cellBounds;
        bool isWithinBounds = bounds.Contains(cellPos);
        isValidPosition = isWithinBounds && placeableTilemap.HasTile(cellPos);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("拖拽结束");
        if (isValidPosition && isDragging == true)
        {
            // 放置实际角色
            Instantiate(characterPrefab, previewInstance.transform.position, Quaternion.identity);
            isDragging = false;

            if (previewInstance != null)
            {
                Destroy(previewInstance);
                previewInstance = null; // 清除引用
                Debug.Log("删除预制体");
            } // 销毁预览

            if (operatorDragHandler != null)
            { operatorDragHandler.wasPlaced = true; }
            Debug.Log("删除图标");
            Destroy(this.gameObject);//直接删除图标
        }
        else 
        {
            if (previewInstance != null)
            {
                Destroy(previewInstance);
                previewInstance = null; // 清除引用
                Debug.Log("删除预制体");
            } // 销毁预览

        }
        Time.timeScale = 1.0f;
    }

}