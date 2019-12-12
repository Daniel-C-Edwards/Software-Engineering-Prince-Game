using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;        //Allows us to use SceneManager

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class Player : MovingObject
{
    public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.
    public int pointsPerFood = 10;              //Number of points to add to player food points when picking up a food object.
    public int wallDamage = 1;                  //How much damage a player does to a wall when chopping it.


    private Animator animator;                  //Used to store a reference to the Player's animator component.


    //Start overrides the Start function of MovingObject
    protected override void Start()
    {
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();

        //Call the Start function of the MovingObject base class.
        base.Start();
    }


    //This function is called when the behaviour becomes disabled or inactive.
    private void OnDisable()
    {

    }


    private void Update()
    {
        //If it's not the player's turn, exit the function.
        if (!GameManager.instance.playersTurn || GameManager.instance.inBattle) return;

        int horizontal = 0;      //Used to store the horizontal move direction.
        int vertical = 0;        //Used to store the vertical move direction.


        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }

        //Check if we have a non-zero value for horizontal or vertical
        if (horizontal != 0 || vertical != 0)
        {
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            AttemptMove<Enemy>(horizontal, vertical);
        }
    }

    //AttemptMove overrides the AttemptMove function in the base class MovingObject
    //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        if(GameManager.instance.playerScore > 0)
        {
            //Every time player moves, subtract from score.
            GameManager.instance.playerScore -= 1;
        }

        //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
        base.AttemptMove<T>(xDir, yDir);

        //Hit allows us to reference the result of the Linecast done in Move.
        RaycastHit2D hit;

        //If Move returns true, meaning Player was able to move into an empty space.
        if (Move(xDir, yDir, out hit))
        {
            //Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
        }

        //Since the player has moved and lost food points, check if the game has ended.
        CheckIfGameOver();

        //Set the playersTurn boolean of GameManager to false now that players turn is over.
        GameManager.instance.playersTurn = false;
    }


    //OnCantMove overrides the abstract function OnCantMove in MovingObject.
    //It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
    protected override void OnCantMove<T>(T component)
    {
        GameManager.instance.inBattle = true;

        Enemy enemy = component as Enemy;
        //Transform enemyObject = enemy.transform.parent;
        GameManager.instance.enemyAttacker = enemy;

        //Debug.Log("Hiijah");

        animator.SetTrigger("playerChop");

        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
    }


    //OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Exit")
        {
            GameManager.instance.playerScore += 20;
            //Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            SceneManager.LoadScene("Main");

            //Disable the player object since level is over.
            enabled = false;
        }

        if (other.tag == "Chest")
        {
            GameManager.instance.playerScore += 100;

            other.gameObject.GetComponent<UpgradeChest>().UpgradeChestStart(GameManager.instance.playerUpgrades);            

            //Disable the player object since level is over.
            enabled = false;
        }

        //Check if the tag of the trigger collided with is Food.
        if (other.tag == "Food")
        {
            //Add pointsPerFood to the players current food total.
            GameManager.instance.playerScore += pointsPerFood;

            //Disable the food object the player collided with.
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Heart")
        {
            if (GameManager.instance.playerHealthCurrent < GameManager.instance.playerHealthMax)
            {
                GameManager.instance.playerHealthCurrent += 1;

                other.gameObject.SetActive(false);
            }
        }
    }


    //Restart reloads the scene when called.
    private void Restart()
    {
        //Load the last scene loaded, in this case Main, the only scene in the game.
        SceneManager.LoadScene("Main");
    }


    //LoseFood is called when an enemy attacks the player.
    //It takes a parameter loss which specifies how many points to lose.
    public void LoseFood(int loss)
    {
        //Set the trigger for the player animator to transition to the playerHit animation.
        animator.SetTrigger("playerHit");

        //Check to see if game has ended.
        CheckIfGameOver();
    }


    //CheckIfGameOver checks if the player is out of food points and if so, ends the game.
    private void CheckIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        if (GameManager.instance.playerHealthCurrent <= 0)
        {

            //Call the GameOver function of GameManager.
            GameManager.instance.GameOver();
        }
    }
}
