using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragController : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5f;
    [SerializeField] private float pickupForce = 150f;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    [SerializeField] private Transform holdArea;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

/*
        //* show popup if draggable 
        RaycastHit hit2;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit2, pickupRange)){
            if(hit2.transform.CompareTag("draggable")){
                //hit2.transform.FindChild("Canvas").gameObject.SetActive(true);
                hit2.transform.Find("Canvas").gameObject.SetActive(true);

            }
        }
        */
/*
        //if(Input.GetMouseButtonDown(0)){
            if(heldObject == null ){
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange)){
                    if(hit.transform.CompareTag("draggable")){
                        //hit.transform.Find("Canvas").gameObject.SetActive(true); //show popup
                        if(Input.GetKeyDown(KeyCode.E)){
                        PickUpObject(hit.transform.gameObject);
                        }
                        else{
                            DropObject();
                        }
                    }
                    else{
                        //hit.transform.Find("Canvas").gameObject.SetActive(false); //hide popup
                    }
                }
            }
            //else{
              //  DropObject();
            //}
        //}

        if(heldObject != null){
            MoveObject();
        }

     */  
/*
        if(heldObject == null ){
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange)){
                if(hit.transform.CompareTag("draggable")){
                    if(Input.GetKeyDown(KeyCode.E)){
                        PickUpObject(hit.transform.gameObject);
                        }
                        else{
                            DropObject();
                        }
                    }
                }
            }

        if(heldObject != null){
            MoveObject();
        }
        */

        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("XD");
            if(heldObject == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange)){
                    if(hit.transform.CompareTag("draggable")){
                        PickUpObject(hit.transform.gameObject);
                    }
                    if(hit.transform.CompareTag("UI"))
                    {
                        Debug.Log("test");
                    }
                    
                }
            }
            else {
                DropObject();

            }

        }
        if(heldObject != null){
            MoveObject();
        }






    }
    void PickUpObject(GameObject pickObj){
        if(pickObj.GetComponent<Rigidbody>()){
            heldObjectRb = pickObj.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false;
            heldObjectRb.drag = 10;
            heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjectRb.transform.parent = holdArea;
            heldObject = pickObj;
        }
    }


    void DropObject(){

        heldObjectRb.useGravity = true;
        heldObjectRb.drag = 1;
        heldObjectRb.constraints = RigidbodyConstraints.None;

        heldObjectRb.transform.parent = null;
        heldObject = null;

    }

    void MoveObject(){

        if(Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f){
            Vector3 moveDirection = (holdArea.position -heldObject.transform.position);
            heldObjectRb.AddForce(moveDirection * pickupForce);
        }


    }
    
}
