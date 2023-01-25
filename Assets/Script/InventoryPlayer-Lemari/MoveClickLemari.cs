using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveClickLemari : MonoBehaviour, IPointerClickHandler
{
    public GameObject UI_LemariInventory;

    public Mover move;

    private int itemIndex;

    private void Awake()
    {
        itemIndex = UI_LemariInventory.GetComponent<UI_LemariInventory>().getNomor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        move.MoveToPlayer(itemIndex);
    }
}
