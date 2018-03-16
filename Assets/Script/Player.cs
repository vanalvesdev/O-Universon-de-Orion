using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed;
    public Sprite childShip;
    public Sprite parentShip;
    public Sprite childShip3;
    public Sprite parentShip3;
    public Sprite childBarLife;
    public Sprite parentBarLife;
    private Rigidbody2D rb;
    public bool canMove = false;
    public bool respawn = false;
    public bool sideMove = false;
    public bool freezeY = false;
    public bool canShoot = false;
    public float timeToShoot;
    private float currentTimeShoot;
    public GameObject bullet;
    private Transform childPosition;
    private Transform parentPosition;
    private Vector3 initialPosition;
    private Vector2 lastTouch;
    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        childPosition = GameObject.Find("ChildPosition").GetComponent<Transform>();
        parentPosition = GameObject.Find("ParentPosition").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (canMove)
        {

            if(Input.touchCount >= 1)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase.Equals(TouchPhase.Ended) || touch.phase.Equals(TouchPhase.Canceled))
                {
                    lastTouch = Vector2.zero;
                } else if (touch.phase.Equals(TouchPhase.Moved))
                {
                    Vector2 deslocamento = touch.position - lastTouch;
                    lastTouch = touch.position;
                    if (!sideMove)
                    {
                        rb.MovePosition(rb.position + deslocamento * (speed / 100));
                    }
                    else
                    {
                        Vector2 newPosition = rb.position + deslocamento * (speed / 100);
                        rb.MovePosition(new Vector2(newPosition.x, rb.position.y));
                    }
                    
                } else if (touch.phase.Equals(TouchPhase.Began))
                {
                    lastTouch = touch.position;
                }
            }
            
        }else if (respawn)
        {
            respawn = false;
            canMove = true;
            transform.position = initialPosition;
        }

        if (freezeY) { 
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.freezeRotation = true;
        }

        if (canShoot)
        {
            currentTimeShoot += Time.deltaTime; 
            if(currentTimeShoot >= timeToShoot)
            {
                currentTimeShoot = 0;
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }

    }
    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Boundary")
            rb.velocity = Vector2.zero;

    }


    public void setupShip(bool isChild)
    {
        if (isChild)
        {
            GetComponent<SpriteRenderer>().sprite = childShip;
            transform.position = childPosition.position;
            initialPosition = childPosition.position;
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = childBarLife;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = parentShip;
            transform.position = parentPosition.position;
            initialPosition = parentPosition.position;
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = parentBarLife;
        }
    }

    public void setupShipNivel3(bool isChild)
    {
        if (isChild)
        {
            GetComponent<SpriteRenderer>().sprite = childShip3;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = parentShip3;
        }
    }


    public void respawnPlayer()
    {
        if(initialPosition != null)
            transform.position = initialPosition;
    }
}
