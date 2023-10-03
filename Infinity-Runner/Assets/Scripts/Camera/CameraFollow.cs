using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    public float offSet; 
    [SerializeField] private float camSpeed; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void LateUpdate()
    {

        Vector3 newCamPosition = new Vector3(player.position.x + offSet, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPosition, camSpeed * Time.deltaTime); //vector3.Slerp retorna um vector 3 entre dois objetos na cena


    }
}
