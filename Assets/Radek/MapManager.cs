using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject play;
    [SerializeField] GameObject continueGame;

    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }



    public void StartGame()
    {
        ToogleMenu();
        Debug.Log("start");
        SceneManager.LoadScene(1);
        play.SetActive(false);
        continueGame.SetActive(true);

    }

    public void Continue()
    {
        Debug.Log("continue");

        ToogleMenu();
    }



    public void ExitGame()
    {
        Debug.Log("quit");

        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("esc");
            if(SceneManager.GetActiveScene().buildIndex!=0) ToogleMenu();
        }


    }

    private void ToogleMenu()
    {
        if (GameObject.Find("PlayerFollowCamera"))
            GameObject.Find("PlayerFollowCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>().enabled = panel.activeInHierarchy;
        panel.SetActive(!panel.activeInHierarchy);
    }
    public void Load(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
