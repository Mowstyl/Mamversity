using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject reference;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * offset;

        transform.position = player.transform.position + offset;

        //ubicar camara
        transform.LookAt(player.transform.position);

        //referencia para que los controladores no cmbien
        Vector3 copyRotation = new Vector3(0, transform.eulerAngles.y, 0);
        reference.transform.eulerAngles = copyRotation;

	}
}
