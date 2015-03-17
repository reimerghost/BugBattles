using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public float velocidad;
    public float grados;


    public Texture btnArriba, btnIzquierda, btnDerecha, btnDispara;

    private Rect rArriba = (new Rect(0, 0, 60, 60));
    private Rect rIzquierda = (new Rect(30, 10, 60, 60));
    private Rect rDerecha = (new Rect(110, 10, 60, 60));
    private Rect rDispara = (new Rect(760, 10, 60, 60));

    bool bArriba;
    bool bIzquierda;
    bool bDerecha;
    bool bDispara;

    void OnGUI()
    {
        bArriba = GUI.RepeatButton(rArriba, btnArriba); //Boton Adelante
        bIzquierda = GUI.RepeatButton(rIzquierda, btnIzquierda); //Boton Izquierda
        bDerecha = GUI.RepeatButton(rDerecha, btnDerecha); //Boton Derecha
        bDispara = GUI.RepeatButton(rDispara, btnDispara); //Boton Dispara 

        if (Input.touchCount > 0)
            for (int i = 0; i < Input.touchCount; i++)
            {
                GUI.Label(new Rect(0, (i * 10), 100, 50), Input.GetTouch(i).position.ToString());

                if (rArriba.Contains(Input.GetTouch(i).position))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "ARRIBA");
                    moverDelante();                }
                if (rIzquierda.Contains(Input.GetTouch(i).position))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "IZQUIERDA");
                    girarBicho(1f);
                }
                if (rDerecha.Contains(Input.GetTouch(i).position))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "DERECHA");
                    girarBicho(-1f);
                }
                if (rDispara.Contains(Input.GetTouch(i).position))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "DISPARANDO");
                    //DISPARO
                }
            }
        

    }

	// Use this for initialization
	void Start () {
	
	}       
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {

        

        float rotar = Input.GetAxis("Horizontal");
        float mover = Input.GetAxis("Vertical");
            //Vertical
            if (mover > 0)
            {
                moverDelante();
            }
            //Horizontal
            if (rotar > 0)
            {
                girarBicho(-1f);
            }
            if (rotar < 0)
            {
                girarBicho(1f);
            }
    }

    public void moverDelante()
    {

        GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * 0.3f * velocidad;
    }

    public void girarBicho(float dir)
    {
        float g = grados*dir;
        transform.Rotate(0.0f, 0.0f, g);
    }



    void disparar()
    {
    }
}