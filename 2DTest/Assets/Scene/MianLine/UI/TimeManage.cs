using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManage : MonoBehaviour
{
    private float gameTime;
    private bool isTiming = false;

    private void Start()
    {
        // ��������ʱ��ʼ��ʱ
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

    // �뿪����ʱֹͣ��ʱ����ѡ��
    private void OnDestroy()
    {
        isTiming = false;
    }
}
