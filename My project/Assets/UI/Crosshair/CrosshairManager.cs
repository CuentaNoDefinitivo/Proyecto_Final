using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public static CrosshairManager Instance { get; private set; } //esto es porque hay unos scripts que quieren acceder a la variable Image.
    Animator crosshairAnimator;
    public Image Image { get; private set; }

    private void Awake()
    {
        Instance = this;

        if (Cursor.visible) Cursor.visible = false;

        TryGetComponent<Animator>(out crosshairAnimator);
        Image = GetComponent<Image>();

        Weapon.sniperCrosshair += CrosshairType;
    }
    private void Start()
    {
        Image.color = SettingsManager.Instance.CrosshairColor;
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    //crosshairAnimation
    void CrosshairType(bool state)
    {
        //esto es porque hay armas de rango que va a llamar estos eventos y armas de melee que no necesita estos eventos.
        if (state == true)
        {
            RangeWeapons.Reloading += Reloading;
            RangeWeapons.StopReloading += Reloaded;
            RangeWeapons.MunitionCount += MunitionCount;
        }
        else if (crosshairAnimator != null)
        {
            crosshairAnimator.SetFloat("Munition", 1);
            RangeWeapons.Reloading -= Reloading;
            RangeWeapons.StopReloading -= Reloaded;
            RangeWeapons.MunitionCount -= MunitionCount;
        }

    }


    void Reloading()
    {
        if (crosshairAnimator != null) crosshairAnimator?.SetBool("Reloading", true);
    }
    void Reloaded()
    {
        if (crosshairAnimator != null) crosshairAnimator?.SetBool("Reloading", false);
    }
    void MunitionCount(int munitionCount, int maxMunition)
    {
        if (crosshairAnimator != null) crosshairAnimator?.SetFloat("Munition", munitionCount);
    }
    private void OnDestroy()
    {
        RangeWeapons.Reloading -= Reloading;
        RangeWeapons.StopReloading -= Reloaded;
        RangeWeapons.MunitionCount -= MunitionCount;
        Weapon.sniperCrosshair -= CrosshairType;
    }
}
