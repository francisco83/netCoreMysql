using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

namespace coreNetMysql.Models
{
    public class MongoContext
    {
        
        public string ConnectionString { get; set; }


        public MongoContext(string connectionString)
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
            int i = 1;

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from padron", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        /*Conexion con MongoDb*/
                        try
                        {

                            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

                            //Get Database and Collection  
                            IMongoDatabase db = dbClient.GetDatabase("padron");
                            var coleccionPersonas = db.GetCollection<BsonDocument>("personas");




                        while (reader.Read())
                        {
                            /*list.Add(new DatosSensores()
                            {
                                Id = Convert.ToInt32(eader["Id"]r),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Temperatura = Convert.ToDecimal(reader["Temperatura"]),
                                Humedad = Convert.ToDecimal(reader["Humedad"]),
                                Luminosidad = Convert.ToDecimal(reader["Luminosidad"]),
                                Voltsbateria = Convert.ToDecimal(reader["Voltsbateria"]),
                                Voltspanel = Convert.ToDecimal(reader["Voltspanel"])
                            });*/

                            //CREATE  
                            BsonElement dni = new BsonElement("dni", Convert.ToInt32(reader["dni"]));
                            BsonElement anio = new BsonElement("anio", Convert.ToInt32(reader["anio"]));
                            BsonElement Apellido_Nombre = new BsonElement("Apellido_Nombre", (reader["Apellido_Nombre"]).ToString());
                            BsonElement profesion = new BsonElement("profesion", (reader["profesion"]).ToString());
                            BsonElement direccion = new BsonElement("direccion", (reader["direccion"]).ToString());
                            BsonElement tipo = new BsonElement("tipo", (reader["tipo"]).ToString());
                            BsonElement sexo = new BsonElement("sexo", (reader["sexo"]).ToString());

                            BsonDocument personDoc = new BsonDocument();
                            personDoc.Add(dni);
                            personDoc.Add(anio);
                            personDoc.Add(Apellido_Nombre);
                            personDoc.Add(profesion);
                            personDoc.Add(direccion);
                            personDoc.Add(tipo);
                            personDoc.Add(sexo);
                            //personDoc.Add(new BsonElement("PersonAge", 23));

                            coleccionPersonas.InsertOne(personDoc);

                            i++;
                            Console.WriteLine(i);


                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Fallo la conexión con Mongodb");
                        }

                    }
                }
            }
            catch (Exception ex) {
                
            }
            return list;
        }

        public Boolean Save(DatosSensores datosSensores)
        {
            Boolean result = false;

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

            }
            return result;
        }
    }
}

