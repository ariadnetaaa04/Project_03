using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variable que guarda la info del rigidbody
    private Rigidbody _rigidbody;

    public float jumpForce = 10;
    
    private bool isOnTheGround = true;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    
    private void OnCollisionEnter(Collision otherCollider)
    {
        isOnTheGround = true;
    }
}
