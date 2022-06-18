using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player")&&MapManager.Instance.rome)
        {
            MapManager.Instance.Load(1);
        }
    }
}
