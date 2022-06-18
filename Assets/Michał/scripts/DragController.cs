using StarterAssets;
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
    private LeverController LC;
    void Start()
    {
        LC = FindObjectOfType<LeverController>();
    }

    // Update is called once per frame
    void Update()
    {

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
                        hit.transform.GetComponent<TMP_InputField>().ActivateInputField();
                        FindObjectOfType<Rotate>().enabled = false;
                        FindObjectOfType<FirstPersonController>().enabled = false;
                    }
                    if (hit.transform.CompareTag("Painting"))
                    {
                        Debug.Log("Obraz");
                        hit.collider.attachedRigidbody.useGravity = true;
                        Debug.Log(hit.collider.name);
                        //hit.rigidbody.useGravity = true;
                        PickUpObject(hit.transform.gameObject);

                    }
                    if(hit.transform.CompareTag("Lever")){
                        Debug.Log("test");
                        LC.ChangePosition();
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
