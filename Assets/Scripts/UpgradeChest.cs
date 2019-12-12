using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeChest : MonoBehaviour
{
    public GameObject upgradeCanvas;
    public TextMeshProUGUI blurbText;
    public Button continueButton;
    public TextMeshProUGUI upgradeTextOne;
    public TextMeshProUGUI upgradeTextTwo;
    public TextMeshProUGUI upgradeTextReject;
    public Button upgradeButtonOne;
    public Button upgradeButtonTwo;
    public Button upgradeButtonReject;

    // Start is called before the first frame update
    void Start()
    {
        upgradeCanvas = GameObject.Find("ChestPopup");
        blurbText = GameObject.Find("BlurbText").GetComponent<TextMeshProUGUI>();
        continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        upgradeTextOne = GameObject.Find("UpgradeChoice1").GetComponent<TextMeshProUGUI>();
        upgradeTextTwo = GameObject.Find("UpgradeChoice2").GetComponent<TextMeshProUGUI>();
        upgradeTextReject = GameObject.Find("UpgradeChoiceReject").GetComponent<TextMeshProUGUI>();
        upgradeButtonOne = GameObject.Find("UpgradeButton1").GetComponent<Button>();
        upgradeButtonTwo = GameObject.Find("UpgradeButton2").GetComponent<Button>();
        upgradeButtonReject = GameObject.Find("UpgradeButtonReject").GetComponent<Button>();

        upgradeCanvas.SetActive(false);
        blurbText.enabled = false;
        continueButton.gameObject.SetActive(false);
        upgradeTextOne.enabled = false;
        upgradeTextTwo.enabled = false;
        upgradeTextReject.enabled = false;
        upgradeButtonOne.gameObject.SetActive(false);
        upgradeButtonTwo.gameObject.SetActive(false);
        upgradeButtonReject.gameObject.SetActive(false);
    }


    public void UpgradeChestStart(int upgrades)
    {
        upgradeCanvas.SetActive(true);
        if (upgrades == 0)
        {
            blurbText.text = ("Finding the first part of himself, the prince begins to regain his lost power.");
        }
        else if (upgrades == 1)
        {
            blurbText.text = ("Opening the chest, the prince finds another piece of himself, and so his magic grows.");
        }
        else if (upgrades == 2)
        {
            blurbText.text = ("Continuing up the tower, the prince finds another chest.");
        }
        else if (upgrades == 3)
        {
            blurbText.text = ("Venturing into the darkness, the prince finds more of himself, and more magic with it.");
        }
        else if (upgrades == 4)
        {
            blurbText.text = ("High in the witches tower, the prince finds another piece. His task is nearling completion.");
        }
        else if (upgrades == 5)
        {
            blurbText.text = ("Finally finding his heart, the prince is oncce again complete. Now all that remains is defeating the witch once and for all...");
        }
        blurbText.enabled = true;
        continueButton.gameObject.SetActive(true);

        continueButton.onClick.AddListener(UpgradeChestChoices);
    }

    public void UpgradeChestChoices()
    {
        blurbText.enabled = false;
        continueButton.gameObject.SetActive(false);
        int randChoiceOne = Random.Range(0, 4);
        int randChoiceTwo;
        while (true)
        {
            randChoiceTwo = Random.Range(0, 4);
            if (randChoiceOne != randChoiceTwo)
            {
                break;
            }
        }

        if (randChoiceOne == 0)
        {
            upgradeTextOne.text = ("Harness magic to increase your spells strength.");
        }
        else if (randChoiceOne == 1)
        {
            upgradeTextOne.text = ("Learn to increase the coordination of your spells.");
        }
        else if (randChoiceOne == 2)
        {
            upgradeTextOne.text = ("Better protective magics will save you from harm.");
        }
        else
        {
            upgradeTextOne.text = ("Inner focus gives you a better start on the monsters.");
        }

        if (randChoiceTwo == 0)
        {
            upgradeTextTwo.text = ("Harness magic to increase your spells strength.");
        }
        else if (randChoiceTwo == 1)
        {
            upgradeTextTwo.text = ("Learn to increase the coordination of your spells.");
        }
        else if (randChoiceTwo == 2)
        {
            upgradeTextTwo.text = ("Better protective magics will save you from harm.");
        }
        else
        {
            upgradeTextTwo.text = ("Inner focus gives you a better start on the monsters.");
        }

        upgradeTextOne.enabled = true;
        upgradeTextTwo.enabled = true;
        upgradeTextReject.enabled = true;
        upgradeButtonOne.gameObject.SetActive(true);
        upgradeButtonTwo.gameObject.SetActive(true);
        upgradeButtonReject.gameObject.SetActive(true);

        upgradeButtonOne.onClick.AddListener(delegate { UpgradeButtonClicked(randChoiceOne); });
        upgradeButtonTwo.onClick.AddListener(delegate { UpgradeButtonClicked(randChoiceTwo); });
        upgradeButtonReject.onClick.AddListener(delegate { UpgradeButtonClicked(-1); });
    }

    public void UpgradeButtonClicked(int choice)
    {
        if (choice == 0)
        {
            GameManager.instance.gBasicValue += 1;
        }
        else if (choice == 1)
        {
            GameManager.instance.gBuffValue += 1;
        }
        else if (choice == 2)
        {
            GameManager.instance.gBlockValue += 1;
        }
        else if (choice == 3)
        {
            GameManager.instance.gPlayerStart += 1;
        }
        else
        {
            // Reject upgrade, for hard-mode
        }

        GameManager.instance.playerUpgrades += 1;
        if (GameManager.instance.playerUpgrades == 6)
        {
            GameManager.instance.finalBattle();
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
}
