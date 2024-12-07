using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x,y;
    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;
    public float velocidadInicial;
    public float velocidadAgachado;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impusoDeGolpe = 10f;

    public bool conArma;

    [Header("efecto de sonido")]
    [SerializeField] private GameObject oSaltoPLayer;

    private AudioSource sAudioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        sAudioPlayer = oSaltoPLayer.GetComponent<AudioSource>();

       

       
        
        

    }

    void FixedUpdate()
    {

          if(!estoyAtacando)        
        {
                transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
                transform.Translate(0, 0, y* Time.deltaTime * velocidadMovimiento);
            }

        if(avanzoSolo)
        {
            rb.velocity= transform.forward * impusoDeGolpe;
        }
       


      //  transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
      //  transform.Translate(0, 0, y* Time.deltaTime * velocidadMovimiento);

     
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

          
       

        if(Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyAtacando)
        {
            

            if(conArma)
            {
                anim.SetTrigger("golpeo2");
            estoyAtacando=true;
            }
            else
            {
                anim.SetTrigger("golpeo");
                estoyAtacando=true;
            }
        }

        
        

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if(puedoSaltar==true)
        {   
            
            if(!estoyAtacando)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("salte", true);
                    rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);

                }

                if(Input.GetKey(KeyCode.LeftControl))
                {
                anim.SetBool("agachado", true);
                velocidadMovimiento = velocidadAgachado;
                }
                else
                {
                    anim.SetBool("agachado", false);
                velocidadMovimiento = velocidadInicial;
                }
            }

            
            anim.SetBool("tocoSuelo", true);

        }
        else
        {
            Estoycayendo();
        }
    }

    public void Estoycayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
        
    }

    public void AnanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejeDeAvanzar()
    {
        avanzoSolo = false;
    }

    public void Salto()
    {
        if(puedoSaltar == true)
        {
            sAudioPlayer.Play();
        }
    }


    
}
