using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Player Score").GetComponent<TextMeshProUGUI>();
        Text.text = ("Score: " + GameManager.instance.playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = ("Score: " + GameManager.instance.playerScore);
    }
}
