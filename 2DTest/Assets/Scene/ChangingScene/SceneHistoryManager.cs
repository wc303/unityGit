using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

//����һ��ȫ�ֹ����������ٳ����л���¼��ȷ���糡����

public class SceneHistoryManager : MonoBehaviour
{
    // ����ʵ��
    public static SceneHistoryManager Instance { get; private set; }

    // ������ʷջ����¼�������ƣ�
    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // ������ʼ��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ��¼�������루�ڳ�������ʱ���ã�
    public void RecordSceneEntry(string sceneName)
    {
        sceneHistory.Push(sceneName);
    }

    // ������һ������
    public void GoBackToPreviousScene()
    {
        if (sceneHistory.Count >= 2)
        {
            // ������ǰ����
            sceneHistory.Pop();
            // ��ȡ��һ����������
            string previousScene = sceneHistory.Peek();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("û�пɷ��ص���һ��������");
        }
    }
}