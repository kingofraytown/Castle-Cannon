using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public HealthBar healthBar;
    public HealthBar powerBar;
    public float chargeRate;
    public float currentCharge;
    public PlayerHealth health;
    public bool isFiringBullets = false;
    public Transform turret;
    public bool isHurt = false;
    public float hurtTime;
    public float hurtTimer;
    public Animator castleAnimator;
    public Animator cannonAnimator;
    public Animator damageAnimator;

    public enum ChargeState
    {
        None,
        Basic,
        Charge,
        BigCharge,
        GreatCharge,
        OverFlow
    }

    public ChargeState currentChargeState = ChargeState.None;

    public enum HealthState
    {
        Full,
        Damage1,
        Damage2,
        Damage3,
        Damage4,
        Destroyed
    }
    public HealthState currentHealthState = HealthState.Full;
    public Gun basicShot;
    public Gun chargeShot;
    public Gun bigChargeShot;
    public Gun biggerChargeShot;
    public Gun overFlowShot;

    private void OnEnable()
    {
        PlayerHealth.PlayerDamageEvent += PlayerHit;
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDamageEvent -= PlayerHit;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isHurt)
        {
            hurtTimer -= Time.deltaTime;

            if (hurtTimer <= 0)
            {
                isHurt = false;
            }

        }
        ChargeCannon();
        UpdatePowerBar();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("fire the cannon");
            FireCannon();
        }

    }

    void FireCannon()
    {
        switch (currentChargeState)
        {
            case ChargeState.None:
                break;
            case ChargeState.Basic:
                basicShot.Fire();
                cannonAnimator.SetTrigger("fire");
                currentCharge = 0;
                UpdateChargeStatus(currentCharge);
                break;
            case ChargeState.Charge:
                chargeShot.Fire();
                cannonAnimator.SetTrigger("fire");
                currentCharge = 0;
                UpdateChargeStatus(currentCharge);
                health.TakeDamage(5);
                break;
            case ChargeState.BigCharge:
                bigChargeShot.Fire();
                cannonAnimator.SetTrigger("fire");
                currentCharge = 0;
                UpdateChargeStatus(currentCharge);
                health.TakeDamage(10);
                break;
            case ChargeState.GreatCharge:
                biggerChargeShot.Fire();
                cannonAnimator.SetTrigger("fire");
                currentCharge = 0;
                UpdateChargeStatus(currentCharge);
                health.TakeDamage(20);
                break;
            case ChargeState.OverFlow:
                overFlowShot.Fire();
                cannonAnimator.SetTrigger("fire");
                currentCharge = 0;
                UpdateChargeStatus(currentCharge);
                health.TakeDamage(40);
                break;
        }
    }

    void ChargeCannon()
    {
        currentCharge += chargeRate * Time.deltaTime;
        UpdateChargeStatus(currentCharge);
        
    }

    void UpdateChargeStatus(float charge)
    {
        if(charge <= 10)
        {
            if(currentChargeState != ChargeState.None)
            {
                currentChargeState = ChargeState.None;
            }
        } else if(charge > 10 && charge <= 25)
        {
            if (currentChargeState != ChargeState.Basic)
            {
                currentChargeState = ChargeState.Basic;
            }
        } else if(charge > 25 && charge <= 50)
        {
            if (currentChargeState != ChargeState.Charge)
            {
                currentChargeState = ChargeState.Charge;
            }
        } else if (charge > 50 && charge <= 75)
        {
            if (currentChargeState != ChargeState.BigCharge)
            {
                currentChargeState = ChargeState.BigCharge;
            }
        }
        else if (charge > 75 && charge <= 100)
        {
            if (currentChargeState != ChargeState.GreatCharge)
            {
                currentChargeState = ChargeState.GreatCharge;
            }
        } else if(charge > 100)
        {
            if (currentChargeState != ChargeState.OverFlow)
            {
                currentChargeState = ChargeState.OverFlow;
            }
        }
    }

    void UpdatePowerBar()
    {
        powerBar.health = currentCharge;
    }

    void UpdateHealthState()
    {
        if(health.health == 100)
        {
            if(currentHealthState != HealthState.Full)
            {
                currentHealthState = HealthState.Full;
                castleAnimator.SetInteger("castle-health", 5);
            }
        } else if (health.health < 100 && health.health > 75)
        {
            if (currentHealthState != HealthState.Damage1)
            {
                currentHealthState = HealthState.Damage1;
                castleAnimator.SetInteger("castle-health", 4);
                damageAnimator.SetTrigger("dvfx1");
            }
        } else if (health.health <= 75 && health.health > 50)
        {
            if (currentHealthState != HealthState.Damage2)
            {
                currentHealthState = HealthState.Damage2;
                castleAnimator.SetInteger("castle-health", 3);
                damageAnimator.SetTrigger("dvfx2");
            }
        } else if (health.health <= 50 && health.health > 25)
        {
            if (currentHealthState != HealthState.Damage3)
            {
                currentHealthState = HealthState.Damage3;
                castleAnimator.SetInteger("castle-health", 2);
            }
        } else if (health.health < 25 && health.health > 0)
        {
            if (currentHealthState != HealthState.Damage4)
            {
                currentHealthState = HealthState.Damage4;
                castleAnimator.SetInteger("castle-health", 1);
                damageAnimator.SetTrigger("dvfx2");
            }
        }  else if (health.health <= 0)
        {
            if (currentHealthState != HealthState.Destroyed)
            {
                currentHealthState = HealthState.Destroyed;
                castleAnimator.SetInteger("castle-health", 0);
                damageAnimator.SetTrigger("dvfx2");
            }
        }

    }

    public void PlayerHit(int d)
    {
        if (isHurt == false)
        {
            isHurt = true;
            hurtTimer = hurtTime;
            healthBar.health = health.health;
            UpdateHealthState();
        }
    }
}
