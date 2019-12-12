using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finalScore : MonoBehaviour
{
    TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = this.gameObject.GetComponent<TextMeshProUGUI>();
        Text.text = ("Final score: " + GameManager.instance.playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
