using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject characterPrefab; // ��ɫPrefab
    public GameObject previewPrefab; // ��ɫԤ��Prefab

    public Tilemap placeableTilemap;   // �ɷ��õ�Tilemap��
    private GameObject previewInstance;
    private bool isValidPosition;

    public Color validColor = new Color(1, 1, 1, 0.5f);
    public Color invalidColor = new Color(1, 0, 0, 0.3f);

    private Sprite characterSprite;

    private bool isDragging;

    public  OperatorDragHandler operatorDragHandler;

    void Start()
    {
        // ��Prefab��ȡSprite��ֻ��ִ��һ�Σ�
        characterSprite = characterPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �������Ӿ�Ԥ������
        previewInstance = new GameObject("DragPreview");
        SpriteRenderer renderer = previewInstance.AddComponent<SpriteRenderer>();
        renderer.sprite = characterSprite;
        renderer.sortingOrder = 999; // ȷ����ʾ�����ϲ�
        isDragging = true;
        Debug.Log("�Ӿ����󴴽�");
    }


    public void OnDrag(PointerEventData eventData)
    {
        Time.timeScale = 0.1f;
        // ��ȡ�����Ļ���꣨ע��Z�ᴦ��
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = Camera.main.nearClipPlane + 1f; // �ؼ���ȷ�������������ɼ���Χ��

        // ת��Ϊ�������겢ǿ��Z�����
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;

        // ת��ΪTilemap����
        Vector3Int cellPos = placeableTilemap.WorldToCell(worldPos);
        Vector3 cellCenter = placeableTilemap.GetCellCenterWorld(cellPos);

        // ����Ԥ��λ��
        previewInstance.transform.position = cellCenter;

        // ����Ƿ�ɷ��ã�������ΧУ�飩
        BoundsInt bounds = placeableTilemap.cellBounds;
        bool isWithinBounds = bounds.Contains(cellPos);
        isValidPosition = isWithinBounds && placeableTilemap.HasTile(cellPos);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("��ק����");
        if (isValidPosition && isDragging == true)
        {
            // ����ʵ�ʽ�ɫ
            Instantiate(characterPrefab, previewInstance.transform.position, Quaternion.identity);
            isDragging = false;

            if (previewInstance != null)
            {
                Destroy(previewInstance);
                previewInstance = null; // �������
                Debug.Log("ɾ��Ԥ����");
            } // ����Ԥ��

            if (operatorDragHandler != null)
            { operatorDragHandler.wasPlaced = true; }
            Debug.Log("ɾ��ͼ��");
            Destroy(this.gameObject);//ֱ��ɾ��ͼ��
        }
        else 
        {
            if (previewInstance != null)
            {
                Destroy(previewInstance);
                previewInstance = null; // �������
                Debug.Log("ɾ��Ԥ����");
            } // ����Ԥ��

        }
        Time.timeScale = 1.0f;
    }

}