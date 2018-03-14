using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform trackObj;
    [SerializeField] private float xOffset;

    private float originalY;
    private float originalZ;

    private void Start() {
        originalY = transform.position.y;
        originalZ = transform.position.z;
    }

    void LateUpdate () {
        transform.position = new Vector3(trackObj.transform.position.x + xOffset, originalY, originalZ);
	}
}
