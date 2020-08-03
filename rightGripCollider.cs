using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightGripCollider : MonoBehaviour
{
    public GameObject cube;
    public bool rightGripColliderBool;

    void Start()
    {

        cube = GameObject.Find("cube");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);

        if (other.tag == "cube")
        {
            rightGripColliderBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.tag);

        if (other.tag == "cube")
        {
            rightGripColliderBool = false;
        }
    }
}
