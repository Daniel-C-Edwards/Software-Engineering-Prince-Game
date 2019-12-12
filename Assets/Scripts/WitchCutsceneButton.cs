using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WitchCutsceneButton : MonoBehaviour
{
    public void ContinueBattle()
    {
        SceneManager.LoadScene("Battle");
    }
}
