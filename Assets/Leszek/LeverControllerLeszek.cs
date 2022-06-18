using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeverControllerLeszek : MonoBehaviour
{
    [SerializeField] private int currentPosition;
    [SerializeField]
    private Animation animationLever;
    [SerializeField]
    private Animation animationBookshelf;
    [SerializeField] GameObject portal;
    
    void Start()
    {
        currentPosition = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangePosition();
        }
    }

    public void ChangePosition()
    {
        if (currentPosition == 0)
        {
            //set current pos as a 1

            animationLever.Play();
            currentPosition = 1;
            animationBookshelf.Play();
            MapManager.Instance.ChangeWW2();
            portal.SetActive(true);
            // transform.rotation.eulerAngles.x
            //transform.rotation = Quaternion.Euler(-45,0,0);
        }

    }
}
