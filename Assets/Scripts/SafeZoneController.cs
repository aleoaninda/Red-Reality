using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    //public float expansionSpeed;
    public Vector2 futureSafeZoneSize;
    int iter = 0;
    int limit = 250;
    //public float decimalInitialSize = 0.2f;
    //public float mapScaleInRelationToObject = 24; //The scale of the object so that it covers the entire map
    public static int safeZoneState = 1; //0 = Shrink Safe Zone, 1 = Stable Safe Zone, 2 = Expand SafeZone
    /*enum SafeZoneStates
    {
        Expand,
        Stable,
        Shrink
    }*/

        /*
         * Initial Scale = 4 (0.2 * 24)
         * 24 SCALE IS MAP Size
         * Max Size is 30% of Map Size
         * 10 Puzzles in prototype
         * 
         */

    // Start is called before the first frame update
    void Start()
    {
        //futureSafeZoneSize.x = decimalInitialSize * mapScaleInRelationToObject; //Sets initial Size of SafeZone;
        //futureSafeZoneSize.y = decimalInitialSize * mapScaleInRelationToObject; //Sets initial Size of SafeZone;

    }

    // Update is called once per frame
    void Update()
    {

        if (safeZoneState == 2)
        {
            Debug.Log("Expand");
            expand();
        }

        else if (safeZoneState == 0)
        {
            Debug.Log("Shrink");
            shrink();
        }
        else { //for debugging purpose
            Debug.Log("Stable");
        }

    }
    void expand()
    {
        futureSafeZoneSize = transform.localScale;

        futureSafeZoneSize.x += Time.deltaTime;
        futureSafeZoneSize.y += Time.deltaTime;

        transform.localScale = futureSafeZoneSize;
        iter++;
        if (iter > limit)
        {
            stablise();
        }
    }

    void shrink()
    {
        futureSafeZoneSize = transform.localScale;

        futureSafeZoneSize.x -= Time.deltaTime;
        futureSafeZoneSize.y -= Time.deltaTime;

        transform.localScale = futureSafeZoneSize;
        iter++;
        if (iter > limit) {
            stablise();
        }
    }

    void stablise() {
        safeZoneState = 1;
        iter = 0;
    }

    
}
