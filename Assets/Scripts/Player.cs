using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public GameObject whiteSquare;

    GameController gameController;

    public AudioSource aus;

    public AudioClip shootingSound;

    public Transform shootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isGameOver())
            return;

        // left -1 right 1 
        float xDirection = Input.GetAxisRaw("Horizontal");

        if ((xDirection < 0 && transform.position.x < -9f) || (xDirection > 0 && transform.position.x > 9f))
            return;

        transform.position -= moveSpeed * Vector3.left * xDirection * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot() { 
        if(whiteSquare && shootingPoint)
        {
            if(aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(whiteSquare, shootingPoint.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.setIsGameOverState(true);

            Destroy(collision.gameObject);
        }
    }
}
