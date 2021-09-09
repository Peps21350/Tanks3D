using UnityEngine;
using UnityEngine.EventSystems;

public sealed class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal => _input.x;
    public float Vertical => _input.y;

    private float[,] angleMass = {{10, 60}, {60, 120,}, {120, 170}, {-10, -60}, {-60, -120}, {-120, -170}};
    private float[,] positionToMove = {{0.866f, 0.5f}, {0,1}, {-0.866f, 0.5f}, {0.866f, -0.5f}, {0,-1}, {-0.866f, -0.5f}};
    public float HandleRange
    {
        set => _handleRange = Mathf.Abs(value);
    }
    
    [SerializeField] private float _handleRange = 1;
    [SerializeField] private RectTransform _joystickBackground = null;
    [SerializeField] private RectTransform _joystickHandle = null;
    
    private RectTransform _baseRect = null;
    private Vector2 _input = Vector2.zero;
    private float angle = 0;

    private void Start()
    {
        HandleRange = _handleRange;
        Vector2 center = new Vector2(0.5f, 0.5f);
        _joystickBackground.pivot = center;
        _joystickHandle.anchorMin = center;
        _joystickHandle.anchorMax = center;
        _joystickHandle.pivot = center;
        _joystickHandle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(null,  _joystickBackground.position);
        Vector2 radius = _joystickBackground.sizeDelta / 2;
        _input = (eventData.position - position) / radius ;
        HandleInput(_input.magnitude, _input.normalized, radius);
        _joystickHandle.anchoredPosition = _input * radius * _handleRange;
        //AngleCheck();
    }

    private void AngleCheck()
    {
        float angle = Mathf.Atan2(_input.y, _input.x) * Mathf.Rad2Deg;
        int rows = angleMass.GetUpperBound(0) + 1;
        int columns = angleMass.Length / rows;
        for (int i = 0; i < rows; i++)
        {
            if (angle > angleMass[i,0] && angle < angleMass[i,1])
            {
                _input.x = positionToMove[i, 0];
                _input.y = positionToMove[i, 1];
            }
        }
    }

    private void HandleInput(float magnitude, Vector2 normalised, Vector2 radius)
    {
        if (magnitude > 0)
        {
            if (magnitude > 1)
                _input = normalised;
        }
        else
            _input = Vector2.zero;
    }
    

    public void OnPointerUp(PointerEventData eventData)
    {
        _input = Vector2.zero;
        _joystickHandle.anchoredPosition = Vector2.zero;
    }
}
