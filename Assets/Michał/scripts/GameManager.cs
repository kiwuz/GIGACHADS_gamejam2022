using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text text4;
    [SerializeField] private Text text5;
    [SerializeField] private Text text6;
    [SerializeField] private Text text7;
    [SerializeField] private bool puzzle2;
    public bool puzzle1;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject lamp1;
    [SerializeField] private GameObject lamp2;

    [SerializeField] private GameObject lamp3;

    [SerializeField] private GameObject lamp4;




    // Start is called before the first frame update
    void Start()
    {
        puzzle1 = false;
        puzzle2 = false;
        portal.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzle1){
            lamp1.SetActive(true);
            lamp2.SetActive(true);
            lamp3.SetActive(true);
            lamp4.SetActive(true);
        }
        else if(!puzzle1){
            lamp1.SetActive(false);
            lamp2.SetActive(false);
            lamp3.SetActive(false);
            lamp4.SetActive(false);
        }
        if (puzzle2 && puzzle1){
            portal.SetActive(true);
            MapManager.Instance.ChangeSciFi();
        }
    }

    public void CheckText(){

        //if(text1.text.Equals(1) && text2.text.Equals(0) && text3.text.Equals(1) && text4.text.Equals(0) && text5.text.Equals(0) && text6.text.Equals(0) && text7.text.Equals(1)){//XDDD
        if(text1.text == "1" && text2.text == "0" && text3.text == "1" && text4.text == "0" && text5.text =="0" && text6.text == "0" && text7.text == "1"){
            Debug.Log("bin done");
            puzzle2 = true;
        }
        else puzzle2 = false;
        } 
    }
