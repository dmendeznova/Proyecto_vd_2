using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArmas : MonoBehaviour
{
    public BoxCollider[] armasBoxCol;
    public BoxCollider puñoBoxCol;
    // Start is called before the first frame update
    public GameObject[] armas;

    //Animacion arma
    public LogicaPersonaje1 logicaPersonaje1;
    void Start()
    {
        DesactivarCollidersArmas(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DesactivarArmas();
        }
    }

    public void ActivarArmas(int numero)
    {
        for(int i=0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true); 

        logicaPersonaje1.conArma = true;
    }

    public void DesactivarArmas()
    {
        for(int i=0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        logicaPersonaje1.conArma = false;
    }

    public void ActivarCollidersArmas()
    {
        for(int i=0; i < armasBoxCol.Length; i++)
        {
            if(logicaPersonaje1.conArma)
            {
                if(armasBoxCol[i] != null)
                {
                    
                    armasBoxCol[i].enabled = true;
                }
            }
            else
            {
                puñoBoxCol.enabled = true;
            }
        }
    }

    public void DesactivarCollidersArmas()
    {
        for(int i=0; i < armasBoxCol.Length; i++)
        {
            
            if(armasBoxCol[i] != null)
            {
                armasBoxCol[i].enabled = false;
            }
            
        }
        puñoBoxCol.enabled = false;
    }

    


}
