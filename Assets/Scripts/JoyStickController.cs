using UnityEngine;
using UnityEngine.EventSystems;

public sealed class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal => _input.x;
    public float Vertical => _input.y;
    
    public float HandleRange
    {
        set => handleRange = Mathf.Abs(value);
    }
    
    [SerializeField] private float handleRange = 1;
    [SerializeField] private RectTransform joystickBackground = null;
    [SerializeField] private RectTransform joystickHandle = null;
    private RectTransform _baseRect = null;
    private Vector2 _input = Vector2.zero;

    private void Start()
    {
        HandleRange = handleRange;
        Vector2 center = new Vector2(0.5f, 0.5f);
        joystickBackground.pivot = center;
        joystickHandle.anchorMin = center;
        joystickHandle.anchorMax = center;
        joystickHandle.pivot = center;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(null,  joystickBackground.position);
        Vector2 radius = joystickBackground.sizeDelta / 2;
        _input = (eventData.position - position) / radius ;
        HandleInput(_input.magnitude, _input.normalized, radius);
        joystickHandle.anchoredPosition = _input * radius * handleRange;
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
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}
