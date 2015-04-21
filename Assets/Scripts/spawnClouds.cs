using UnityEngine;
using System.Collections;

public class spawnControl : MonoBehaviour
{
    public GameObject[] enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public int maxEnemigos;
    private int actualEnemies;
    private bugData player;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<bugData>();
    }


    void Spawn()
    {
        actualEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
		maxEnemigos = player.nivel * 10;
        if (actualEnemies<maxEnemigos)
        {
            actualEnemies++;
        // If the player has no health left...
            if (player.getVidaActual() <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
            //int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int enemyRandom = Random.Range(0,enemy.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy[enemyRandom], new Vector3(transform.position.x, transform.position.y+11, 0), Quaternion.identity);
        }
        //Debug.Log("Enemigos: " + actualEnemies);
    }
}
