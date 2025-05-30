using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManage : MonoBehaviour
{
    private float gameTime;
    private bool isTiming = false;

    private void Start()
    {
        // 场景加载时开始计时
        StartTimer();
    }

    public void StartTimer()
    {
        gameTime = Time.time;
        isTiming = true;
    }

    public float GetCurrentTime()
    {
        return isTiming ? Time.time - gameTime : 0f;
    }

    // 离开场景时停止计时（可选）
    private void OnDestroy()
    {
        isTiming = false;
    }
}
