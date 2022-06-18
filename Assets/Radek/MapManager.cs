using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject play;
    [SerializeField] GameObject continueGame;

    [SerializeField] public bool prehistory;
    [SerializeField] public bool rome;
    [SerializeField] public bool ww2;
    [SerializeField] public bool sciFi;
    [SerializeField] TMPro.TextMeshPro puzzleHints;


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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);

        Debug.Log("start");
        SceneManager.LoadScene(1);
        play.SetActive(false);
        continueGame.SetActive(true);

        //panel.GetComponent<Image>().enabled = true;
    }

    public void Continue()
    {
        Debug.Log("continue");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ToogleMenu();
        panel.SetActive(false);

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
            Debug.Log(Cursor.lockState);

            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("esc");
            if(SceneManager.GetActiveScene().buildIndex!=0) ToogleMenu();
        }


    }

    private void ToogleMenu()
    {
        //if (GameObject.Find("PlayerCapsule"))
        //    GameObject.Find("PlayerCapsule").transform.Find("MainCamera").GetComponent<Cinemachine.CinemachineBrain>().enabled = panel.activeInHierarchy;
        if (GameObject.Find("PlayerCapsule"))
        {
            int value;
            if (GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>().RotationSpeed == 0) value = 1;
            else value = 0;

            //if (cursorStatus == false)
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //    Cursor.visible = true;
            //}
            //else
            //{
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;
            //}
            //cursorStatus = !cursorStatus;

            GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>().RotationSpeed = value;

        }
        if(panel.activeInHierarchy==false) panel.SetActive(true);


        //        panel.SetActive(!panel.activeInHierarchy);
        //                panel.SetActive(!panel.activeInHierarchy);
    }
    public void Load(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void UpdatePuzzleHint()
    {
        string txt="Odpowiedzi\n";
        if (prehistory)
        {
            txt += "Prehistoria: " + "" + "\n";
        }
        if (rome)
        {
            txt += "Rzym: " + "Data za³o¿enia rzymu: 04.753 p.n.e."+"\n";
        }
        if (ww2)
        {
            txt += "WW2: " + "" + "\n";
        }
        if (sciFi)
        {
            txt += "Sci-Fi: " + "" + "\n";
        }
    }

    public void ChangePrehistory()
    {
        prehistory = true;
        //UpdatePuzzleHint();
    }
    public void ChangeRome()
    {
        rome = true;
        //UpdatePuzzleHint();
    }
    public void ChangeWW2()
    {
        ww2 = true;
        //UpdatePuzzleHint();
    }
    public void ChangeSciFi()
    {
        sciFi = true;
        //UpdatePuzzleHint();
    }





}
