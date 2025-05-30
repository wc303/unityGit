using UnityEngine;
using UnityEngine.SceneManagement;

//���ص�ÿ�������� �ն��� �ϣ��� SceneTracker���������ڳ�������ʱ֪ͨ��������
public class SceneTracker : MonoBehaviour
{
    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneHistoryManager.Instance.RecordSceneEntry(currentSceneName);
    }
}

