using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemySprite : MonoBehaviour
{
    public string enemyClass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.enemyAttacker.enemyClass != enemyClass)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
