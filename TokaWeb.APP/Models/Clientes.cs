using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokaWeb.APP.Models
{
    public class Clientes
    {
        [JsonProperty("Data")]
        public List<Data> Data { get; set; } 
    }
    public class Data
    {
        [JsonProperty("IdCliente")]
        public int IdCliente { get; set; }

        [JsonProperty("FechaRegistroEmpresa")]
        public string FechaRegistroEmpresa { get; set; }

        [JsonProperty("RazonSocial")]
        public string RazonSocial { get; set; }

        [JsonProperty("RFC")]
        public string RFC { get; set; }

        [JsonProperty("Sucursal")]
        public string Sucursal { get; set; } 

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Paterno")]
        public string Paterno { get; set; }

        [JsonProperty("Materno")]
        public string Materno { get; set; }

        [JsonProperty("IdViaje")]
        public int IdViaje { get; set; }

    }
} 