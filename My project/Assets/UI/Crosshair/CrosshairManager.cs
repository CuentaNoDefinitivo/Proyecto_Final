using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    Animator crosshairAnimator;
    [SerializeField]Image image;
    
    private void Awake()
    {
        crosshairAnimator = GetComponent<Animator>();

        RangeWeapons.Reloading += Reloading;
        RangeWeapons.StopReloading += Reloaded;
        RangeWeapons.MunitionCount += MunitionCount;

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
    void Reloading()
    {
        crosshairAnimator.SetBool("Reloading", true);
        image.color = SettingsManager.Instance.ReloadCrosshairColor;
    }
    void Reloaded()
    {
        crosshairAnimator.SetBool("Reloading", false);
        image.color = SettingsManager.Instance.CrosshairColor;
    }
    void MunitionCount(int munitionCount, int maxMunition)
    {
        crosshairAnimator.SetFloat("Munition", munitionCount);
        if (munitionCount == 0) image.color = SettingsManager.Instance.NoMunitionCrosshairColor;
        else image.color = SettingsManager.Instance.CrosshairColor;
    }
    private void OnDestroy()
    {
        RangeWeapons.Reloading -= Reloading;
        RangeWeapons.StopReloading -= Reloaded;
        RangeWeapons.MunitionCount -= MunitionCount;

    }
}
