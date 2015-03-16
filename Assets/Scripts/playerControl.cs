using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public float velocidad;
    public float grados;


    public Texture btnArriba, btnIzquierda, btnDerecha, btnDispara;

    private Rect rArriba = new Rect(200, 200, 75, 75);
    private Rect rDispara = new Rect(740, 400, 75, 75);
    private Rect rIzquierda = new Rect(100, 100, 75, 75);
    private Rect rDerecha = new Rect(120, 400, 75, 75);

    void OnGUI()
    {
        if (Input.touchCount > 0)
            for (int i = 0; i < Input.touchCount; i++)
            {
                GUI.Label(new Rect(0, (i*10), 100, 50), Input.GetTouch(i).position.ToString());

                if (rIzquierda.Contains(Input.GetTouch(i).position))
                {
                    GUI.Label(new Rect(100, (i * 10), 100, 50), "IZQUIERDA");
                    girarBicho(1f);
                }
                if(rArriba.Contains(Input.GetTouch(i).position)){
                    GUI.Label(new Rect(100, (i*10), 100, 50), "ARRIBA");
                    moverDelante();
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