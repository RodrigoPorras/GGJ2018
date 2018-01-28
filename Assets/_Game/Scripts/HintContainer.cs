﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintContainer : MonoBehaviour {
	public struct NombreHombre{  
		public string nombre;
		public string hint;  
	}  
	public struct NombreMujer{  
		public string nombre;
		public string hint;  
	} 	
	public struct Horario{
		public int[] horario;
		public string hintHorario;
	}
	/////////////////

	public Horario[] horarios;
    [HideInInspector]
	public List<Horario> listHorarios;
	public NombreHombre[] nombresHombres;
    [HideInInspector]
    public List<NombreHombre> listNombresHombres;
	
	public NombreMujer[] nombresMujeres;
    [HideInInspector]
    public List<NombreMujer> listNombresMujeres;
	public Voz[] vocesHombres;
    [HideInInspector]
    public List<Voz> listVocesHombres;
	public Voz[] vocesMujeres;
    [HideInInspector]
    public List<Voz> listVocesMujeres;	
	public Face[] faces;
    [HideInInspector]
    public List<Face> listFaces = new List<Face>();
	
	////////////////
	public static HintContainer instance;
	
	void Awake () {
		if(instance == null){
			instance = this;
		}else{
			Destroy(this);
		}

		//TODO
		//llenar horarios array
		Horario h1,h2,h3,h4;
		h1.horario = new int[4]{1,2,3,4};
		h1.hintHorario = "mas o menos cada "+h1.horario+" segundos";
		h2.horario = new int[30]{1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,57,59};
		h2.hintHorario = "mas o menos cada "+h2.horario+" segundos";
        h3.horario = new int[1]{1};
        h3.hintHorario = "mas o menos cada " + h2.horario + " segundos";
        h4.horario = new int[0] {  };
        h4.hintHorario = "Nunca esta conectado";

        horarios = new Horario[4]{h1,h2,h3,h4};
		//llenar nombres hombres array 
		NombreHombre nh1,nh2, nh3;
		nh1.nombre = "Ramiro";
		nh1.hint = "Contiene la letra a";
		nh2.nombre = "Carlos";
		nh2.hint = "Contiene la letra a y c ";
        nh3.nombre = "Carlos";
        nh3.hint = "Contiene la letra a y c ";
        nombresHombres = new NombreHombre[3]{nh1,nh2, nh3};

		//llenar nombres mujeres array
		NombreMujer nm1,nm2;
		nm1.nombre = "Andrea";
		nm1.hint = "Contiene la letra d";
		nm2.nombre = "Camila";
		nm2.hint = "Contiene la letra c y a";
		nombresMujeres = new NombreMujer[2]{nm1,nm2};
	}

	public void LoadListsForGenerateAgentsAgain()
    {
		listHorarios = new List<Horario>(horarios);
		listNombresHombres = new List<NombreHombre>(nombresHombres);
		listNombresMujeres = new List<NombreMujer>(nombresMujeres);
		listVocesHombres = new List<Voz>(vocesHombres);
		listVocesMujeres = new List<Voz>(vocesMujeres);
		listFaces = new List<Face>(faces);
	}

}
