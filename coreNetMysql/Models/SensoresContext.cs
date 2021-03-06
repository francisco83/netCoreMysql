﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace coreNetMysql.Models
{
    public class SensoresContext
    {
        
        public string ConnectionString { get; set; }

        public SensoresContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        public List<DatosSensores> GetAll()
        {
            List<DatosSensores> list = new List<DatosSensores>();

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from datossensores", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DatosSensores()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Temperatura = Convert.ToDecimal(reader["Temperatura"]),
                                Humedad = Convert.ToDecimal(reader["Humedad"]),
                                Luminosidad = Convert.ToDecimal(reader["Luminosidad"]),
                                Voltsbateria = Convert.ToDecimal(reader["Voltsbateria"]),
                                Voltspanel = Convert.ToDecimal(reader["Voltspanel"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("No se pudieron recuperar los datos.",ex.Message);                
            }
            return list;
        }

        public Boolean Save(DatosSensores datosSensores)
        {
            Boolean result = true;

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into datossensores(Temperatura,Humedad,Luminosidad,Voltsbateria,Voltspanel)values("+datosSensores.Temperatura+","+datosSensores.Humedad+","+datosSensores.Luminosidad+","+datosSensores.Voltspanel+","+datosSensores.Voltsbateria+")", conn);

                    var reader = cmd.ExecuteReader();
   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar Registros", ex.Message);
                result = false;

            }
            return result;
        }
    }
}

