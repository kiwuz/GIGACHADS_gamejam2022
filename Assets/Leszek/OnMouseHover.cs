using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseHover : MonoBehaviour
{
    [SerializeField]
    private Text Text;
    private Color startcolor;
    [SerializeField]
    private Canvas canvas;
    [SerializeField] GameObject Player;
    [SerializeField] private float pickupRange = 5f;
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
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Wcisnalem F");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                if (hit.transform.CompareTag("Enigma"))
                {
                    Player.gameObject.SetActive(false);
                    Debug.Log("Du[a");
                    canvas.enabled = true;

                }
            }
        }
    }
   

}
