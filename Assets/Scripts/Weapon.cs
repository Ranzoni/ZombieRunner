using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot)
            StartCoroutine(Shoot());
    }

    void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (HasAmmo(ammoType))
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            GetComponent<AudioSource>().Play();
        }
        
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    bool HasAmmo(AmmoType ammoType)
    {
        var ammoAmount = ammoSlot.GetCurrentAmmo(ammoType);
        var hasAmmo = ammoAmount > 0;

        return hasAmmo;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        var hitSomething = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        if (hitSomething)
        {
            CreateHitImpact(hit);
            var target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.TakeDamage(damage);
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
