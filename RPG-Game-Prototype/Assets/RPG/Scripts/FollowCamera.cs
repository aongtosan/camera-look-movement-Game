using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;
    private Vector3 m_offet;
    void Start()
    {
        m_offet = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!target){
            return;
        }
        float currentAngle = transform.eulerAngles.y;
        float targetAngle =  target.transform.eulerAngles.y;
        currentAngle = Mathf.Lerp(
            currentAngle,
            targetAngle,
            0.01f
        );
        transform.position = new Vector3(
            target.position.x,
            5.0f,
            target.position.z);
            Quaternion currentRotation = Quaternion.Euler(0,currentAngle,0);
            Vector3 rotatedPosition  = currentRotation * Vector3.forward; 
            transform.position -= rotatedPosition *10;
            transform.LookAt(target); 
    }
}
