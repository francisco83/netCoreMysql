using System;
namespace coreNetMysql.Models
{
    public class DatosSensores
    {
        private SensoresContext context;
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Humedad { get; set; }
        public decimal Luminosidad { get; set; }
        public decimal Voltspanel { get; set; }
        public decimal Voltsbateria { get; set; }
    }
}
