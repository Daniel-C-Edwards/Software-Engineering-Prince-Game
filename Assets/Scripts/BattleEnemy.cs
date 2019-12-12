using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleEnemy : MonoBehaviour
{
    public BattleManager battleManager;

    public string enemyClass = "Small";

    public TextMeshProUGUI enemyActionText;
    public TextMeshProUGUI enemyScoreText;
    public int enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        enemyActionText.text = (" ");

        enemyScore = GameManager.instance.enemyAttacker.startingValue;
    }

    // Update is called once per frame
    void Update()
    {
        enemyScoreText.text = ("Enemy power: " + enemyScore.ToString());
    }

    public void EnemyTurn()
    {
        //Debug.Log("Enemy turn");
        int enemyAction;
        enemyAction = Random.Range(1, 101);
        if (enemyClass == "Small")
        {
            if (1 <= enemyAction && enemyAction <= 20)
            {
                enemyScore += 1;
                enemyActionText.text = ("The monster focuses on you.");
            }
            else if (21 <= enemyAction && enemyAction <= 40)
            {
                enemyScore += 1;
                enemyActionText.text = ("The monster looks at you menanacingly.");
            }
            else if (41 <= enemyAction && enemyAction <= 70)
            {
                enemyScore += 2;
                enemyActionText.text = ("The monster plans its next move.");
            }
            else if (71 <= enemyAction && enemyAction <= 90)
            {
                enemyScore += 3;
                enemyActionText.text = ("The monster plots your demise.");
            }
            else // 91 - 100
            {
                enemyScore += 3;
                enemyActionText.text = ("The monster swings at you.");
                battleManager.reduceRandom(1, 1);
            }
        }
        else if (enemyClass == "Medium")
        {
            if (1 <= enemyAction && enemyAction <= 20)
            {
                enemyScore += 1;
                enemyActionText.text = ("The monster focuses its strength.");
            }
            else if (21 <= enemyAction && enemyAction <= 40)
            {
                enemyScore += 2;
                enemyActionText.text = ("The monster glares at you.");
            }
            else if (41 <= enemyAction && enemyAction <= 80)
            {
                enemyScore += 2;
                enemyActionText.text = ("The monster jumps at you.");
                battleManager.reduceRandom(1, 1);
            }
            else if (81 <= enemyAction && enemyAction <= 90)
            {
                enemyScore += 3;
                enemyActionText.text = ("The monster swings its tail at you.");
                battleManager.reduceRandom(2, 1);
            }
            else // 91 - 100
            {
                enemyScore += 2;
                enemyActionText.text = ("The monster slashes at you twice.");
                battleManager.reduceRandom(2, 2);
            }
        }
        else if (enemyClass == "Large")
        {
            if (1 <= enemyAction && enemyAction <= 20)
            {
                enemyScore += 2;
                enemyActionText.text = ("The monster looses an ear splitting screech.");
                battleManager.reduceRandom(1, 2);
            }
            else if (21 <= enemyAction && enemyAction <= 40)
            {
                enemyScore += 3;
                enemyActionText.text = ("The monster summons a rockslide.");
                battleManager.reduceRandom(1, 4);
            }
            else if (41 <= enemyAction && enemyAction <= 80)
            {
                enemyScore += 3;
                enemyActionText.text = ("The monster summons a rainstorm.");
                battleManager.reduceRandom(2, 2);
            }
            else if (81 <= enemyAction && enemyAction <= 90)
            {
                enemyScore += 3;
                enemyActionText.text = ("The monster summons a tornado.");
                battleManager.reduceRandom(2, 3);
            }
            else // 91 - 100
            {
                enemyScore += 2;
                enemyActionText.text = ("The monster summons a firestorm.");
                battleManager.reduceRandom(3, 3);
            }
        }
        else if (enemyClass == "Witch")
        {
            if (1 <= enemyAction && enemyAction <= 20)
            {
                enemyScore += 4;
                enemyActionText.text = ("The witch cackles manically.");
                battleManager.reduceRandom(2, 2);
            }
            else if (21 <= enemyAction && enemyAction <= 40)
            {
                enemyScore += 4;
                enemyActionText.text = ("The witch's familiar attacks you.");
                battleManager.reduceRandom(2, 4);
            }
            else if (41 <= enemyAction && enemyAction <= 80)
            {
                enemyScore += 4;
                enemyActionText.text = ("The witch throws a potion at you.");
                battleManager.reduceRandom(3, 4);
            }
            else if (81 <= enemyAction && enemyAction <= 90)
            {
                enemyScore += 5;
                enemyActionText.text = ("The witch begins cursing you.");
                battleManager.reduceRandom(3, 4);
            }
            else // 91 - 100
            {
                enemyScore += 6;
                enemyActionText.text = ("The witch casts a spell.");
                battleManager.reduceRandom(4, 5);
            }
        }

        battleManager.playerTurn = true;
    }
}
