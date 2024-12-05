using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("ActualizarDestino", 0f, 0.5f); // Actualizar el destino cada 0.5 segundos
    }

    void ActualizarDestino()
    {
        if (GameManager.Instance.jugador != null)
        {
            agent.destination = GameManager.Instance.jugador.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}
