using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private bool GameIsActive = true;

    public GameObject[] Objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StopStartGame()
    {
        for(int i = 0; i < Objects.Length;i++)
            Objects[i].SetActive(!Objects[i].active);
        if (GameIsActive)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        GameIsActive = !GameIsActive;
    }
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
                StopStartGame();
    }
}
