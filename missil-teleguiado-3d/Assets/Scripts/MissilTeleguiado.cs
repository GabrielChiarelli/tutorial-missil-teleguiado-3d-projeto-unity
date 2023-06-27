using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilTeleguiado : MonoBehaviour
{
    [Header("Referências")]
    public GameObject alvo;
    private Rigidbody oRigidbody;

    [Header("Perseguição")]
    [SerializeField] private float velocidadeDoMissil;
    [SerializeField] private float velocidadeDeRotacao;
    private Quaternion rotacaoParaOAlvo;

    private void Awake()
    {
        oRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovimentarMissil();
    }

    private void MovimentarMissil()
    {
        if (alvo != null)
        {
            rotacaoParaOAlvo = Quaternion.LookRotation(alvo.transform.position - transform.position);
            oRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotacaoParaOAlvo, velocidadeDeRotacao));

            oRigidbody.velocity = transform.forward * velocidadeDoMissil;
        }
        else
        {
            oRigidbody.velocity = transform.forward * velocidadeDoMissil;
        }
    }
}
