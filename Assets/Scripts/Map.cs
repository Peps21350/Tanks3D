using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private GameObject _prefabIndestructibleWall;
    [SerializeField] private GameObject _prefabDestructibleWall;
    [SerializeField] private GameObject _nawMesh;
    private GameObject _createdWalls;
    [HideInInspector] public List<int> busyCoordsX;
    [HideInInspector] public List<int> busyCoordsZ;
    [SerializeField] private Bonus _bonus;
    [HideInInspector] public static bool isStart = true;
    
    
	// a place where obstacles do not spawn
	public const int AmountCellWhereDontSpawnObstacles = 3;

	private float _xPos;
	private float _zPos;
	


	[HideInInspector] public int widthMap = 40;
    [HideInInspector] public int heightMap = 40;

    float xOffset = 0.882f;
    float zOffset = 0.764f;


    void Start () 
    {
	    if (isStart == true)
	    {
		    CreatingMap();
		    CreatingObstacles();
	    }
    }


    private void CreatingObstacles()
    {
	    int minCountObstacle = (heightMap * widthMap) / 5;
	    int maxCountObstacle = (heightMap * widthMap) / 4;
	    
	    int randAmountObstacles = Random.Range(minCountObstacle, maxCountObstacle);
	    for (int i = 0; i < randAmountObstacles; i++)
	    {
		    int randPositionX = Random.Range(AmountCellWhereDontSpawnObstacles, heightMap - 1);
		    int randPositionZ = Random.Range(AmountCellWhereDontSpawnObstacles, widthMap - 1);
		    if (CheсkCoordWithList(randPositionX, randPositionZ))
		    {
			    AddCoordsToList(randPositionX, randPositionZ);
			    float xRandPos = SetXPos(randPositionX, randPositionZ);
			    if (i % 2 == 1)
			    {
				    GameObject createdDestructibleWall = (GameObject) Instantiate(_prefabDestructibleWall,
					    new Vector3(xRandPos, 0, randPositionZ * zOffset), Quaternion.identity);
				    SetOptionsForCell(createdDestructibleWall, "HexDestructibleWall_", 0, i);
			    }
			    else
			    {
				    GameObject createdIndestructibleWall = (GameObject) Instantiate(_prefabIndestructibleWall,
					    new Vector3(xRandPos, 0, randPositionZ * zOffset), Quaternion.identity);
				    SetOptionsForCell(createdIndestructibleWall, "HexIndestructibleWall_", 0, i);
			    }
		    }
		    else
			    randAmountObstacles++;
	    }
	    _nawMesh.SetActive(true);
	    _nawMesh.GetComponent<NavMeshSurface>().BuildNavMesh();

    }

    public float SetXPos(int x, int y)
    {
	    _xPos = x * xOffset;
                
	    if( y % 2 == 1 ) 
	    {
		    _xPos += xOffset/2f;
	    }

	    return _xPos;
    }

    private void CreatingMap()
    {
	    for (int x = 0; x < widthMap; x++) 
	    {
		    for (int y = 0; y < heightMap; y++)
		    {
			    _xPos = SetXPos(x, y);
			    GameObject hexGO = (GameObject)Instantiate(hexPrefab, new Vector3( _xPos,0, y * zOffset  ), Quaternion.identity  );
			    SetOptionsForCell(hexGO,"Hex_", x,y);
			    if (x == 0 || x == widthMap-1 ||  y == heightMap-1 || y == 0)
			    {
				    _createdWalls = (GameObject)Instantiate(_prefabIndestructibleWall, new Vector3( _xPos,0, y * zOffset  ), Quaternion.identity  );
				    SetOptionsForCell(_createdWalls,"HexWall_", x,y);
			    }
		    }
	    }
    }

    private void AddCoordsToList(int valueX, int valueZ)
    {
	    busyCoordsX.Add(valueX);
	    busyCoordsZ.Add(valueZ);
    }

    public bool CheсkCoordWithList(int valueX, int valueZ)
    {
	    bool result = true;
	    var  coordsXZ =  busyCoordsX.Zip(busyCoordsZ, (x, z) => new Vector2Int( x, z ));
	    foreach (var coords in coordsXZ)
	    {
		    if (coords.x == valueX  && coords.y == valueZ )//((coords.x == valueX || coords.x + 1 == valueX || coords.x - 1 == valueX) && (coords.y == valueZ || coords.y - 1 == valueZ || coords.y + 1 == valueZ))
		    {
			    result = false;
			    break;
		    }
	    }
	    return result;
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
