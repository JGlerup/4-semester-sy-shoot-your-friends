using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class ObjectLabel : MonoBehaviour 

{

public Transform target1;  // Object that this label should follow
public Transform target2;  // Object that this label should follow
public Transform target3;  // Object that this label should follow
public Transform target4;  // Object that this label should follow
public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
public bool clampToScreen = false;  // If true, label will be visible even if object is off screen
public float clampBorderSize = 0.05f;  // How much viewport space to leave at the borders when a label is being clamped
public bool useMainCamera = true;   // Use the camera tagged MainCamera
public Camera cameraToUse ;   // Only use this if useMainCamera is false
Camera cam ;
Transform thisTransform;
Transform camTransform;

    void Start ()
    {
        thisTransform = transform;
    	if (useMainCamera)
        cam = Camera.main;
    else
        cam = cameraToUse;
    	camTransform = cam.transform;
    }

    void Update()
    {

        if (clampToScreen)
        {
			if(target1)
			{
            	Vector3 relativePosition = camTransform.InverseTransformPoint(target1.position);
            	relativePosition.z =  Mathf.Max(relativePosition.z, 1.0f);
            	thisTransform.position = cam.WorldToViewportPoint(camTransform.TransformPoint(relativePosition + offset));
            	thisTransform.position = new Vector3(Mathf.Clamp(thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize),
                                             Mathf.Clamp(thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize),
                                             thisTransform.position.z);
			}
			if(target2)
			{
            	Vector3 relativePosition = camTransform.InverseTransformPoint(target2.position);
            	relativePosition.z =  Mathf.Max(relativePosition.z, 1.0f);
            	thisTransform.position = cam.WorldToViewportPoint(camTransform.TransformPoint(relativePosition + offset));
            	thisTransform.position = new Vector3(Mathf.Clamp(thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize),
                                             Mathf.Clamp(thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize),
                                             thisTransform.position.z);
			}
			if(target3)
			{
            	Vector3 relativePosition = camTransform.InverseTransformPoint(target3.position);
            	relativePosition.z =  Mathf.Max(relativePosition.z, 1.0f);
            	thisTransform.position = cam.WorldToViewportPoint(camTransform.TransformPoint(relativePosition + offset));
            	thisTransform.position = new Vector3(Mathf.Clamp(thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize),
                                             Mathf.Clamp(thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize),
                                             thisTransform.position.z);
			}
			if(target4)
			{
            	Vector3 relativePosition = camTransform.InverseTransformPoint(target4.position);
            	relativePosition.z =  Mathf.Max(relativePosition.z, 1.0f);
            	thisTransform.position = cam.WorldToViewportPoint(camTransform.TransformPoint(relativePosition + offset));
            	thisTransform.position = new Vector3(Mathf.Clamp(thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize),
                                             Mathf.Clamp(thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize),
                                             thisTransform.position.z);
			}

        }
        else
        {
			if(target1)
            	thisTransform.position = cam.WorldToViewportPoint(target1.position);
			if(target2)
				thisTransform.position = cam.WorldToViewportPoint(target2.position + offset);
			if(target3)
				thisTransform.position = cam.WorldToViewportPoint(target3.position + offset);
			if(target4)
				thisTransform.position = cam.WorldToViewportPoint(target4.position + offset);
        }
    }
}
