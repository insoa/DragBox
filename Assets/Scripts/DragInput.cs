using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _boxImage;
    [SerializeField] private List<Color> _colors = new List<Color>();
    
    private List<Item> _collectedItems = new List<Item>();
    private int _itemCount; 
    
    private void Start() => _boxImage.GetComponent<Image>();
    
    private void GetItem(Item item)
    {
        item.gameObject.transform.SetParent(gameObject.transform);
        _collectedItems.Add(item);
        UiController.Instance.SetCount(_collectedItems.Count);
    }

    public void OnDrag(PointerEventData eventData) => transform.position = eventData.position;

    public void OnBeginDrag(PointerEventData eventData) => _boxImage.color = _colors[0];

    public void OnEndDrag(PointerEventData eventData) => _boxImage.color = _colors[1];

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GetItem(collider.GetComponent<Item>());
    }
}
