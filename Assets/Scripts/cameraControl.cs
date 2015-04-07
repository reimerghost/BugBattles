using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;	
	}

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;
    Vector3 targetPos;
    private Transform target;

    public float moveSpeed = 2f;
    public float loopMax = 10f;
    public float loopMin = 0f;

    void FixedUpdate()
    {
        if (target && target.position.y > -0.79)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.position.z;
            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * 15f;
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}
