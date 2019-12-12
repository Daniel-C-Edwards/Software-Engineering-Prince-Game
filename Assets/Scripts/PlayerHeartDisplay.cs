using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartDisplay : MonoBehaviour
{
    public int healthLimit;
    private Image image;
    private Color fullColour;
    private Color invisColour;

    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        fullColour = image.color;
        invisColour = image.color;
        invisColour.a = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.playerHealthCurrent < healthLimit)
        {
            image.color = invisColour;
        }
        else
        {
            image.color = fullColour;
        }
    }
}
