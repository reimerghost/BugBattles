using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public float velocidad;
    public float grados;
    public GameObject disparo;
    public float velAtaque;
    private scriptDisparo balaRecibida;
    private bugData me;
    
    private float lastUpdate,lastUpdate2;

    public Texture btnArriba, btnIzquierda, btnDerecha, btnDispara;

    private float acelerometro,rotar,mover;

    private Rect rArriba = escalarGUI.ResizeGUI(new Rect(70, 730, 80, 60));
    private Rect rIzquierda = escalarGUI.ResizeGUI(new Rect(20, 730, 80, 60));
    //private Rect rDerecha = escalarGUI.ResizeGUI(new Rect(120, 730, 80, 60));
    private Rect rDispara = escalarGUI.ResizeGUI(new Rect(420, 730, 80, 60));

    Vector2 vTouch;
    void OnGUI()
    {
        //GUI.Label(new Rect(0, 70, 200, 50), "Acc: " + Input.acceleration.x);

        GUI.DrawTexture(rArriba, btnArriba); //Boton Adelante
        GUI.DrawTexture(rIzquierda, btnIzquierda); //Boton Izquierda
        //GUI.DrawTexture(rDerecha, btnDerecha); //Boton Derecha
        GUI.DrawTexture(rDispara, btnDispara); //Boton Dispara 

        if (Input.touchCount > 0)
            for (int i = 0; i < Input.touchCount; i++)
            {
                //GUI.Label(new Rect(0, (i * 10), 100, 50), Input.GetTouch(i).position.ToString());
                vTouch = new Vector2(Input.GetTouch(i).position.x, Screen.height-Input.GetTouch(i).position.y);

               if (rArriba.Contains(vTouch))
                {
                    moverDelante();
               }
                if (rIzquierda.Contains(vTouch))
                {
                    transform.position = new Vector3(0,10,0);
                }
                if (rDispara.Contains(vTouch))
                {
                    disparar();
                }
            }
    }

	// Use this for initialization
	void Start () {
        me = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<bugData>();
	}       
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 0)
        {
            if (Time.time - lastUpdate2 >= 1)
            {
                me.sumarDamage(50);
                lastUpdate2 = Time.time;
            }
        }
	}

    void FixedUpdate()
    {
        //Teclado (solo debug)
        rotar = Input.GetAxis("Horizontal");
        mover = Input.GetAxis("Vertical");
        //Movil
        acelerometro = -Input.acceleration.x;

            //Vertical
            if (mover > 0)
            {
                moverDelante();
            }
            //Horizontal
            if (rotar > 0 || acelerometro < -0.09)
            {
                girarBicho(-1f);
            }
            if (rotar < 0 || acelerometro > 0.09)
            {
                girarBicho(1f);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                disparar();
            }        
    }

    public void moverDelante()
    {
        GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * 0.3f * velocidad;
    }

    //Solo de prueba (para probar con el teclado)
    public void girarBicho(float dir)
    {
        float g = grados*dir;
        transform.Rotate(0.0f, 0.0f, g);
    }

    void disparar()
    {
        if (Time.time - lastUpdate >= velAtaque)
        {
            Instantiate(disparo, transform.position, transform.rotation);
            lastUpdate = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        balaRecibida = coll.GetComponentInChildren<scriptDisparo>();

        if ("enemyBullet".Equals(coll.tag))
        {
            Destroy(coll.gameObject);
            if (me.getVidaActual()<= 0)
            {
                //DO NOTHING
            }
            else
            {
                me.sumarDamage(balaRecibida.power);
            }
        }
    }
}