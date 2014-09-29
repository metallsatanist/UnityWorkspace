﻿using UnityEngine;
using System.Collections;

public class ScreenRelativePosition : MonoBehaviour {


	public enum ScreenEdge {LEFT, RIGHT, TOP, BOTTOM};
	public ScreenEdge screenEdge;
	public float yOffset;
	public float xOffset;


	void Start () {
	
		Vector3 newPosition = transform.position;
		Camera cam = Camera.main;


		switch (screenEdge) {
		
		case ScreenEdge.RIGHT:
			newPosition.x = cam.aspect * cam.orthographicSize + xOffset;
			Debug.Log("Cam aspect: "+cam.aspect);
			Debug.Log("Cam Orth Size: "+cam.orthographicSize);
			Debug.Log("*: "+cam.orthographicSize* cam.aspect);
			Debug.Log("X: "+newPosition.x);

			newPosition.y = yOffset;
			break;
		case ScreenEdge.TOP:

			newPosition.y = cam.orthographicSize + yOffset;
			newPosition.x = xOffset;
			break;
		case ScreenEdge.LEFT:

			newPosition.x = -cam.aspect * cam.orthographicSize + xOffset ;
			newPosition.y = yOffset;
			break;
		case ScreenEdge.BOTTOM:

			newPosition.y = cam.orthographicSize + yOffset;
			newPosition.x = xOffset;

			break;
		}
	
		transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {

	}



}