using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalButton : MonoBehaviour
{
    //public Button button;
    // Start is called before the first frame update
    void Start()
    {
        //button.onClick.AddListener(FinalRestart);
    }

    // Update is called once per frame
    void Update()
    {
        //button.onClick.AddListener(FinalRestart);
    }

    public void FinalRestart()
    {
        GameManager.instance.playerScore = 0;
        GameManager.instance.playerHealthCurrent = 3;
        GameManager.instance.playerUpgrades = 0;
        GameManager.instance.level = 1;
        GameManager.instance.enemiesDefeated = 0;
        GameManager.instance.inBattle = false;
        GameManager.instance.gPlayerStart = 0;
        GameManager.instance.gBasicValue = 1;
        GameManager.instance.gBlockValue = 1;
        GameManager.instance.gBuffValue = 1;
        SceneManager.LoadScene("Menu");
    }
}
