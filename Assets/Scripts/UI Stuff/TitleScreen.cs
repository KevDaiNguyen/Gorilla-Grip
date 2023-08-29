using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
