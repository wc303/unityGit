using UnityEngine;
using UnityEngine.UI;

//挂载在返回按钮上，可以返回上一场景

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
