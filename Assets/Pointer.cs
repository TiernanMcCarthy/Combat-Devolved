using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public GameObject targetPosition;

    public GameObject pointer;

    public GameObject player;

    public GameObject example;

    public float north = 0;

    //private Vector3 

    public static float AngleDir(Vector3 fwd ,Vector3 targetDir,Vector3  up)
    {
        var perpen= Vector3.Cross(fwd,targetDir);

        float dir = Vector3.Dot(perpen, up);

        if (dir > 0.0f)
        {
            return 1.0f;
        }
        else if (dir < 0.0)
        {
            return -1.0f;
        }
        else
        {
            return 0.0f;
        }

        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos1 = new Vector2(pointer.transform.position.x, pointer.transform.position.z);
        Vector2 pos2 = new Vector2(targetPosition.transform.position.z, targetPosition.transform.position.z);


        example.transform.forward = targetPosition.transform.position-player.transform.position;

        /*
        //https://math.stackexchange.com/questions/1901229/finding-angle-between-one-point-and-another-point-with-ray
        Vector3 vectorToObjective = targetPosition.transform.position - player.transform.position;

        Vector3 playerToView = (player.transform.position + player.transform.forward * 50) - player.transform.position;

        float VectorToObjectiveMag = vectorToObjective.magnitude;
        float PlayerToViewMag = playerToView.magnitude;

        float dot=Vector3.Dot(vectorToObjective, playerToView);

        float temp = dot / (VectorToObjectiveMag * PlayerToViewMag);
        float angle = Mathf.Acos(temp);

        pointer.transform.localEulerAngles = new Vector3(pointer.transform.localEulerAngles.x, pointer.transform.localEulerAngles.y, angle*Mathf.Rad2Deg);
        */


        Vector3 vectorToObjective = targetPosition.transform.position - player.transform.position;

        vectorToObjective.y = 0;

        Vector3 playerToView = (player.transform.position + player.transform.forward) - player.transform.position;

        playerToView.y = 0;

        float VectorToObjectiveMag = vectorToObjective.magnitude;
        float PlayerToViewMag = playerToView.magnitude;

        float dot = Vector3.Dot(vectorToObjective, playerToView);

        float temp = dot / (VectorToObjectiveMag * PlayerToViewMag);
        float angle = Mathf.Acos(temp);


        Vector3 delta = targetPosition.transform.position - player.transform.position;
        Vector3 cross = Vector3.Cross(delta,player.transform.forward);
        float dot2 = Vector3.Dot(cross, Vector3.up);
        if (dot2 < 0)
        {
            // Do something
            angle *= -1;
        }
        else
        {
            // Do something else
        }
        Debug.Log(dot2);

        //Vector3 VectorResult;
        //Vector3 fakeforward = transform.forward;
        //fakeforward.y = 0;
        //float DotResult = Vector3.Dot(fakeforward, vectorToObjective.normalized); // good start
        //if (DotResult > 0)
        //{
        //     VectorResult = transform.forward + targetPosition.transform.forward;
        // }
        // else
        // {
        //     VectorResult = transform.forward - targetPosition.transform.forward;
        // }

        //if(DotResult<0)
        // {
        //     angle *= -1;//invert angle as it is on the left side of the player
        // }

        //Debug.Log(DotResult);
        



        pointer.transform.localRotation = Quaternion.Euler(pointer.transform.localEulerAngles.x, pointer.transform.localEulerAngles.y, angle * Mathf.Rad2Deg);

       


        //pointer.transform.localRotation = Quaternion.Euler(pointer.transform.localEulerAngles.x, pointer.transform.localEulerAngles.y, example.transform.localEulerAngles.x);

        //pointer.transform.rotation=example.transform.rotation;



        //pointer.transform.localEulerAngles = new Vector3(pointer.transform.localEulerAngles.x, pointer.transform.localEulerAngles.y, north - player.transform.localEulerAngles.y);





        //Vector3 targetDir = targetPosition.transform.position - player.transform.position - transform.forward * 500;
        //targetDir = targetDir.normalized;

        //float dot = Vector3.Dot(targetDir, player.transform.forward);
        //float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;


        //pointer.transform.localRotation = Quaternion.Euler(pointer.transform.localRotation.x, pointer.transform.localRotation.y, angle);


        // float f1 = (player.transform.position+player.transform.forward*1).x - targetPosition.transform.position.x;
        //float f2= (player.transform.position + player.transform.forward * 1).z - targetPosition.transform.position.z;
        //float f1 = targetPosition.transform.position.x-(player.transform.position + player.transform.forward * 1).x;
        //float f2 = targetPosition.transform.position.z-(player.transform.position + player.transform.forward * 1).z;
        //float angle = Mathf.Atan2(f2, f1);

        //float angle = Vector2.SignedAngle(targetPosition.transform.position - player.transform.position, Vector2.up);
        //Debug.Log(angle*Mathf.Rad2Deg);

        //pointer.transform.localRotation = Quaternion.Euler(pointer.transform.localRotation.x, pointer.transform.localRotation.y, angle*Mathf.Rad2Deg);
        //float angle = Vector2.Angle(pos1, pos2);
        // Debug.Log(angle);
        //pointer.transform.localRotation = Quaternion.Euler(pointer.transform.localRotation.eulerAngles.x, pointer.transform.localRotation.eulerAngles.y, angle);
        //transform.position = targetPosition.transform.position;
        //Vector3 oldrot = pointer.transform.rotation.eulerAngles;
        //pointer.transform.rotation = Quaternion.LookRotation(targetPosition.transform.position-transform.position);
        //pointer.transform.eulerAngles = new Vector3(oldrot.x, oldrot.y, pointer.transform.rotation.eulerAngles.z);


        // Vector3 oldrot = transform.localRotation.eulerAngles;
        //transform.rotation = Quaternion.LookRotation(targetPosition.transform.position-transform.position);
        // transform.localRotation = Quaternion.Euler(oldrot.x, oldrot.y, transform.rotation.eulerAngles.z);

    }

}
