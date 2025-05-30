using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void FirstLogIn()
    {
        SceneManager.LoadScene("LogInScene");
    }
    public void LogIn()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void TurnToShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
