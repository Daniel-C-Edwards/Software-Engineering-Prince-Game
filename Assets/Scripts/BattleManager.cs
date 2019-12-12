using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public TextMeshProUGUI spellScore;

    public DropZone dz1;
    public DropZone dz2;
    public DropZone dz3;
    public DropZone dz4;
    public DropZone dz5;
    public DropZone dz6;
    public DropZone dz7;
    public DropZone dz8;
    public DropZone dz9;
    private int scoreSum;

    public Color32 zoneColour;
    public Color32 highColour;
    public Color32 greenColour;
    public Color32 cyanColour;
    public Color32 redColour;

    public int playerStart = 0;
    public int basicValue = 1;
    public int buffValue = 1;
    public int blockValue = 1;

    public int blockTurns = 0;

    public int turn = 0;

    public Transform playerHand;
    public GameObject basicCard;
    public GameObject buffCard;
    public GameObject blockCard;

    public bool playerTurn = true;
    public BattleEnemy battleEnemy;

    public bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        zoneColour = new Color32(255, 255, 255, 100);
        highColour = new Color32(250, 225, 120, 150);
        greenColour = new Color32(0, 255, 0, 150);
        cyanColour = new Color32(0, 255, 255, 150);
        redColour = new Color32(255, 0, 0, 150);

        drawCard();
        drawCard();
        drawCard();
        for (int i=0; i<playerStart; i++)
        {
            drawCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreSum = dz1.zoneScore + dz2.zoneScore + dz3.zoneScore + dz4.zoneScore + dz5.zoneScore + dz6.zoneScore + dz7.zoneScore + dz8.zoneScore + dz9.zoneScore + 10*playerStart;
        spellScore.text = ("Spell Power: " + scoreSum.ToString());

        if (playerTurn == false)
        {
            drawCard();

            if (blockTurns > 0)
            {
                blockTurns -= 1;
                battleEnemy.enemyActionText.text = ("The monster is stunned.");
                playerTurn = true;
            }
            else
            {
                battleEnemy.EnemyTurn();
            }

            turn += 1;
        }

        if (turn == 9)
        {
            EndBattle();
        }
    }

    public void Buff(int position)
    {
        if (position == 1)
        {
            if (dz2.droppable == false) dz2.zoneScore = dz2.zoneScore + buffValue;
            if (dz4.droppable == false) dz4.zoneScore = dz4.zoneScore + buffValue;
        }
        else if (position == 2)
        {
            if (dz1.droppable == false) dz1.zoneScore = dz1.zoneScore + buffValue;
            if (dz3.droppable == false) dz3.zoneScore = dz3.zoneScore + buffValue;
            if (dz5.droppable == false) dz5.zoneScore = dz5.zoneScore + buffValue;
        }
        else if (position == 3)
        {
            if (dz2.droppable == false) dz2.zoneScore = dz2.zoneScore + buffValue;
            if (dz6.droppable == false) dz6.zoneScore = dz6.zoneScore + buffValue;
        }
        else if (position == 4)
        {
            if (dz1.droppable == false) dz1.zoneScore = dz1.zoneScore + buffValue;
            if (dz5.droppable == false) dz5.zoneScore = dz5.zoneScore + buffValue;
            if (dz7.droppable == false) dz7.zoneScore = dz7.zoneScore + buffValue;
        }
        else if (position == 5)
        {
            if (dz2.droppable == false) dz2.zoneScore = dz2.zoneScore + buffValue;
            if (dz4.droppable == false) dz4.zoneScore = dz4.zoneScore + buffValue;
            if (dz6.droppable == false) dz6.zoneScore = dz6.zoneScore + buffValue;
            if (dz8.droppable == false) dz8.zoneScore = dz8.zoneScore + buffValue;
        }
        else if (position == 6)
        {
            if (dz3.droppable == false) dz3.zoneScore = dz3.zoneScore + buffValue;
            if (dz5.droppable == false) dz5.zoneScore = dz5.zoneScore + buffValue;
            if (dz9.droppable == false) dz9.zoneScore = dz9.zoneScore + buffValue;
        }
        else if (position == 7)
        {
            if (dz4.droppable == false) dz4.zoneScore = dz4.zoneScore + buffValue;
            if (dz8.droppable == false) dz8.zoneScore = dz8.zoneScore + buffValue;
        }
        else if (position == 8)
        {
            if (dz5.droppable == false) dz5.zoneScore = dz5.zoneScore + buffValue;
            if (dz7.droppable == false) dz7.zoneScore = dz7.zoneScore + buffValue;
            if (dz9.droppable == false) dz9.zoneScore = dz9.zoneScore + buffValue;
        }
        else // (position == 9)
        {
            if (dz6.droppable == false) dz6.zoneScore = dz6.zoneScore + buffValue;
            if (dz8.droppable == false) dz8.zoneScore = dz8.zoneScore + buffValue;
        }
    }

    public void BuffHighlight(int position)
    {
        if (position == 1)
        {
            if (dz2.droppable == false) dz2.GetComponent<Image>().color = greenColour;
            else dz2.GetComponent<Image>().color = redColour;
            if (dz4.droppable == false) dz4.GetComponent<Image>().color = greenColour;
            else dz4.GetComponent<Image>().color = redColour;
        }
        else if (position == 2)
        {
            if (dz1.droppable == false) dz1.GetComponent<Image>().color = greenColour;
            else dz1.GetComponent<Image>().color = redColour;
            if (dz3.droppable == false) dz3.GetComponent<Image>().color = greenColour;
            else dz3.GetComponent<Image>().color = redColour;
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = greenColour; 
            else dz5.GetComponent<Image>().color = redColour;
        }
        else if (position == 3)
        {
            if (dz2.droppable == false) dz2.GetComponent<Image>().color = greenColour;
            else dz2.GetComponent<Image>().color = redColour;
            if (dz6.droppable == false) dz6.GetComponent<Image>().color = greenColour;
            else dz6.GetComponent<Image>().color = redColour;
        }
        else if (position == 4)
        {
            if (dz1.droppable == false) dz1.GetComponent<Image>().color = greenColour;
            else dz1.GetComponent<Image>().color = redColour;
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = greenColour;
            else dz5.GetComponent<Image>().color = redColour;
            if (dz7.droppable == false) dz7.GetComponent<Image>().color = greenColour;
            else dz7.GetComponent<Image>().color = redColour;
        }
        else if (position == 5)
        {
            if (dz2.droppable == false) dz2.GetComponent<Image>().color = greenColour;
            else dz2.GetComponent<Image>().color = redColour;
            if (dz4.droppable == false) dz4.GetComponent<Image>().color = greenColour;
            else dz4.GetComponent<Image>().color = redColour;
            if (dz6.droppable == false) dz6.GetComponent<Image>().color = greenColour;
            else dz6.GetComponent<Image>().color = redColour;
            if (dz8.droppable == false) dz8.GetComponent<Image>().color = greenColour;
            else dz8.GetComponent<Image>().color = redColour;
        }
        else if (position == 6)
        {
            if (dz3.droppable == false) dz3.GetComponent<Image>().color = greenColour;
            else dz3.GetComponent<Image>().color = redColour;
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = greenColour;
            else dz5.GetComponent<Image>().color = redColour;
            if (dz9.droppable == false) dz9.GetComponent<Image>().color = greenColour;
            else dz9.GetComponent<Image>().color = redColour;
        }
        else if (position == 7)
        {
            if (dz4.droppable == false) dz4.GetComponent<Image>().color = greenColour;
            else dz4.GetComponent<Image>().color = redColour;
            if (dz8.droppable == false) dz8.GetComponent<Image>().color = greenColour;
            else dz8.GetComponent<Image>().color = redColour;
        }
        else if (position == 8)
        {
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = greenColour;
            else dz5.GetComponent<Image>().color = redColour;
            if (dz7.droppable == false) dz7.GetComponent<Image>().color = greenColour;
            else dz7.GetComponent<Image>().color = redColour;
            if (dz9.droppable == false) dz9.GetComponent<Image>().color = greenColour;
            else dz9.GetComponent<Image>().color = redColour;
        }
        else // (position == 9)
        {
            if (dz6.droppable == false) dz6.GetComponent<Image>().color = greenColour;
            else dz6.GetComponent<Image>().color = redColour;
            if (dz8.droppable == false) dz8.GetComponent<Image>().color = greenColour;
            else dz8.GetComponent<Image>().color = redColour;
        }
    }

    public void ClearHighlights(int position)
    {
        if (position == 1)
        {
            if (dz2.droppable == false) dz2.GetComponent<Image>().color = cyanColour;
            else dz2.GetComponent<Image>().color = zoneColour;
            if (dz4.droppable == false) dz4.GetComponent<Image>().color = cyanColour;
            else dz4.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 2)
        {
            if (dz1.droppable == false) dz1.GetComponent<Image>().color = cyanColour;
            else dz1.GetComponent<Image>().color = zoneColour;
            if (dz3.droppable == false) dz3.GetComponent<Image>().color = cyanColour;
            else dz3.GetComponent<Image>().color = zoneColour;
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = cyanColour;
            else dz5.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 3)
        {
            if (dz2.droppable == false) dz2.GetComponent<Image>().color = cyanColour;
            else dz2.GetComponent<Image>().color = zoneColour;
            if (dz6.droppable == false) dz6.GetComponent<Image>().color = cyanColour;
            else dz6.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 4)
        {
            if (dz1.droppable == false) dz1.GetComponent<Image>().color = cyanColour;
            else dz1.GetComponent<Image>().color = zoneColour;
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = cyanColour;
            else dz5.GetComponent<Image>().color = zoneColour;
            if (dz7.droppable == false) dz7.GetComponent<Image>().color = cyanColour;
            else dz7.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 5)
        {
            if (dz2.droppable == false) dz2.GetComponent<Image>().color = cyanColour;
            else dz2.GetComponent<Image>().color = zoneColour;
            if (dz4.droppable == false) dz4.GetComponent<Image>().color = cyanColour;
            else dz4.GetComponent<Image>().color = zoneColour;
            if (dz6.droppable == false) dz6.GetComponent<Image>().color = cyanColour;
            else dz6.GetComponent<Image>().color = zoneColour;
            if (dz8.droppable == false) dz8.GetComponent<Image>().color = cyanColour;
            else dz8.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 6)
        {
            if (dz3.droppable == false) dz3.GetComponent<Image>().color = cyanColour;
            else dz3.GetComponent<Image>().color = zoneColour;
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = cyanColour;
            else dz5.GetComponent<Image>().color = zoneColour;
            if (dz9.droppable == false) dz9.GetComponent<Image>().color = cyanColour;
            else dz9.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 7)
        {
            if (dz4.droppable == false) dz4.GetComponent<Image>().color = cyanColour;
            else dz4.GetComponent<Image>().color = zoneColour;
            if (dz8.droppable == false) dz8.GetComponent<Image>().color = cyanColour;
            else dz8.GetComponent<Image>().color = zoneColour;
        }
        else if (position == 8)
        {
            if (dz5.droppable == false) dz5.GetComponent<Image>().color = cyanColour;
            else dz5.GetComponent<Image>().color = zoneColour;
            if (dz7.droppable == false) dz7.GetComponent<Image>().color = cyanColour;
            else dz7.GetComponent<Image>().color = zoneColour;
            if (dz9.droppable == false) dz9.GetComponent<Image>().color = cyanColour;
            else dz9.GetComponent<Image>().color = zoneColour;
        }
        else // (position == 9)
        {
            if (dz6.droppable == false) dz6.GetComponent<Image>().color = cyanColour;
            else dz6.GetComponent<Image>().color = zoneColour;
            if (dz8.droppable == false) dz8.GetComponent<Image>().color = cyanColour;
            else dz8.GetComponent<Image>().color = zoneColour;
        }
    }

    public void Block()
    {
        blockTurns += blockValue;
    }

    public void drawCard()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0) Instantiate(basicCard, playerHand);
        else if (rand == 1) Instantiate(buffCard, playerHand);
        else if (rand == 2) Instantiate(blockCard, playerHand);
    }

    public IEnumerator reduceColour(float time, DropZone zone)
    {
        zone.GetComponent<Image>().color = redColour;
        yield return new WaitForSeconds(time);
        zone.GetComponent<Image>().color = cyanColour;
    }

    public void reduceRandom(int times, int reduction)
    {
        for (int i = 0; i < times; i++)
        {
            while (true)
            {
                float reductionTime = reduction * 0.5f;
                int position = Random.Range(1, 10);
                if (position == 1 && dz1.droppable == false) { dz1.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz1)); break; }
                else if (position == 2 && dz2.droppable == false) { dz2.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz2)); break; }
                else if (position == 3 && dz3.droppable == false) { dz3.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz3)); break; }
                else if (position == 4 && dz4.droppable == false) { dz4.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz4)); break; }
                else if (position == 5 && dz5.droppable == false) { dz5.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz5)); break; }
                else if (position == 6 && dz6.droppable == false) { dz6.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz6)); break; }
                else if (position == 7 && dz7.droppable == false) { dz7.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz7)); break; }
                else if (position == 8 && dz8.droppable == false) { dz8.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz8)); break; }
                else if (position == 9 && dz9.droppable == false) { dz9.zoneScore -= reduction; StartCoroutine(reduceColour(reductionTime, dz9)); break; }
            }
        }
    }

    public void EndBattle()
    {
        if (scoreSum >= battleEnemy.enemyScore)
        {
            //Debug.Log("Victory");
            turn = -1;
            GameManager.instance.battleResult = "Victory";
            GameManager.instance.playerScore += GameManager.instance.enemyAttacker.victoryScore;
            Debug.Log(GameManager.instance.playerScore);
            GameManager.instance.enemyAttacker.defeatedEnemy();
            GameManager.instance.enemyAttacker = null;
            GameManager.instance.enemiesDefeated += 1;
            if (battleEnemy.enemyClass == "Witch")
            {
                SceneManager.LoadScene("FinalVictory");
            }
        }
        else
        {
            //Debug.Log("Failure");
            turn = -1;
            GameManager.instance.battleResult = "Defeat";
            GameManager.instance.playerHealthCurrent -= GameManager.instance.enemyAttacker.playerDamage;
            if (battleEnemy.enemyClass == "Witch")
            {
                SceneManager.LoadScene("FinalScene");
            }
            else if (GameManager.instance.playerHealthCurrent <= 0)
            {
                GameManager.instance.GameOver();
            }
        }

        if (battleEnemy.enemyClass != "Witch")
        {
            Scene battle = SceneManager.GetSceneByName("Battle");
            //Scene main = SceneManager.GetSceneByName("Main");
            //SceneManager.SetActiveScene(main);
            GameManager.instance.playersTurn = true;
            SceneManager.UnloadSceneAsync(battle);
            GameManager.instance.inBattle = false;
        }
    }
}
