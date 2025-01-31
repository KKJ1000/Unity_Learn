using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private DateTime sessionStartTime;
    private DateTime sessionEndTime;

    void Start()
    {
        sessionStartTime = DateTime.Now;
        Debug.Log("Game session start 0: " + DateTime.Now);
    }

    void OnApplicationQuit()
    {
        sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = sessionEndTime.Subtract(sessionStartTime);
        Debug.Log("Game session ended 0: " + DateTime.Now);
        Debug.Log("Game session lasted: " + timeDifference);
    }

    void OnGUI()
    {
        if (GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
