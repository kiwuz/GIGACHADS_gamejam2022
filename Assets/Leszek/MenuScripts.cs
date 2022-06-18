using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{

    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Text Text;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Canvas doorCanvas;
    [SerializeField]
    private InputField doorText;
    [SerializeField]
    private Animation animation;
    [SerializeField]
    private GameObject lever;
    
    

    private void Start()
    {
        lever.SetActive(false);
        canvas.enabled = false;
        doorCanvas.enabled = false;

    }

    public void EnigmaChecker()
    {
        if (inputField.text == "mein fuhrer")
        {
            Text.text = "2137";
        }
        else
        {
            Debug.Log("KURWA ZLE");
        }
    }

    public void DoorChecker()
    {
        if (doorText.text == "200418892137")
        {
            animation.Play();
          
            disableDoors();
            lever.SetActive(true);
        }
        
    }

    public void disableEnigma()
    {
        canvas.enabled = false;
        Cursor.visible = false;
        //canvas.transform.localScale = Vector3.zero;


    }
    public void disableDoors()
    {
        doorCanvas.enabled = false;
        Cursor.visible = false;
        //doorCanvas.transform.localScale = Vector3.zero;



    }

}
