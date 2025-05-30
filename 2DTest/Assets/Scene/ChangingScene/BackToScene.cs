using UnityEngine;
using UnityEngine.UI;

//�����ڷ��ذ�ť�ϣ����Է�����һ����

public class BackToScene : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnBackButtonClick);
    }

    private void OnBackButtonClick()
    {
        SceneHistoryManager.Instance.GoBackToPreviousScene();
    }
}
