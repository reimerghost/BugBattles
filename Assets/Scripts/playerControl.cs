using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public float velocidad;

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
            moverDelante(velocidad);
        }
        //Horizontal
        if (rotar > 0)
        {
            girarBicho(2, -1);
        }
        if (rotar < 0)
        {
            girarBicho(2,1);
        }
    }

    void moverDelante(float v)
    {
        GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * v;
    }
    void girarBicho(float grados, int dir)
    {
        grados = grados * dir;
        transform.Rotate(0.0f, 0.0f, grados);
    }
    void disparar()
    {
    }
}