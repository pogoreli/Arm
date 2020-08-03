using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftGripCollider : MonoBehaviour
{
    public GameObject cube;
    public bool leftGripColliderBool;

    void Start()
    {
        
        cube = GameObject.Find("cube");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);

        if (other.tag == "cube")
        {
            leftGripColliderBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.tag);

        if (other.tag == "cube")
        {
            leftGripColliderBool = false;
        }
    }
}
