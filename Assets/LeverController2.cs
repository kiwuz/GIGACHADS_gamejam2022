using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController2 : MonoBehaviour
{

    public Laser LSR;
    [SerializeField] private int currentPosition;
    [SerializeField] private GameObject light;
    private Animator m_animator;
    public AudioClip leverSwitch;



    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
        //LSR = transform.GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator = transform.GetComponent<Animator>(); 
    }

    public void ChangePosition(){
        
        if(currentPosition == 0){

             
            m_animator.SetTrigger("LeverON");
            currentPosition = 1;
            LSR.startLaser = true;
            light.SetActive(true);
            Debug.Log("Laser ON");
            AudioSource.PlayClipAtPoint(leverSwitch,this.transform.position,100f);
            


        }
        else if(currentPosition == 1){
            currentPosition = 0;
            m_animator.SetTrigger("LeverOFF");
            LSR.startLaser = false;
            Debug.Log("laser OFF");
            light.SetActive(false);
            AudioSource.PlayClipAtPoint(leverSwitch,this.transform.position,100f);

        }
    }


}
