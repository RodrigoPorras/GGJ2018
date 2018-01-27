using System.Collections;
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
		public int horario;
		public string hintHorario;
	}
	/////////////////

	public Horario[] horarios;
	public List<Horario> listHorarios;
	public NombreHombre[] nombresHombres;
	public List<NombreHombre> listNombresHombres;
	
	public NombreMujer[] nombresMujeres;
	public List<NombreMujer> listNombresMujeres;
	public Voz[] vocesHombres;
	public List<Voz> listVocesHombres;
	public Voz[] vocesMujeres;
	public List<Voz> listVocesMujeres;	
	public Face[] faces;
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
		Horario h1,h2;
		h1.horario = 1;
		h1.hintHorario = "mas o menos cada "+h1.horario+" segundos";
		h2.horario = 1;
		h2.hintHorario = "mas o menos cada "+h2.horario+" segundos";

		horarios = new Horario[2]{h1,h2};
		//llenar nombres hombres array 
		NombreHombre nh1,nh2;
		nh1.nombre = "Ramiro";
		nh1.hint = "Contiene la letra a";
		nh2.nombre = "Carlos";
		nh2.hint = "Contiene la letra a y c ";
		nombresHombres = new NombreHombre[2]{nh1,nh2};

		//llenar nombres mujeres array
		NombreMujer nm1,nm2;
		nm1.nombre = "Andrea";
		nm1.hint = "Contiene la letra d";
		nm2.nombre = "Camila";
		nm2.hint = "Contiene la letra c y a";
		nombresMujeres = new NombreMujer[2]{nm1,nm2};
	}

	public void LoadListsForGenerateAgentsAgain(){
		listHorarios = new List<Horario>(horarios);
		listNombresHombres = new List<NombreHombre>(nombresHombres);
		listNombresMujeres = new List<NombreMujer>(nombresMujeres);
		listVocesHombres = new List<Voz>(vocesHombres);
		listVocesMujeres = new List<Voz>(vocesMujeres);
		listFaces = new List<Face>(faces);
	}

}
