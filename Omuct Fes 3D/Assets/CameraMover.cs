using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public void MoveCamera(Vector3 targetPos,Vector3 cameraVec,float distance){
        RaycastHit hit;
        if(Physics.Raycast(targetPos,cameraVec,out hit,distance)){
            this.transform.position=targetPos+cameraVec*hit.distance*0.9f;
        }else{
            this.transform.position=targetPos+cameraVec*distance;
        }

        this.transform.LookAt(targetPos);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
