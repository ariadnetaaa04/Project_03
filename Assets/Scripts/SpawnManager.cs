using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private PlayerController playerControllerScript;
   

    private float startDelay = 2f;
    private float repeatRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }

    private void SpawnObstacle()
    {
        int randomIdx = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIdx], transform.position, obstaclePrefabs[randomIdx].transform.rotation); //un array no tiene transform por lo tanto tenemos que poner el RandomIdx para decirle que agarre el transform del prefab aleatorio elegido.
    }

}
