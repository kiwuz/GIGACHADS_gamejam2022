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
   

    private void Start()
    {
        canvas.enabled = false;

    }

    public void EnigmaChecker()
    {
        if (inputField.text == "mein fuhrer")
        {
            Text.text = "Tu bedzie haslo";
        }
        else
        {
            Debug.Log("KURWA ZLE");
        }
    }

    public void disableEnigma()
    {
        canvas.enabled = false;
       
    }

}
