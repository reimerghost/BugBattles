using UnityEngine;
using System.Collections;

public class scriptDisparo : MonoBehaviour {
    public float velocidad;
    public float power;
    private hubSystem HUB;
    public int type; //TODO para futuras versiones.
    private float tiempoDisparo;

	// Use this for initialization
	void Start () {
        tiempoDisparo = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {        
        GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * 1f * velocidad;
        if(Time.time-tiempoDisparo>5f){
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ("pared".Equals(coll.tag))
        {
            Destroy(this.gameObject);
        }
    }

}
