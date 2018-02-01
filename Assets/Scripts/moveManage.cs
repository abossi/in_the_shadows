using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveManage : MonoBehaviour {

	public List<Vector3>			positions;
	public List<Vector3>			rotations;

	public CameraManage				camManage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		int step = camManage.step;
		transform.localPosition = transform.localPosition + (positions[step] - transform.localPosition) / 10;
		transform.localEulerAngles = transform.localEulerAngles + (rotations[step] - transform.localEulerAngles) / 10;
	}
}
