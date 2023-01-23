using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool gameOver;
    public float gravityMultiplier = 1.5f;

    //particulas 
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    //variable que guarda la info del rigidbody
    private Rigidbody _rigidbody;
    [SerializeField]
    private bool isOnTheGround = true;

    //animacion 
    private Animator _animator;
    public float gravityModifier = 1.5f;

    //audio
    public AudioClip[] jumpSounds; //si solo queremos un solo audio le quitamos el []
    public AudioClip[] crashSounds;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            //audio unico para el salto
            //_audioSource.PlayOneShot(jumpSounds, 1);

            //audio aleatorio
            Jump();
            ChooseRandomSFX(jumpSounds);
        }

    }


    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherCollider.gameObject);
            GameOver();
        }
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int",Random.Range (1,3));
        explosionParticle.Play();
        dirtParticle.Stop();
        //audio unico para el crash
        // _audioSource.PlayOneShot(crashSounds, 1);
        ChooseRandomSFX(crashSounds);
    }
    private void Jump()
    {
        isOnTheGround = false; //deja de tocar el suelo
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // Llamamos al trigger para que se dé la transición de la animación de correr a salto
        _animator.SetTrigger("Jump_trig");
        dirtParticle.Stop();
    }
    private void ChooseRandomSFX(AudioClip[] sounds)
    {
        //audio aleatorio
        int randomIdx = Random.Range(0, sounds.Length);
        _audioSource.PlayOneShot(sounds[randomIdx], 1);
    }



}
   
