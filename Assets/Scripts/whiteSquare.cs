using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteSquare : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public float timeToDestroy;

    Rigidbody2D m_rb;

    GameController gameController;

    public AudioClip hitSound;

    AudioSource aus;

    public GameObject hitVFX;

    // Start is called before the first frame update
    void Start()
        {

        aus = FindObjectOfType<AudioSource>();
        m_rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, timeToDestroy);
            gameController = FindObjectOfType<GameController>();
        }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed;


    }

   

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            if (aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }
            if (hitVFX)
            {
                GameObject hitVFXclone =  Instantiate(hitVFX,coll.transform.position,Quaternion.identity);

                Destroy(hitVFXclone,1);
            }
            
            gameController.scoreIncrement();

            Destroy(gameObject);

            Destroy(coll.gameObject);
           
        }else if (CompareTag("ScenesTagLimit"))
        {
            Destroy(gameObject);
        }
    }
}
