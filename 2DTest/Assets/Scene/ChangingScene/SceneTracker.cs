using UnityEngine;
using UnityEngine.SceneManagement;

//挂载到每个场景的 空对象 上（如 SceneTracker），用于在场景加载时通知管理器：
public class SceneTracker : MonoBehaviour
{
    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneHistoryManager.Instance.RecordSceneEntry(currentSceneName);
    }
}

