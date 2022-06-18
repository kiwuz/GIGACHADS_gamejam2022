using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteMessage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text Text;
    private Color startcolor;

    void OnMouseEnter()
    {
        Text.gameObject.SetActive(true);
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        Text.gameObject.SetActive(false);
        GetComponent<Renderer>().material.color = startcolor;
    }
}
