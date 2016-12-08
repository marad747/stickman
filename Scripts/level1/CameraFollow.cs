using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    public static CameraFollow instance;
    public GameObject target;
    public float damping = 1.5f;

    void Awake () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {

        if (target != null) {
            Vector3 currentPosition = Vector3.Lerp(new Vector3(transform.position.x,1f,-10),new Vector3(target.transform.position.x + damping,1f,-10),damping * Time.deltaTime);
            transform.position = currentPosition;
        }

    }
}
