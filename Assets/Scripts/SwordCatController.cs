using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCatController : MonoBehaviour 
{
    public int maxHealth;
    public float timeInvincible = 2.0f;

    public int health { get { return _currentHealth; } }//property definition, with get is read only
    int _currentHealth;

    bool _isInvincible;
    float _invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal, vertical;

    public float mySpeed;

    Animator catAnimator;
    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject projectilePrefab;

    // Class means defining a new component, in this case SwordCatController
    void Start()
    {
        /* the two lines below is to demonstrate how to control the speed of your game so that it’s the same on any machine.
            Your character now runs at the same speed, regardless of the number of frames rendered by our game. 
            It’s now “frame independent”.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;*/

        rigidbody2d = GetComponent<Rigidbody2D>();
        _currentHealth = maxHealth;
        catAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*because we added Rigidbody, we can create the variables at the start, thus we won't need them here
        float horizontal = Input.GetAxis("Horizontal"); //we call GetAxis inside Input, which is a function in Unity
        float vertical = Input.GetAxis("Vertical");
        */
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        /*also, we move the lines below to the FixedUpdate function
        Vector2 position = transform.position; //declared a var of type Vector2 called position
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;//floating point, float type
        position.y = position.y + 3.0f * vertical * Time.deltaTime; //Character moves 3 units per second
        transform.position = position;    
        */

        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        catAnimator.SetFloat("Move X", lookDirection.x);
        catAnimator.SetFloat("Move Y", lookDirection.y);
        catAnimator.SetFloat("Speed", move.magnitude);

        if (_isInvincible)
        {
            _invincibleTimer -= Time.deltaTime;
            if (_invincibleTimer < 0)
                _isInvincible = false;
        }

        if (_currentHealth < (maxHealth / 10))
            NeedHealth();

        if (Input.GetKeyDown(KeyCode.C))
            Launch();
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        /*I can specify the speed here
         * position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;
        or i can create the public var, assign the speed in the inspector/Unity and then use that var in the line of code as per below*/
        position.x = position.x + mySpeed * horizontal * Time.deltaTime;
        position.y = position.y + mySpeed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    //void means what value the function will return, in this case nothing, because
    //it just changes the Health
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            catAnimator.SetTrigger("SwordCatHit");
            if (_isInvincible)
                return;

            _isInvincible = true;
            _invincibleTimer = timeInvincible;
        }

        //Matchf.Clamp is a built-in function in which the var will not go below 0 and above the maxHealth
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
        Debug.Log(_currentHealth + "/" + maxHealth);
    }

    void NeedHealth()
    {
        Debug.Log("Your health is low! eat strawberries!");
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        catAnimator.SetTrigger("Launch");
    }
}
