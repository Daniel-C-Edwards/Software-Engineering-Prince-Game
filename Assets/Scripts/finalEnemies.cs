using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finalEnemies : MonoBehaviour
{
    TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = this.gameObject.GetComponent<TextMeshProUGUI>();
        Text.text = ("Monsters defeated: " + GameManager.instance.enemiesDefeated);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
