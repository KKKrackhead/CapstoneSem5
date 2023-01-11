using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveClickPlayer : MonoBehaviour, IPointerClickHandler
{
    public GameObject UI_playerInventory;

    public Mover move;

    private int itemIndex;

    private void Awake()
    {
        itemIndex = UI_playerInventory.GetComponent<UI_Inventory2>().getNomor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Player");
        move.MoveToLemari(itemIndex);
    }
}
