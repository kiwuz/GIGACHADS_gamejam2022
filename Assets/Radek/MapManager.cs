using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject play;
    [SerializeField] GameObject continueGame;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        play.SetActive(false);
        continueGame.SetActive(true);
    }

    public void Continue()
    {

    }



    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
        }


    }

    private void ToogleMenu()
    {
//        panel.SetActive(!panel)
    }

}
