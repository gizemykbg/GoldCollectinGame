using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }

    public void SetDirection(string direction)
    {
        Vector3 temp = transform.rotation.eulerAngles;
        if(direction == "up")
        {
            offset = new Vector3(0.0f, 2.3f, -6.0f);
            temp.y = 0.0f;
        }
        else if (direction == "down")
        {
            offset = new Vector3(0.0f, 2.3f, 6.0f);
            temp.y = 180.0f;
        } else if (direction == "left")
        {
            offset = new Vector3(5.0f, 2.3f, 0.0f);
            temp.y = -90.0f;
        }
        else if (direction == "right")
        {
            offset = new Vector3(-5.0f, 2.3f, 0.0f);
            temp.y = 90.0f;
        }
        transform.rotation = Quaternion.Euler(temp);
    }
}



/* {
    public Transform target;
    private Vector3 offset;

    
    void Start()
    {
        offset = transform.position - target.position;
    }

    
    public void SetDirection()
    {
        Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,offset.z+target.position.z);
        transform.position = Vector3.Lerp(transform.position,newPosition,10*Time.deltaTime);
     }
} */




























/* 
 */