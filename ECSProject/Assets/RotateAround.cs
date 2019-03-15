using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateAround : MonoBehaviour {

    public GameObject Cube;
    public float speed;

    public float xDist;
    public float zDist;
    public float distance;
    private void Start()
    {
       
        speed = 0.01f/((Cube.transform.position.magnitude - transform.position.magnitude)*(Time.deltaTime*0.1f));
        



        Debug.Log("xDist: " + xDist + "  "+"zDist: "+zDist);
    }


    private void Update()
    {
        transform.RotateAround(Cube.transform.position, Vector3.up, speed /** Time.deltaTime*/);
    }
}
