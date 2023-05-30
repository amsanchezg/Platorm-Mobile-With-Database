using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;//Librería añadida para trabajar con la DB
using System.IO;//Librería para poder abrir archivos
using Mono.Data.Sqlite;//Librería para trabajar con SQLite
public class NuevoCoinManager : MonoBehaviour
{

    public static int TotalCoins;
    public static int LevelCoins;
    public Text TextoTotalCoins;
    public Text TextoLevelCoins;
    public GameObject rankingGO;
    int puntosDB;

    //Variable donde guardar la dirección de la Base de Datos
    string rutaDB;
    string strConexion;
    //Nombre de la base de datos con la que vamos a trabajar
    string DBFileName = "RankingMonedas.db";

    //Referencia que necesitamos para poder crear una conexión 
    IDbConnection dbConnection;
    //Referencia que necesitamos para poder ejecutar comandos
    IDbCommand dbCommand;
    //Referencia que necesitamos para leer datos
    IDataReader reader;

    // Start is called before the first frame update
    void Start()
    {
        LevelCoins = 0;
        //TotalCoins = PlayerPrefs.GetInt("MonedasTotales_nuevo");
       TotalCoins = DataBaseManager.LoadMoney();

    }

    // Update is called once per frame
    void Update()
    {
        ////UPDATE LA UI
        if(TextoTotalCoins != null)
        {
            TextoTotalCoins.text = TotalCoins.ToString();
        }
        if (TextoLevelCoins != null)
       {
            TextoLevelCoins.text = LevelCoins.ToString();
      }


    }
    public void FinalizarNivelyGuardarMonedas()
    {

        TotalCoins += LevelCoins;
        PlayerPrefs.SetInt("MonedasTotales_nuevo", TotalCoins);
        DataBaseManager.SaveMoney(TotalCoins);
        //GuardarPuntosDB();
        
    }

    public void GuardarPuntosDB()
    {
        rankingGO.GetComponent<RankingManager>().InsertarPuntos(LevelCoins);
    }

    public void ObtenerPuntosDB()
    {
        rankingGO.GetComponent<RankingManager>().ObtenerRanking();
    }
  
    public void MostrarPuntosDB()
    {
        rankingGO.GetComponent<RankingManager>().MostrarRanking();
    }

    public bool QuitarMonedas(int monedasAQuitar)
    {
        if (TotalCoins >= monedasAQuitar)
        {
            TotalCoins -= monedasAQuitar;

            
            PlayerPrefs.SetInt("MonedasTotales_nuevo", TotalCoins);
            //PlayerPrefs.SetInt("MonedasActuales", PlayerPrefs.GetInt("MonedasTotales", 0) - monedasAQuitar);
            return true;

        }
        else
        {
            return false;
        }
    }
}
