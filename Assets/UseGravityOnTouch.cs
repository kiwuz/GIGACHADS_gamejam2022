using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGravityOnTouch : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] string tagToCompare;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToCompare))
        {
            rigidbody.useGravity = true;
        }
    }

}
