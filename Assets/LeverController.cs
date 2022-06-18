using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeverController : MonoBehaviour
{
    [SerializeField] private int currentPosition;
    private Animator m_animator;
    [SerializeField] private Text text;
    void Start()
    {
        currentPosition = 0;
        m_animator = transform.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition(){
        if(currentPosition == 0){
            //set current pos as a 1
             
            m_animator.SetTrigger("LeverON");
            currentPosition = 1;
            text.text = "1";
           // transform.rotation.eulerAngles.x
           //transform.rotation = Quaternion.Euler(-45,0,0);
        }
        else if(currentPosition == 1){
            //set bool as a 0
            currentPosition = 0;
            m_animator.SetTrigger("LeverOFF");
            currentPosition = 0;
            text.text = "0";
            //transform.rotation = Quaternion.Euler(45,0,0);

        }
    }
}
