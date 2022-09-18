using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public static CrosshairManager Instance { get; private set; }
    Animator crosshairAnimator;
    [SerializeField]public Image image;
    
    private void Awake()
    {
        Instance = this;

        if (Cursor.visible) Cursor.visible = false;

        TryGetComponent<Animator>(out crosshairAnimator);

        Weapon.sniperCrosshair += CrosshairType;
    }
    private void Start()
    {
        image.color = SettingsManager.Instance.CrosshairColor;
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    //crosshairAnimation
    void CrosshairType(bool state)
    {
        if (state == true)
        {
            RangeWeapons.Reloading += Reloading;
            RangeWeapons.StopReloading += Reloaded;
            RangeWeapons.MunitionCount += MunitionCount;
        }
        else
        {
            crosshairAnimator.SetFloat("Munition", 1);
            RangeWeapons.Reloading -= Reloading;
            RangeWeapons.StopReloading -= Reloaded;
            RangeWeapons.MunitionCount -= MunitionCount;
        }
        
    }


    void Reloading()
    {
        crosshairAnimator.SetBool("Reloading", true);
        //image.color = SettingsManager.Instance.ReloadCrosshairColor;
    }
    void Reloaded()
    {
        crosshairAnimator.SetBool("Reloading", false);
        //image.color = SettingsManager.Instance.CrosshairColor;
    }
    void MunitionCount(int munitionCount, int maxMunition)
    {
        crosshairAnimator.SetFloat("Munition", munitionCount);
        //if (munitionCount == 0) image.color = SettingsManager.Instance.NoMunitionCrosshairColor;
        //else image.color = SettingsManager.Instance.CrosshairColor;
    }
    private void OnDestroy()
    {
        RangeWeapons.Reloading -= Reloading;
        RangeWeapons.StopReloading -= Reloaded;
        RangeWeapons.MunitionCount -= MunitionCount;
    }
}
