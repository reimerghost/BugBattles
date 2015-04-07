using UnityEngine;
using System.Collections;

public class bugData : MonoBehaviour {
    //FUNDAMENTAL
    public string Nombre;
    public float vida, regen, damage;
    public int nivel=1;
    public float exp;
    //public int Person,tipoTiro,tipoBicho;
    float lastUpdate;

    //EXP SYSTEM
    public float actualExp, expToLevelUp, malos;
    

    //BASE
    public float atqBase, defBase, velBase, giroBase;
    
    public equipoData Equipo1, Equipo2, Equipo3;

	// Use this for initialization
	void Start () {
        expToLevelUp = 100;
	}
	
	// Update is called once per frame
	void Update () {
	    //REGENERAR
        if (Time.time - lastUpdate >= 2)
        {
            if(damage>0){
            damage -= regen;
            }
            lastUpdate = Time.time;
        }
	}

    public void sumarDamage(float d)
    {
        damage += d;
    }

    public float getVidaActual()
    {
        return (vida - damage);
    }

    public float getVidaTotal()
    {
        return (vida);
    }

    public void SubirExperiencia(float exp)
    {
        malos++;
        actualExp += exp;
        if (actualExp >= expToLevelUp)
        {
            nivel += 1;
            expToLevelUp += ((6 / 5) * Mathf.Pow(nivel, 3)) + (15 * Mathf.Pow(nivel, 2)) + (nivel) + 140;
            malos = 0;
        }
    }

    public string getCadenaEXP()
    {
        return actualExp+"/"+expToLevelUp;
    }
}
