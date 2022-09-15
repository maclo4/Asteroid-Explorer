using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGaugeController : MonoBehaviour
{
    [SerializeField] private int fuelAmount;
    private int fuelTotal;
    private int twoFuelCellThreshold, oneFuelCellThreshold;
    [SerializeField] private int fuelReductionAmount;
    [SerializeField] private int fuelGainAmount;
    [SerializeField] private GameObject gauge;
    private float initialGaugeScale;
    [SerializeField] private Animator fuelGaugeAnimator;
    private static readonly int FullFuel = Animator.StringToHash("FullFuel");
    private static readonly int TwoFuelCells = Animator.StringToHash("TwoFuelCells");
    private static readonly int OneFuelCell = Animator.StringToHash("OneFuelCell");
    private static readonly int EmptyGauge = Animator.StringToHash("EmptyGauge");
    private int fuelBufferAmount = 10;

    private void Awake()
    {
        initialGaugeScale = gauge.transform.localScale.x;
        fuelTotal = fuelAmount;
        var fuelCellIncrement = fuelTotal / 3;
        twoFuelCellThreshold = fuelTotal - fuelCellIncrement;
        oneFuelCellThreshold = twoFuelCellThreshold - fuelCellIncrement;
        Debug.Log("oneFuelCellThreshold: " + oneFuelCellThreshold);
        Debug.Log("twoFuelCellThreshold: " +twoFuelCellThreshold);
    }

    private void SetFuelGaugeAnimation()
    {
        var currentGaugeXScale = fuelAmount / (float)fuelTotal * initialGaugeScale;
        var localScale = gauge.transform.localScale;
        localScale = new Vector3(currentGaugeXScale, localScale.y, localScale.z);
        gauge.transform.localScale = localScale;
        
        /*if(fuelAmount > twoFuelCellThreshold + fuelBufferAmount )
            fuelGaugeAnimator.SetTrigger(FullFuel);
        if(fuelAmount <= twoFuelCellThreshold && fuelAmount > oneFuelCellThreshold + fuelBufferAmount)
            fuelGaugeAnimator.SetTrigger(TwoFuelCells);
        if(fuelAmount <= oneFuelCellThreshold && fuelAmount > 0)
            fuelGaugeAnimator.SetTrigger(OneFuelCell);
        if(fuelAmount <= 0)
            fuelGaugeAnimator.SetTrigger(EmptyGauge);*/
    }

    public void DecreaseFuel()
    {
        if (fuelAmount <= 0) return;
        
        fuelAmount -= fuelReductionAmount;
        SetFuelGaugeAnimation();
    }
    
    public void IncreaseFuel()
    {
        if (fuelAmount >= fuelTotal) return;
        
        fuelAmount += fuelGainAmount;
        SetFuelGaugeAnimation();
    }

    public bool IsFuelEmpty()
    {
        return fuelAmount <= 0;
    }

    public void SetGaugeFull()
    {
        fuelAmount = fuelTotal;
        SetFuelGaugeAnimation();
    }
}
