using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {

    public float velocidad;
    public float grados;
    public GameObject disparo;
    public float velAtaque,exp;
    public float enemyHealth;
    private scriptDisparo balaRecibida;
    private hubSystem HUB;
    private float dist;
    private GameObject target;

    float lastUpdate;

	// Use this for initialization
	void Start () {
        HUB = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<hubSystem>();
    }

    void FixedUpdate()
    {
        target = GameObject.FindWithTag("Player");
        //rotate to look at the player
        transform.LookAt(target.transform.position);
        transform.Rotate(new Vector3(0,90, 90), Space.Self);

        transform.Translate(new Vector3(0,1f * Time.deltaTime, 0));
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 2f)
        {
            disparar();
        }
    }

    void disparar()
    {
        if (Time.time - lastUpdate >= velAtaque){
            Instantiate(disparo, transform.position, transform.rotation);
            lastUpdate = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        balaRecibida = coll.GetComponentInChildren<scriptDisparo>();

        if ("bullet".Equals(coll.tag)) {
            Destroy(coll.gameObject);
            if (enemyHealth <= 0)
            {
                HUB.actualizaEnemigos(exp);
                Destroy(this.gameObject);
            }
            else
            {
                enemyHealth -= balaRecibida.power;
            }
        }
    }
    
}
