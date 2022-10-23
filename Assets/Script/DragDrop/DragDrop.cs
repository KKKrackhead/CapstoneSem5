using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    public RectTransform home;
    public RectTransform parent1;
    public RectTransform target;
    private CanvasGroup canvasGroup;
    public GameObject UI_playerInventory;
    public GameObject ConfirmButton;

    private int nomor;
  //private Item display;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        nomor = UI_playerInventory.GetComponent<UI_Inventory>().getNomor();
    //  display = UI_playerInventory.GetComponent<UI_Inventory>().getItem();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if(rectTransform.anchoredPosition != target.anchoredPosition)
        {
            rectTransform.anchoredPosition = home.anchoredPosition;
            parent1.anchoredPosition = new Vector2(nomor * 170f, 0f);
        }
        else
        {
            parent1.anchoredPosition = new Vector2(0f, 0f);
            ConfirmButton.GetComponent<ConfirmButtonMejaDisplay>().setitemIndex(nomor);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}
