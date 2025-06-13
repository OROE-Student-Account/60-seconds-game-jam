using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject gameManager;
    private int currentTile;
    private GameObject newTile;
    public int gameMode;
    public bool testing;
    public bool coinOrKill;
    public GameObject persistentData;


    public void PerformTurn()
    {
        // Rolls the dice and moves you forward that much
        currentTile += gameManager.GetComponent<GameManager>().RollDice();

        // The locations of the shortcuts
        if (currentTile == 3)
        {
            currentTile = 15;
        }
        else if (currentTile == 12)
        {
            currentTile = 26;
        }
        else if (currentTile == 25)
        {
            currentTile = 33;
        }
        else if (currentTile>48)
        {
            // Change this 
            currentTile = 0;
        }

        // Finds what tile you landed on and moves your there
        newTile = gameManager.GetComponent<GameManager>().tiles[currentTile];
        Vector3 newTilePosition = newTile.transform.position;
        transform.position = new Vector3(
            newTilePosition.x,
            0, newTilePosition.z);

        Invoke("AllowReroll",3);
        

    }

    private void AllowReroll() 
    {
        gameMode = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameMode==2)
        {
            transform.gameObject.GetComponent<CountDown>().enabled = true;
        }
        else if (coinOrKill)
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
        
    }

    private void RestorePosition()
    {
        if (persistentData.GetComponent<PersistentData>().playerTile == -1)
        {
            currentTile = 0;
        }
        else
        {
            currentTile = persistentData.GetComponent<PersistentData>().playerTile;
        }

        newTile = gameManager.GetComponent<GameManager>().tiles[currentTile];
        Vector3 newTilePosition = newTile.transform.position;
        transform.position = new Vector3(
            newTilePosition.x,
            0, newTilePosition.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        RestorePosition();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test");
        float height = -0.25f;
        // Player movement on board

        if (Input.GetKeyDown(KeyCode.W) && gameMode == 0)
        {
            PerformTurn();
            gameMode = 2;
        }

        // Player movement in minigames
        if (Input.GetKey(KeyCode.W) && gameMode == 1)
        {
            transform.position = new Vector3(transform.position.x, height, transform.position.z - 0.12f);
        }

        if (Input.GetKey(KeyCode.S) && gameMode == 1)
        {
            transform.position = new Vector3(transform.position.x, height, transform.position.z + 0.12f);
        }

        if (Input.GetKey(KeyCode.A) && gameMode == 1)
        {
            transform.position = new Vector3(transform.position.x + 0.12f, height, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D) && gameMode == 1)
        {
            transform.position = new Vector3(transform.position.x - 0.12f, height, transform.position.z);
        }

        transform.rotation = new Quaternion(0,0,0,1);



    }
}
