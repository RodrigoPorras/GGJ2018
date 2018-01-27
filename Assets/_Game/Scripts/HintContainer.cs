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
