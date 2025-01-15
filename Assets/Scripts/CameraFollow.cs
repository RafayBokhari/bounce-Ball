using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public int level1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            //Vector2 targetPosition = (Vector2)target.position + offset;
            //Vector2 smoothedPosition = Vector2.Lerp((Vector2)transform.position, targetPosition, smoothSpeed);
            //transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
            Vector3 desiredPosition = target.position + offset;
            if (level1 == 1)
            {
                desiredPosition.y = transform.position.y;
            }
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x,smoothedPosition.y,transform.position.z);

        }

    }
    
}
