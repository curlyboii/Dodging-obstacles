using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject enemy;
    public Transform spawnPoint;
    public float maxSpawnPointX; // spawn enemy X position

    bool gameStarted = false;
    int score = 0;

    public Text scoreText;


    public static GameManager instance; // By declaring a public static variable called "Instance," we can access
                                        // the GameManager from anywhere in the game without needing to create a new instance
                                        // of the GameManager class every time we need to use it.

    /// <summary>
    /// In this code, we are checking if the static variable "instance" is null.
    /// If it is null, it means that there is no instance of the GameManager class created yet,
    /// so we set the value of "instance" to "this," which is a reference to the current
    /// instance of the GameManager class.
    /// </↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓>
    private void Awake() // Singleton design pattern in Unity using C#
    {
        
        
        if (instance == null)
        {

            instance = this;
        
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && !gameStarted) // if you press any key, game just started
        {

            scoreText.gameObject.SetActive(true);


            StartCoroutine("SpawnEnemies");
            gameStarted = true;

        }


    }


    /// <summary>
    /// This is a coroutine that spawns enemies repeatedly with a delay of 0.8 seconds between spawns.
    /// The while loop is infinite and will continue to spawn enemies until the game is stopped. 
    /// The "yield return new WaitForSeconds(0.8f);" line waits for 0.8 seconds before executing the "Spawn()" method, 
    /// which actually instantiates the enemy prefab.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemies()
    { 
    
        while (true) 
        {
            yield return new WaitForSeconds(0.8f);
            Spawn();
        
        }
    
    }

    public void Spawn()
    {

        float randomSpawnX = Random.Range(-maxSpawnPointX, maxSpawnPointX);

        Vector3 enemySpawnPos= spawnPoint.position;
        enemySpawnPos.x = randomSpawnX;

        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
    
    
    }

    public void Restart()
    {

        SceneManager.LoadScene(0);
    
    }

    public void ScoreUp()
    {

        score++;
        scoreText.text = score.ToString();
    
    }
}
