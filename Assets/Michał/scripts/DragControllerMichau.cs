using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class DragControllerMichau : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5f;
    [SerializeField] private float pickupForce = 150f;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    [SerializeField] private Transform holdArea;
    private LeverController LC;
    void Start()
    {
        //LC = FindObjectOfType<LeverController>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E)){
            if(heldObject == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange)){
                    if(hit.transform.CompareTag("draggable")){
                        PickUpObject(hit.transform.gameObject);
                    }
                    if(hit.transform.CompareTag("Lever")){
                        hit.transform.GetComponent<LeverController>().ChangePosition();
                    }
                    if(hit.transform.CompareTag("Lever2")){
                        hit.transform.GetComponent<LeverController2>().ChangePosition();
                    }
                    if(hit.transform.CompareTag("Rotatable")){

                        //hit.transform.parent.Rotate(Vector3.forward, 90f);
                        Debug.Log(hit.transform.parent.rotation.z);
                        Debug.Log(hit.transform.rotation.z);
                        Debug.Log(hit.transform.parent.rotation.eulerAngles.z);


                        
                        if(hit.transform.parent.localRotation.eulerAngles.z % 90 == 0){
                            hit.transform.parent.DORotate(new Vector3(hit.transform.parent.rotation.eulerAngles.x,hit.transform.parent.rotation.eulerAngles.y, hit.transform.parent.rotation.eulerAngles.z+ 90),  0.5f,RotateMode.Fast);

                        }

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
