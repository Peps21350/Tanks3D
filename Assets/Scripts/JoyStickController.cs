using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    public GameObject touchMarket;

    private Vector3 _targetVector;

    public Unit unitController;

    private Vector3 _savePosition;
    // Start is called before the first frame update
    void Start()
    {
        touchMarket.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // треба переписати інпути під андроід,(поменять Input.GetMouseButton(0) на Input.touchCount >0 и Input.mousePosition
        // на Input.GetTouch (0).position, где 0 означает, что мы записываем координаты первого касания.)
        
        if (Input.GetMouseButton(0))
        {
            Vector3  touch_pos = Input.mousePosition;
            _targetVector = touch_pos - transform.position;
            if (_targetVector.magnitude < 120)
            {
                touchMarket.transform.position = touch_pos;
                unitController.destination = new Vector3(_targetVector.x, 0, _targetVector.z);
                _savePosition = new Vector3(_targetVector.x, 0, _targetVector.z);
            }
        }

        else
        {
            touchMarket.transform.position = transform.position;
            unitController.destination = _savePosition;
            //unitController.destination= new Vector3(0, 0, 0);
        }
    }
}
