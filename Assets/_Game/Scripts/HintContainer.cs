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
        Horario h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15, h16, h17, h18;
        h1.horario = new int[30] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60 };
		h1.hintHorario = "Como es posible que alguien se conecte solo en los minutos pares?";
        h2.horario = new int[30] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59 };
		h2.hintHorario = "Como es posible que alguien se conecte solo en los minutos impares?";
        h3.horario = new int[5] { 1, 2, 3, 4, 5 };
        h3.hintHorario = "Suele conectarse los primeros 5 minutos de la hora";
        h4.horario = new int[10] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };
        h4.hintHorario = "Mientras trabaja, llama a su hijo los ultimos 10 minutos de la hora";
        h5.horario = new int[50] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };
        h5.hintHorario = "Parece senora del servicio pues pasados 10 minutos de la hora siempre se conecta";
        h6.horario = new int[0] { };
        h6.hintHorario = "Habra muerto? Nunca esta conectado";
        h7.horario = new int[30] { 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };
        h7.hintHorario = "Suele conectarse en la segunda mitad de la hora";
        h8.horario = new int[30] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
        h8.hintHorario = "Suele conectarse los primeros 30 minutos de la hora";
        h9.horario = new int[12] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };
        h9.hintHorario = "Suele conectarse cada 5 minutos";
        h10.horario = new int[15] { 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };
        h10.hintHorario = "Suele conectarse el ultimo cuarto de hora";
        h11.horario = new int[6] { 0, 10, 20, 30, 40, 50 };
        h11.hintHorario = "Al parecer se conecta en todas las decenas de la hora";
        h12.horario = new int[20] { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };
        h12.hintHorario = "Prefiere conectarse los ultimos 20 minutos de la hora";
        h13.horario = new int[25] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        h13.hintHorario = "Normalmente se conecta antes del minuto 25";
        h14.horario = new int[3] { 20, 40, 0 };
        h14.hintHorario = "Se conecta frecuentemente cada 20 minutos";
        h15.horario = new int[2] { 0, 30 };
        h15.hintHorario = "Es normal que llame cada media hora";
        h16.horario = new int[20] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 0 };
        h16.hintHorario = "Por cuestiones de trabajo se conecta cada 3 minutos";
        h17.horario = new int[15] { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56 };
        h17.hintHorario = "Parece que vende zapatos por telefono y sus llamadas van una tras de otra cada 4 minutos";
        h18.horario = new int[60] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };
        h18.hintHorario = "Caramba! la tarifa de telefono de este debe ser larga pues siempre esta conectado";


        horarios = new Horario[18] { h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15, h16, h17, h18 };
		//llenar nombres hombres array 
		NombreHombre nh1,nh2, nh3, nh4, nh5, nh6, nh7, nh8, nh9, nh10;
		nh1.nombre = "Robert Tully";
		nh1.hint = "Chespirito es su legado";
		nh2.nombre = "Charles Goldman";
		nh2.hint = "El toque de midas";
        nh3.nombre = "Martin Glimcher";
        nh3.hint = "Su nombre es similar al arma del dios del rayo";
        nh4.nombre = "Ivan Ospina";
        nh4.hint = "Actualmente vive en su van";
        nh5.nombre = "Francisco Rios";
        nh5.hint = "Amante de francia";
        nh6.nombre = "Ciro Pertusi";
        nh6.hint = "Ama los círicos";
        nh7.nombre = "Andres Gramsci";
        nh7.hint = "Un pro gramatical";
        nh8.nombre = "Michael Dickens";
        nh8.hint = "Scrooge y sus fantasmas de navidad";
        nh9.nombre = "Sergey Adamovich";
        nh9.hint = "Tan duro como el adamantium";
        nh10.nombre = "Enzo Altieri";
        nh10.hint = "Desea tener un ferrari";
        nombresHombres = new NombreHombre[10]{ nh1, nh2, nh3, nh4, nh5, nh6, nh7, nh8, nh9, nh10 };

        //llenar nombres mujeres array
        NombreMujer nm1, nm2, nm3, nm4, nm5, nm6, nm7, nm8, nm9;
		nm1.nombre = "Elena Pavao";
		nm1.hint = "Una princesa troyana";
		nm2.nombre = "Erika Blosch";
		nm2.hint = "Eureka!";
        nm3.nombre = "Marta Martinez";
        nm3.hint = "Que bueno los M&M's";
        nm4.nombre = "Aida Divjak";
        nm4.hint = "Contiene la letra c y a";
        nm5.nombre = "Anna Belka";
        nm5.hint = "Hermana de una reina helada";
        nm6.nombre = "Jana Mora";
        nm6.hint = "No hay como el jugo de...";
        nm7.nombre = "Christine Alkins";
        nm7.hint = "La religion ha otorgado gran cantidad de nombres";
        nm8.nombre = "Irina Folks";
        nm8.hint = "Algo le decia que su vida estaria relacionada con la panaderia";
        nombresMujeres = new NombreMujer[8]{ nm1, nm2, nm3, nm4, nm5, nm6, nm7, nm8 };
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
