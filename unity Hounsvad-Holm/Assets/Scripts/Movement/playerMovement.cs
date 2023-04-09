using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    public AudioClip walkingSound;
    public float volume = 0.1f;
    public float minVelocity = 10f;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }


    void Update()
    {
        //Basic player movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        //Player is spriting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float sprintingSpeed = speed * 1.25f;
            rb.velocity = moveDir * sprintingSpeed;
            Debug.Log("-Sprinting-" + sprintingSpeed);
        }

        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }

        //Walking sound
        if (rb.velocity.magnitude > minVelocity && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(walkingSound, volume);
        }
        if (rb.velocity.magnitude < minVelocity && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        
        
    }
}
