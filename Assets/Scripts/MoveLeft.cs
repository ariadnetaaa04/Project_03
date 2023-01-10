using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15f;
    public float leftBound = -7f;

    private PlayerController playerControllerScript; //comunicacion entre scripts

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript =FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
            
        
    }
}
