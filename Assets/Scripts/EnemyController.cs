using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameFloat lookRange;
    public float lookRanged;
    public GameObject player;
    public Gun gun;
    //public ItemDropper bag;
    //public ObjectPool bullets;
    //public float fireRated;
    //public GameFloat fireRate;
    //public float fireRateTimer;
    //public float targetAngle;
    public Animator animator;
    //public VFXController explosion;
    //public Animator explosionAnimator;
    public Breakable health;
    public GameFloat deathTime;
    public float deathTimed;
    public float deathTimer;
    public float distance;
    public float speed;
    public bool isDying = false;
    public float stopDistance;
    //public bool shootStraight = false;

    // Start is called before the first frame update
    void Start()
    {
        gun.target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDying == false)
        {
            if (distance > stopDistance)
            {
                Vector3 gp = gameObject.transform.position;
                gameObject.transform.position = new Vector3(gp.x + (-1 * speed * Time.deltaTime), gp.y, gp.z);
            }
        }
        
        //check for player distance
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        /*

        fireRateTimer += Time.deltaTime;

        //if in range
        if (distance <= lookRange.value())
        {
            Vector3 direction = player.transform.position - gun.transform.position;
            targetAngle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg - 180;
            Vector3 look = gun.transform.InverseTransformPoint(player.transform.position);
            //targetAngle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
            //face toward player
            //gun.transform.Rotate(0, 0, targetAngle);
            Fire();
        }
        */

        if (health.currentState == Breakable.healthState.Damaged)
        {
            Hit();
        }

        if (health.currentState == Breakable.healthState.Destroyed)
        {
            BreakCrate();
            deathTimer = deathTime.value();
            health.currentState = Breakable.healthState.None;
            isDying = true;
        }

        if (health.currentState == Breakable.healthState.None)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /*void Fire()
    {
        if (fireRateTimer >= fireRate.value())
        {
            GameObject bullet = bullets.GetPooledObject();
            if (bullet != null)
            {
                bullet.GetComponent<EnemyBullet>().Restore();
                bullet.transform.position = gun.transform.position;
                if (shootStraight)
                {
                    bullet.transform.Rotate(0, 0, -180);
                } else
                {
                    bullet.transform.Rotate(0, 0, targetAngle);
                }
                bullet.SetActive(true);
                fireRateTimer = 0;
            }

        }
    }*/

    public void Hit()
    {
        animator.SetTrigger("hit");
    }

    public void BreakCrate()
    {
        //explosion.TriggerVFX();
        animator.SetBool("dead", true);
        //bag.DropItems();
    }
}
