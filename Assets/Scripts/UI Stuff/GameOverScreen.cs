using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = 0;

        if (Input.GetKeyDown(KeyCode.A))
        {
            ToTitleScreen();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Retry();
        }
    }


    public void ToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainGame");
    }
}
