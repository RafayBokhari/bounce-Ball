using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Highfloor;
    public float defaultjump;
    public float currentjump;
    public bool CanJump;
    public float MoveSpeed;
    public Vector3 originalsize;
    public Vector3 level3 = new Vector3(8,8,8); 
    public Vector3 ballsize = new Vector3(6.5f, 6.5f, 6.5f);
    public int currentlevell;
    public float largeSizeThreshold = 1.5f;
    public float buoyantForce = 5.0f;
    public float smallBuoyantMultiplier = 0.1f;
    public float flashVelocity = 10f;
    public float flashDuration = 2f; 
    private Vector2 originalVelocity;
    public float smalljump;
    public float waterspeed;
   // public float defaultspeed;
    public bool moveright;
    public bool moveLeft;
   
    public bool ismove = false;

    // Start is called before the first frame update
    void Start()
    {
       // MoveSpeed = defaultspeed;
       currentjump = defaultjump;
        rb = GetComponent<Rigidbody2D>();
      
        originalsize = transform.localScale; 
        if(currentlevell == 3)
        {
            transform.localScale = level3;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (moveright)
        {
            rb.velocity = new Vector2(MoveSpeed* Time.deltaTime, rb.velocity.y);
        }

        else if (moveLeft)

        {
            rb.velocity = new Vector2(-MoveSpeed * Time.deltaTime, rb.velocity.y);

        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
    }

    public void JumpButton()
    {
        if(CanJump)
        {
            rb.AddForce(Vector2.up * currentjump, ForceMode2D.Impulse);

        }
    }

    public void OnPressRightButton()
    {
        moveright = true;
    }

    public void OnReleaseRightButton()
    {
        moveright = false;
    }

    public void OnPressLeftButton()
    {
        moveLeft = true;
    }

    public void OnReleaseLeftButton()
    {
        moveLeft = false;
    }

   
    //public void Stopmoving()
    //{
    //    Debug.Log("drag");
    //  // rb.angularDrag = normalDrag;
    //    rb.AddForce(new Vector2(0, rb.velocity.y));

    //}

    public void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Ground"))

        {
            Debug.Log("Ground");
            CanJump = true;
           currentjump = defaultjump;
           // MoveSpeed = defaultspeed;
            ismove = true;
        }
        if (other.gameObject.CompareTag("Finish"))

        {
            currentjump = smalljump;
            Debug.Log("Finish");
            CanJump = true;
           // MoveSpeed = defaultspeed;
        }
       
        if(other.gameObject.CompareTag("Enemy"))
        {
            Reloadlevel();
        }
        if(other.gameObject.CompareTag("Size"))
        {
            transform.localScale = ballsize;
        }
        if(other.gameObject.CompareTag("Unsize"))
        {
            transform.localScale = originalsize;
           CanJump = true;
            currentjump = defaultjump;

        }
        if(other.gameObject.CompareTag("High"))
        {
            CanJump = true;
            currentjump = Highfloor;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            if (transform.localScale.x > largeSizeThreshold)
            {
                rb.AddForce(Vector2.up * buoyantForce);
            }
            else
            {
                rb.AddForce(Vector2.up * (buoyantForce *smallBuoyantMultiplier));
            }
            MoveSpeed = waterspeed;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("NOt Ground");

            CanJump = false;
        }
        if (collision.gameObject.CompareTag("Finish"))

        {
            if(!CanJump)
            {
                CanJump = true;

            }
        }
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            UIManager.Instance.ballscoree();
            Destroy(collision.gameObject,0.4f);
            AudioManager.Instance.ballaudio();
        }

        if(collision.gameObject.CompareTag("Level1"))
        {
            nextlevel();
        }

        if (collision.gameObject.CompareTag("Flash"))
        {
            Debug.Log("flash");
            originalVelocity = rb.velocity;
            StartCoroutine(FlashEffect());
        }

        if(collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(collision.gameObject,0.4f);
            AudioManager.Instance.gem();
        }


    }
    IEnumerator FlashEffect()
    {
        rb.velocity = new Vector2(flashVelocity, 0);
        yield return new WaitForSeconds(flashDuration);
        rb.velocity = originalVelocity;
    }


        public void Reloadlevel()
    {
         int currentindex = SceneManager.GetActiveScene().buildIndex;
         SceneManager.LoadScene(currentindex);

    }

    public void nextlevel ()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        int nextscene = currentindex + 1;

        if (nextscene == SceneManager.sceneCountInBuildSettings)
        {
            nextscene = 0;
        }
        SceneManager.LoadScene(nextscene);

    }

}
