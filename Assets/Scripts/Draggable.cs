using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
    public Transform newParent = null;
    public bool draggable = true;
    public int cardScore = 1;
    public TextMeshProUGUI valueText;
    public string cardClass = "Base";
    public BattleManager battleManager; 

    void Start()
    {
        battleManager = GameObject.Find("battleManager").GetComponent<BattleManager>();

        if (cardClass == "Base")
        {
            cardScore = battleManager.basicValue * 2;
        }
        else if (cardClass == "Buff")
        {
            cardScore = battleManager.basicValue /*+ battleManager.buffValue - 1*/;
        }
        else // (cardClass == "Block")
        {
            cardScore = battleManager.basicValue /*+ battleManager.blockValue - 1*/;
        }

        valueText.text = cardScore.ToString();
    }

    void Update()
    {
        if (draggable == false)
        {
            valueText.text = this.transform.parent.GetComponent<DropZone>().zoneScore.ToString();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        if (draggable == true && battleManager.playerTurn == true)
        {
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        battleManager.dragging = true;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");
        if (draggable == true && battleManager.playerTurn == true)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        if (draggable == true && battleManager.playerTurn == true)
        {
            if (newParent != parentToReturnTo && newParent != null)
            {
                this.transform.SetParent(newParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                this.draggable = false;
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }

        battleManager.dragging = false;
    }



}
