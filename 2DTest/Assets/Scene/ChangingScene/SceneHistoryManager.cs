using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

//创建一个全局管理器来跟踪场景切换记录，确保跨场景存活：

public class SceneHistoryManager : MonoBehaviour
{
    // 单例实例
    public static SceneHistoryManager Instance { get; private set; }

    // 场景历史栈（记录场景名称）
    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // 单例初始化
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

    // 记录场景进入（在场景加载时调用）
    public void RecordSceneEntry(string sceneName)
    {
        sceneHistory.Push(sceneName);
    }

    // 返回上一个场景
    public void GoBackToPreviousScene()
    {
        if (sceneHistory.Count >= 2)
        {
            // 弹出当前场景
            sceneHistory.Pop();
            // 获取上一个场景名称
            string previousScene = sceneHistory.Peek();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("没有可返回的上一个场景！");
        }
    }
}