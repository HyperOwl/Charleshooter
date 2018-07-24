using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour {
    public enum WeaponState { Active, Reloading, Ready };

    private bool shieldReloading = false;

    private Animator animator;
    [SerializeField]
    private GameObject barrel1;
    [SerializeField]
    private GameObject barrel2;
    [SerializeField]
    private GameObject laser;
    [Header("STATS")]
    [SerializeField]
    private float shieldReloadTime = 3f;
    [Header("TRACKING")]
    public WeaponState shield = WeaponState.Ready;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update () {
        MouseInput();
        if (shieldReloading) return;
        else if (shield == WeaponState.Active)
        {
            animator.SetBool("Shield", true);
        }
        else if (shield == WeaponState.Ready)
        {
            animator.SetBool("Shield", false);
        }
        else
        {
            animator.SetBool("Shield", false);
            StartCoroutine(ReloadShield());
            shieldReloading = true;
        }
    }
    private void MouseInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laser, barrel1.transform.position, barrel1.transform.rotation, null);
            Instantiate(laser, barrel2.transform.position, barrel2.transform.rotation, null);
            if (shield == WeaponState.Active)
            {
                shield = WeaponState.Reloading;
            }
        }
        if (Input.GetButtonDown("Fire3"))
        {
            if (shield == WeaponState.Ready)
            { 
                shield = WeaponState.Active;
            }
        }
    }
    IEnumerator ReloadShield ()
    {
        Debug.Log("Reloading");
        yield return new WaitForSeconds(shieldReloadTime);
        Debug.Log("Done");
        shield = WeaponState.Ready;
        shieldReloading = false;
    }
}
