using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool droppable = true;
    public int zoneScore;
    public int zonePosition;

    public BattleManager battleManager;

    private Image zone;

    private IEnumerator waitCoroutine;

    public void Start()
    {
        zone = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (battleManager.dragging == true)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && droppable == true)
            {
                zone.color = battleManager.highColour;

                if (d.cardClass == "Buff")
                {
                    battleManager.BuffHighlight(zonePosition);
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (battleManager.dragging == true)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && droppable == true)
            {
                zone.color = battleManager.zoneColour;

                if (d.cardClass == "Buff")
                {
                    battleManager.ClearHighlights(zonePosition);
                }
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && droppable == true)
        {
            if (d.parentToReturnTo != this.transform)
            {
                this.zoneScore = d.cardScore;
                d.newParent = this.transform;
                this.droppable = false;

                if (d.cardClass == "Buff")
                {
                    battleManager.Buff(zonePosition);

                    battleManager.ClearHighlights(zonePosition);
                }
                else if (d.cardClass == "Block")
                {
                    battleManager.Block();
                }

                zone.color = battleManager.cyanColour;

                waitCoroutine = SmallWait();
                StartCoroutine(waitCoroutine);                               
            }
        }
    }

    // Small wait before setting the player turn to false allows the card to finish dropping properly.
    public IEnumerator SmallWait()
    {
        yield return new WaitForSeconds(0.1f);

        battleManager.playerTurn = false;
    }
}
