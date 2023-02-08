using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public GameObject targetPosition;

    public GameObject pointer;

    public GameObject player;



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

        //Get directional Vector from player to objective ignoring Y
        Vector3 vectorToObjective = targetPosition.transform.position - player.transform.position;

        vectorToObjective.y = 0;

        //Get player view direction vector
        Vector3 playerToView = (player.transform.position + player.transform.forward) - player.transform.position;

        playerToView.y = 0;

        //Calculate magnitudes of vectors for dot product sum
        float VectorToObjectiveMag = vectorToObjective.magnitude;
        float PlayerToViewMag = playerToView.magnitude;

        //Solve for dot product
        float dot = Vector3.Dot(vectorToObjective, playerToView);

        //calculate the arc cosine for pointer direction
        float temp = dot / (VectorToObjectiveMag * PlayerToViewMag);
        float angle = Mathf.Acos(temp);


        //Work out if the player is looking left or right through cross product of the objective, if so, flip the angle for correct representation
        Vector3 delta = targetPosition.transform.position - player.transform.position;
        Vector3 cross = Vector3.Cross(delta,player.transform.forward);
        float dot2 = Vector3.Dot(cross, Vector3.up);
        if (dot2 < 0)
        {
            angle *= -1;
        }

        // Set pointer to look at the target relative to player rotation;
        pointer.transform.localRotation = Quaternion.Euler(pointer.transform.localEulerAngles.x, pointer.transform.localEulerAngles.y, angle * Mathf.Rad2Deg);

       

    }

}
