using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 3;
    private int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(2f);
    private Coroutine regen;

    public static PlayerStamina instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

        }
        else
        {
            Debug.Log("Not enough stam");
        }
    }

    private IEnumerable RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 3;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }

}
