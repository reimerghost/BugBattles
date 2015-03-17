using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public float velocidad;
    public float grados;


    public Texture btnArriba, btnIzquierda, btnDerecha, btnDispara;

    private Rect rArriba = escalarGUI.ResizeGUI(new Rect(380, 730, 60, 60));
    private Rect rIzquierda = escalarGUI.ResizeGUI(new Rect(20, 730, 60, 60));
    private Rect rDerecha = escalarGUI.ResizeGUI(new Rect(60, 730, 60, 60));
    private Rect rDispara = escalarGUI.ResizeGUI(new Rect(425, 730, 60, 60));

    Vector2 vTouch;
    void OnGUI()
    {
        GUI.DrawTexture(rArriba, btnArriba); //Boton Adelante
        GUI.DrawTexture(rIzquierda, btnIzquierda); //Boton Izquierda
        GUI.DrawTexture(rDerecha, btnDerecha); //Boton Derecha
        GUI.DrawTexture(rDispara, btnDispara); //Boton Dispara 

        if (Input.touchCount > 0)
            for (int i = 0; i < Input.touchCount; i++)
            {
                GUI.Label(new Rect(0, (i * 10), 100, 50), Input.GetTouch(i).position.ToString());

                vTouch = new Vector2(Input.GetTouch(i).position.x, Screen.height-Input.GetTouch(i).position.y);
                if (rArriba.Contains(vTouch))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "ARRIBA");
                    moverDelante();                }
                if (rIzquierda.Contains(vTouch))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "IZQUIERDA");
                    girarBicho(1f);
                }
                if (rDerecha.Contains(vTouch))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "DERECHA");
                    girarBicho(-1f);
                }
                if (rDispara.Contains(vTouch))
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