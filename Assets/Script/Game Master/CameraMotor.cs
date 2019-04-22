using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    public Vector3 offset;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (player  == null)
        {
            transform.position = transform.position + offset;
        }
        else if(player != null)
        {
            transform.position = player.transform.position + offset;
        }
       
    }
}
