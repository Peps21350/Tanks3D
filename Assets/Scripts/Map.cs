using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private GameObject _prefabIndestructibleWall;
    [SerializeField] private GameObject _prefabDestructibleWall;
    private GameObject _createdWalls;
    
    
	// a place where obstacles do not spawn
	private const int _AmountCellWhereDontSpawnObstacles = 3;


    int widthMap = 40;
    int heightMap = 40;

    float xOffset = 0.882f;
    float zOffset = 0.764f;

    // Use this for initialization
    void Start () 
    {
	    CreatingMap();
	    CreatingObstacles();
    }


    private void CreatingObstacles()
    {
	    int randAmountObstacles = Random.Range(widthMap, widthMap * heightMap / 2);
	    for (int i = 0; i < randAmountObstacles; i++)
	    {
		    int randPositionX = Random.Range(_AmountCellWhereDontSpawnObstacles, heightMap - 1);
		    int randPositionY = Random.Range(_AmountCellWhereDontSpawnObstacles, widthMap - 1);
		    float xRandPos = randPositionX * xOffset;
		    if( randPositionY % 2 == 1 ) 
		    {
			    xRandPos += xOffset/2f;
		    }

		    if (i % 2 == 1)
		    {
			    GameObject createdDestructibleWall = (GameObject)Instantiate(_prefabDestructibleWall, new Vector3( xRandPos,0, randPositionY * zOffset  ), Quaternion.identity  );
			    SetOptionsForCell(createdDestructibleWall,"HexDestructibleWall_", 0,i);
		    }
		    else
		    {
			    GameObject createdIndestructibleWall = (GameObject)Instantiate(_prefabIndestructibleWall, new Vector3( xRandPos,0, randPositionY * zOffset  ), Quaternion.identity  );
			    SetOptionsForCell(createdIndestructibleWall,"HexIndestructibleWall_", 0,i);
		    }

		    
	    }

	    
    }

    private void CreatingMap()
    {
	    for (int x = 0; x < widthMap; x++) 
	    {
		    for (int y = 0; y < heightMap; y++) 
		    {
			    float xPos = x * xOffset;
                
			    if( y % 2 == 1 ) 
			    {
				    xPos += xOffset/2f;
			    }

			    GameObject hexGO = (GameObject)Instantiate(hexPrefab, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
			    SetOptionsForCell(hexGO,"Hex_", x,y);

			    if (x == 0 || x == widthMap-1 ||  y == heightMap-1 || y == 0)
			    {
				    _createdWalls = (GameObject)Instantiate(_prefabIndestructibleWall, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
				    SetOptionsForCell(_createdWalls,"HexWall_", x,y);
			    }
			    
		    }
	    }
    }
    
    private void SetOptionsForCell(GameObject cell, string nameCell, int x, int y)
    {
	    cell.name = nameCell + x + "_" + y;
                
	    cell.GetComponent<Hex>().x = x;
	    cell.GetComponent<Hex>().y = y;
                
	    cell.transform.SetParent(this.transform);
                
	    cell.isStatic = true;
    }

    // Update is called once per frame
    void Update () 
    {
	
    }
}
