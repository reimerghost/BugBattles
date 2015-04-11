using UnityEngine;
using System.Collections;

public class bugData : MonoBehaviour {
    //FUNDAMENTAL
    public string Nombre;
    public float vidaBase, regenBase, regenTimeBase, damage;
    public int nivel;
	public float exp,expToLevelUp;
    //public int Person,tipoTiro,tipoBicho;
    float lastUpdate;    

    //BASE
    public float atqBase, defBase, velBase, giroBase;
    
	//Equipo de Bicho.
    public equipoData Equipo1, Equipo2, Equipo3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    //REGENERAR
		if (Time.time - lastUpdate >= regenTimeBase)
        {
            if(damage>0){
            damage -= regenBase;
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
		return (getVidaTotal() - damage);
    }

    public float getVidaTotal()
    {
		float bonus=0;
		if (Equipo1 != null) {
			bonus +=Equipo1.getVidaPlus();
		}
		if (Equipo2 != null) {
			bonus +=Equipo2.getVidaPlus();
		}
		if (Equipo3 != null) {
			bonus +=Equipo3.getVidaPlus();
		}
		return (vidaBase+bonus);
    }

	public float getAtqTotal(){
		float bonus=0;
		if (Equipo1 != null) {
			bonus +=Equipo1.getVidaPlus();
		}
		if (Equipo2 != null) {
			bonus +=Equipo2.getVidaPlus();
		}
		if (Equipo3 != null) {
			bonus +=Equipo3.getVidaPlus();
		}
		return (atqBase+bonus);
	}

	public float getDefTotal(){
		float bonus=0;
		if (Equipo1 != null) {
			bonus +=Equipo1.getDefPlus();
		}
		if (Equipo2 != null) {
			bonus +=Equipo2.getDefPlus();
		}
		if (Equipo3 != null) {
			bonus +=Equipo3.getDefPlus();
		}
		return (defBase+bonus);
	}

	public float getVelTotal(){
		float bonus=0;
		if (Equipo1 != null) {
			bonus +=Equipo1.getVelPlus();
		}
		if (Equipo2 != null) {
			bonus +=Equipo2.getVelPlus();
		}
		if (Equipo3 != null) {
			bonus +=Equipo3.getVelPlus();
		}
		return (velBase+bonus);
	}

	public float getGiroTotal(){
		float bonus=0;
		if (Equipo1 != null) {
			bonus +=Equipo1.getGiroPlus();
		}
		if (Equipo2 != null) {
			bonus +=Equipo2.getGiroPlus();
		}
		if (Equipo3 != null) {
			bonus +=Equipo3.getGiroPlus();
		}
		return (giroBase+bonus);
	}

    public void SubirExperiencia(float xp)
    {
        exp += xp;
        if (exp >= expToLevelUp)
        {
            nivel += 1;
            expToLevelUp += ((6 / 5) * Mathf.Pow(nivel, 3)) + (15 * Mathf.Pow(nivel, 2)) + (nivel) + 140;
        }
    }

    public string getCadenaEXP()
    {
        return exp+"/"+expToLevelUp;
    }
}
