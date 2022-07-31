using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ToThe(int main)
    {
        SceneManager.LoadScene(main);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
