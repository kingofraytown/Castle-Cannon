using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public HealthBar healthBar;
    public HealthBar powerBar;
    public float chargeRate;
    public float currentCharge;
    public bool isFiringBullets = false;
    public Transform turret;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChargeCannon();
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

    void HealthCheck()
    {

    }
}
