using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeverController : MonoBehaviour
{
    [SerializeField] private int currentPosition;
    private Animator m_animator;
    [SerializeField] private Text text;
    private GameManager GM;
    public AudioClip leverSwitch;
    void Start()
    {
        currentPosition = 0;
        m_animator = transform.GetComponent<Animator>(); 
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition(){
        
        if(currentPosition == 0){

             
            m_animator.SetTrigger("LeverON");
            currentPosition = 1;
            text.text = "1";
            GM.CheckText();
            AudioSource.PlayClipAtPoint(leverSwitch,this.transform.position,100f);

        }
        else if(currentPosition == 1){
            currentPosition = 0;
            m_animator.SetTrigger("LeverOFF");
            currentPosition = 0;
            text.text = "0";
            GM.CheckText();
            AudioSource.PlayClipAtPoint(leverSwitch,this.transform.position,100f);


        }
    }
}
