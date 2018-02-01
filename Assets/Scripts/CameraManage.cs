using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour {

	public List<Vector3>			positions;
	public List<Vector3>			rotations;

	public List<ParticleSystem>		menuPS;

	[HideInInspector]public int		step;
    private Camera					camera;

	// Use this for initialization
	void Start () {
		camera = transform.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (positions[step] - transform.position) / 10;
		transform.localEulerAngles = transform.localEulerAngles + (rotations[step] - transform.localEulerAngles) / 10;

		if (Input.GetKeyDown("1"))
			step = 0;
		if (Input.GetKeyDown("2"))
			step = 1;
		if (Input.GetKeyDown("3"))
			step = 2;

		if (step == 0)
		{
	        RaycastHit hit;
	        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
	        
	        if (Physics.Raycast(ray, out hit)) {
	            ParticleSystem objectHit = hit.transform.GetComponent<ParticleSystem>();
	            if (objectHit && !objectHit.isPlaying)
	            	objectHit.Play();
	            for (int i = 0 ; i < menuPS.Count ; i++)
	            {
	            	if ((!objectHit || menuPS[i] != objectHit) && menuPS[i].isPlaying)
	            	{
	            		menuPS[i].Stop();
	            		menuPS[i].Clear();
	            	}
	            }
	        }
		}
	}
}
