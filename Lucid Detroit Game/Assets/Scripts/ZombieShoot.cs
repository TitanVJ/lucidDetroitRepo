using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShoot : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Attacking,
        Patrol,
        Dead
    }

    private EnemyState _currState = EnemyState.Idle;

    public GameObject playerObj;
    public float attackDistance = 7.0f;
    public float retreatDistance = 15.0f;
    public float moveSpeed = 5.0f;
    public GameObject bulletPre;
    private float bulletSpeed;
    public Transform spawnPoint;
    private List<GameObject> bullets = new List<GameObject>();
    private SpriteRenderer bulletRenderer;
    private GameObject goBullets;
    private Rigidbody2D rBody;
    private Rigidbody2D zBody;
    private SpriteRenderer playerRenderer;
    private Vector3 flipPos;
    private Animator anim;
    private zombieManager zombieManager;

    // Use this for initialization
    void Start()
    {
        bulletSpeed = 3.0f;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        bulletRenderer = GetComponentInChildren<SpriteRenderer>();
        playerRenderer = GetComponent<SpriteRenderer>();
        flipPos = spawnPoint.transform.localPosition;
        zBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currState)
        {
            case EnemyState.Idle:
                IdleUpdate();
                break;
            case EnemyState.Attacking:
                AttackingUpdate();
                break;
            case EnemyState.Patrol:
                PatrolUpdate();
                break;
            case EnemyState.Dead:
                DeadUpdate();
                break;
            default:
                break;
        }

        for (int i = 0; i < bullets.Count; i++)
        {

            goBullets = bullets[i];

            if (goBullets != null)
            {
                /*if(sRenderer.flipX != true)
                    goBullets.transform.Translate(new Vector3(10, 0) * Time.deltaTime * bulletSpeed);
                else
                    goBullets.transform.Translate(new Vector3(-10, 0) * Time.deltaTime * bulletSpeed);*/

                //Removing bullets that go off screen
                Vector3 bulletScreenView = Camera.main.WorldToScreenPoint(goBullets.transform.position);
                if (bulletScreenView.x >= Screen.width || bulletScreenView.x <= 0)
                {
                    DestroyObject(goBullets);
                    bullets.Remove(goBullets);
                }
            }
        }
        Debug.Log(Vector3.Distance(transform.position, playerObj.transform.position));
        Debug.Log(attackDistance);
    }

    private void ChangeState(EnemyState newState)
    {
        ExitState(_currState);
        _currState = newState;
        EnterState(_currState);
    }

    private void ExitState(EnemyState oldState)
    {

    }

    private void EnterState(EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.Patrol:
                break;
            case EnemyState.Dead:
                // Generate particle system.

                break;
            default:
                break;
        }
    }

    private void IdleUpdate()
    {
        if (IsPlayerWithinRange())
        {
            ChangeState(EnemyState.Attacking);
            return;
        }

        // Check for if patrol path exists.
        // Transition to PatrolState if so.

        // Run idle animation
        // Maybe turn randomly.
    }

    private void AttackingUpdate()
    {
        // Targeting the player and moving towards it
        MoveTowardsTarget(playerObj.transform.position);
        StartCoroutine(attackSpeed());
        anim.SetBool("Throw", true);


        if (zBody.velocity.x < 0)
        {
            Debug.Log("less!");
            if (playerRenderer.flipX != true)
                flipPos.x = -(flipPos.x);
            playerRenderer.flipX = true;
        }
        //else if (zBody.velocity.x > 0)
        //{
        //    Debug.Log("MORE!");
        //    if (playerRenderer.flipX != false)
        //        flipPos.x *= -1;
        //    spawnPoint.transform.localPosition = flipPos;
        //}
        // Once with a certain distance do something.
        // Or maybe just try to collide with the player.

        if (IsPlayerEscaped())
        {
            ChangeState(EnemyState.Idle);
            return;
        }

        // Track index of current patrol point.
        // MoveTowardsTarget(currPatrolPoint);
    }

    private void PatrolUpdate()
    {
        // Series of points to move between
        // Maybe a delay upon reaching each point.
        // Lots of other ways to implement some form of patrol behavior.

        if (IsPlayerWithinRange())
        {
            ChangeState(EnemyState.Attacking);
            return;
        }
    }

    private void DeadUpdate()
    {
        // Run death animation.
        // Cleanup and destroy.
        anim.SetBool("Throw", false);
        anim.SetBool("Death", true);

        Destroy(this.gameObject);

    }

    private bool IsPlayerWithinRange()
    {

        return (Vector3.Distance(transform.position, playerObj.transform.position) < attackDistance);
    }

    private bool IsPlayerEscaped()
    {
        return (Vector3.Distance(transform.position, playerObj.transform.position) > retreatDistance);
    }

    private void MoveTowardsTarget(Vector3 target)
    {
        Vector3 dir = ((target + new Vector3(15.0f, 0f)) - transform.position).normalized;

        dir.y = 0.0f;

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == playerObj || collision.gameObject.GetComponent<Enemy>() != null)
        {
            ChangeState(EnemyState.Dead);
        }
    }

    public void shootBullet()
    {

        GameObject bullet = Instantiate(bulletPre, spawnPoint.position, Quaternion.identity);
        bulletRenderer = bullet.GetComponent<SpriteRenderer>();
        rBody = bullet.GetComponent<Rigidbody2D>();

        // Instantiate(bullet, transform.position);
        bullets.Add(bullet);

        bulletRenderer.flipX = true;

        if (IsPlayerWithinRange())
            rBody.velocity += (new Vector2(-1000, 0) * Time.deltaTime * bulletSpeed);
        else
            rBody.velocity += (new Vector2(1000, 0) * Time.deltaTime * bulletSpeed);

        StopAllCoroutines();
    }

    IEnumerator attackSpeed()
    {

        yield return new WaitForSeconds(2f);
        shootBullet();

    }
}
