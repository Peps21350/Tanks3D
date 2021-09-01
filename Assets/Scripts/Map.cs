using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject hexPrefab;

    // Size of the map in terms of number of hex tiles
    // This is NOT representative of the amount of 
    // world space that we're going to take up.
    // (i.e. our tiles might be more or less than 1 Unity World Unit)
    int width = 40;
    int height = 40;

    float xOffset = 0.882f;
    float zOffset = 0.764f;

    // Use this for initialization
    void Start () 
    {
	
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++) 
            {

                float xPos = x * xOffset;
                
                if( y % 2 == 1 ) 
                {
                    xPos += xOffset/2f;
                }

                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
                
                hex_go.name = "Hex_" + x + "_" + y;
                
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().y = y;
                
                hex_go.transform.SetParent(this.transform);
                
                hex_go.isStatic = true;

            }
        }

    }
	
    // Update is called once per frame
    void Update () 
    {
	
    }
}
