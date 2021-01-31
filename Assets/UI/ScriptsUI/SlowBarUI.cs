using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Esto es una barra escalable, le faltan cosas.
/// </summary>

public class SlowBarUI : MonoBehaviour
{
    [SerializeField]
    private Slider barSlider;

    [SerializeField]
    private GameObject slowIcon;


    public void SetInitialValues(int initialValue, int maxValue)
    {
        barSlider.value = initialValue; //Probablemente esto sea 0
        barSlider.maxValue = maxValue;//Ni idea este valor 
    }


    public void SetBarValue(int newValue)
    {
        barSlider.value = newValue;
    }

    //Se supone que cuando se realentice el pj se llama a esto en true y cuando no se lo llama en falso que se yo ya no tengo neuronas 
    public void ShowIcon(bool isCharacterSlowed)
    {
        slowIcon.SetActive(isCharacterSlowed);
    }


}
