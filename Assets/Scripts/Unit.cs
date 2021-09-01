using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private JoyStick _joyStick;

    public Vector3 destination;

    float speed = 2;
    
    void Start () 
    {
        //destination = new Vector3(_joyStick.Horizontal(), _joyStick.Vertical(),0);
        destination = transform.position;
    }
	
    // Update is called once per frame
    void Update () 
    {

        Vector3 dir = destination - transform.position;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;
        
        velocity = Vector3.ClampMagnitude( velocity, dir.magnitude );

        transform.Translate(velocity);

    }

    void NextTurn() 
    {
        // Set "destination" to be the position of the next tile
        // in our pathfinding queue.
    }
}
