using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("Armas")]
    public List<WeaponController> ArmasIniciales = new List<WeaponController>();
    [Header("Sockets")]
    public Transform WeaponParentSocket;
    public Transform DefaultWeaponPosition;
    public Transform AimingPosition;

    public int activeWeaponIndex {  get; private set; }

    private WeaponController[] WeaponSlots = new WeaponController[4];

    void Start()
    {
        activeWeaponIndex = -1;

        foreach (WeaponController ArmaInicial in ArmasIniciales)
        {
            AddWeapon(ArmaInicial);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }
    }

    private void CambiarArma(int ArmaPrefab)
    {
        if (ArmaPrefab != activeWeaponIndex && ArmaPrefab >= 0)
        {
            WeaponSlots[ArmaPrefab].gameObject.SetActive(true);
            activeWeaponIndex = ArmaPrefab;
        }
    }


    private void AddWeapon(WeaponController ArmaPrefab)
    {
        WeaponParentSocket.position = DefaultWeaponPosition.position;

        //Lo siguiente añade un arma pero sin mostrarla

    for (int i = 0; i<WeaponSlots.Length; i++)
        {
            if (WeaponSlots[i] == null)
            {
                WeaponController WeaponClone = Instantiate(ArmaPrefab, WeaponParentSocket);
                WeaponClone.gameObject.SetActive(false);

                WeaponSlots[i] = WeaponClone;
                return;
            } 
        }
    }
}
