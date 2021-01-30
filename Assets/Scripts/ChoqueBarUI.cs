using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoqueBarUI : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private Image slowIcon;
    private CuerpoScript cuerpo;

    private void Awake()
    {
        cuerpo = GameObject.FindObjectOfType<CuerpoScript>();
    }

    private void Update()
    {
        if (cuerpo == null)
            return;
        float val = cuerpo.ChoqueCur / cuerpo.ChoqueMax;
        if (!cuerpo.Debuffing)
            bar.fillAmount = Mathf.Lerp(bar.fillAmount, val, Time.deltaTime * 6);
        else
            bar.fillAmount = val;

        slowIcon.gameObject.SetActive(cuerpo.Debuffing);
    }
}