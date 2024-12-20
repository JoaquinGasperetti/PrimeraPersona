using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    private Quaternion RotacionOrigen;
    void Start()
    {
        RotacionOrigen = transform.localRotation;
    }
    void Update()
    {
        updateSway();
    }

    private void updateSway()
    {
        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse Y");
        //Lo siguiente calcula la rotacion del arma
        Quaternion t_xAngleAdjustmen = Quaternion.AngleAxis(-t_xLookInput * 1.45f, Vector3.up);
        Quaternion t_yAngleAdjustmen = Quaternion.AngleAxis(t_yLookInput * 1.45f, Vector3.right);
        Quaternion t_targetRotation = RotacionOrigen * t_xAngleAdjustmen * t_yAngleAdjustmen;
        //Lo siguiente rota a travez de la rotacion del objetivo
        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targetRotation, Time.deltaTime * 10f);
    }
}
