using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private GameObject _prefabNotСollapsingWall;
    private GameObject _createdWalls;


    int width = 40;
    int height = 40;

    float xOffset = 0.882f;
    float zOffset = 0.764f;

    // Use this for initialization
    void Start () 
    {
	    CreateMap();
    }

    private void CreateMap()
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

			    GameObject hexGO = (GameObject)Instantiate(hexPrefab, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
			    SetOptionsForCell(hexGO,"Hex_", x,y);

			    if (x == 0 || x == 39 ||  y == 39 || y == 0)
			    {
				    _createdWalls = (GameObject)Instantiate(_prefabNotСollapsingWall, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
				    SetOptionsForCell(_createdWalls,"HexWall_", x,y);
			    }
			    
			    
			    void SetOptionsForCell(GameObject cell, string nameCell, int x, int y)
			    {
				    cell.name = nameCell + x + "_" + y;
                
				    cell.GetComponent<Hex>().x = x;
				    cell.GetComponent<Hex>().y = y;
                
				    cell.transform.SetParent(this.transform);
                
				    cell.isStatic = true;
			    }

			   

		    }
	    }
    }

    // Update is called once per frame
    void Update () 
    {
	
    }
}
