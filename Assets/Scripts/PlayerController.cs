using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public HealthBar healthBar;
    public HealthBar powerBar;
    public float chargeRate;
    public float currentCharge;

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
        
    }
}
