using UnityEngine;
using System.Collections;

public class equipoData : MonoBehaviour {
    //FUNDAMENTALES
    public string Nombre;
    public float vida, damage;
    public int nivel;
    public float exp;
    public int tipo;

    //Plus FUNDAMENTALES
    public float vidaPlus, plusRegen, plusExp;
    //Plus BASES
    public float atqPlus, defPlus, velPlus, giroPlus;
    //
    public int lvlReq;
    public float costoReparo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public float getVidaActual(){
        return (vida-damage);
    }
}
