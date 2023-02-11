using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamFOV : MonoBehaviour
{
    Camera cam;
    // Awake is called before the first frame update
    void Awake()
    {
        cam= GetComponent<Camera>();
        float FOV = PlayerPrefs.GetFloat("FOV");
		if (FOV == 0) { PlayerPrefs.SetFloat("FOV", 80); }
		cam.fieldOfView = FOV;
    }

    // Update is called once per frame
    void Update()
    {
		float FOV = PlayerPrefs.GetFloat("FOV");
		cam.fieldOfView = FOV;
	}
}
