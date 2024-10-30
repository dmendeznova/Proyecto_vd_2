using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmasPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public CogerArmas cogerArmas;
    public int numeroArma;
    void Start()
    {
        cogerArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<CogerArmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cogerArmas.ActivarArmas(numeroArma);
            Destroy(gameObject);
        }
    }
}
