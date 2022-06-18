using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnLoad : MonoBehaviour
{
    [SerializeField] GameObject portalPrehistory;
    [SerializeField] GameObject portalRome;
    [SerializeField] GameObject portalWW2;
    [SerializeField] GameObject portalSciFi;


    // Start is called before the first frame update
    void Start()
    {

            if (MapManager.Instance.prehistory)
            {
            //Debug.Log(GameObject.Find("Prehistory"));
            //GameObject.Find("Prehistory").transform.Find("Torus.004").gameObject.SetActive(false);
            portalPrehistory.SetActive(false);
        }
            if (MapManager.Instance.rome)
            {
            portalRome.SetActive(false);
        }
            if (MapManager.Instance.ww2)
            {
            portalWW2.SetActive(false);
        }
            if (MapManager.Instance.sciFi)
            {
            portalSciFi.SetActive(false);
        }
    }

}
