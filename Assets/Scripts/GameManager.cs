using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                        //Time to wait before starting level, in seconds.
    public float turnDelay = 0.25f;                            //Delay between each Player turn.
    public int playerHealthMax = 3;                        //Starting value for Player food points.
    public int playerHealthCurrent;
    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    [HideInInspector] public bool playersTurn = true;         //Boolean to check if it's players turn, hidden in inspector but public.

    public int gPlayerStart = 0;
    public int gBasicValue = 1;
    public int gBuffValue = 1;
    public int gBlockValue = 1;
    public int playerScore = 0;
    public int playerUpgrades = 0;

    private BoardManager boardScript;                         //Store a reference to our BoardManager which will set up the level.
    public int level = 1;                                    //Current level number, expressed in game as "Day 1".
    private List<Enemy> enemies;                              //List of all Enemy units, used to issue them move commands.
    private bool enemiesMoving;                               //Boolean to check if enemies are moving.
    public bool inBattle = false;
    public int enemiesDefeated = 0;

    [HideInInspector] public Enemy enemyAttacker;
    public Enemy FinalBoss;
    [HideInInspector] public string battleResult = null;

    [HideInInspector] public string enemyType = "Small";

    //Awake is always called before any Start functions
    void Awake()
    {
        //instance used to make sure only one instance of GameManager exists at any one point (Keeping track of score etc)
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Assign enemies to a new List of Enemy objects.
        enemies = new List<Enemy>();

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        playerHealthCurrent = playerHealthMax;

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.activeSceneChanged += OnSceneWasSwitched;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            InitGame();

            level++;
        }
        if (scene.name == "Battle")
        {
            BattleManager battleManager = GameObject.Find("battleManager").GetComponent<BattleManager>();
            battleManager.basicValue = gBasicValue;
            battleManager.buffValue = gBuffValue;
            battleManager.blockValue = gBlockValue;
            battleManager.playerStart = gPlayerStart;
            BattleEnemy battleEnemy = GameObject.Find("battleEnemy").GetComponent<BattleEnemy>();
            battleEnemy.enemyClass = enemyAttacker.enemyClass;
        }
    }

    void OnSceneWasSwitched(Scene currentScene, Scene nextScene)
    {
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Clear any Enemy objects in our List to prepare for next level.
        enemies.Clear();

        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene(level);

    }

    //Update is called every frame.
    void Update()
    {
        //Check that playersTurn or enemiesMoving are not currently true.
        if (playersTurn || enemiesMoving || inBattle)
        {
            //If any of these are true, return and do not start MoveEnemies.
            return;
        }    

        //Start moving enemies.
        StartCoroutine(MoveEnemies());
    }

    //Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddEnemyToList(Enemy script)
    {
        //Add Enemy to List enemies.
        enemies.Add(script);
    }


    //GameOver is called when the player reaches 0 health
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //Coroutine to move enemies in sequence.
    IEnumerator MoveEnemies()
    {
        //While enemiesMoving is true player is unable to move.
        enemiesMoving = true;

        //Wait for turnDelay seconds, defaults to .1 (100 ms).
        yield return new WaitForSeconds(turnDelay);

        //If there are no enemies spawned (IE in first level):
        if (enemies.Count == 0)
        {
            //Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
            yield return new WaitForSeconds(turnDelay);
        }
        else
        {
            //Loop through List of Enemy objects.
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    //Call the MoveEnemy function of Enemy at index i in the enemies List.
                    enemies[i].MoveEnemy();
                }
                else
                {
                    enemies.Remove(enemies[i]);
                }
                //Wait for Enemy's moveTime before moving next Enemy, 
                yield return new WaitForSeconds(turnDelay);
            }
            yield return new WaitForSeconds(turnDelay);
        }
        //Once Enemies are done moving, set playersTurn to true so player can move.
        playersTurn = true;

        //Enemies are done moving, set enemiesMoving to false.
        enemiesMoving = false;
    }

    public void finalBattle()
    {
        enemyAttacker = FinalBoss;
        SceneManager.LoadScene("PreWitchBattle");
    }
}
