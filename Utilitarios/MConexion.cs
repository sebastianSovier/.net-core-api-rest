using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Descripción breve de MConexion
/// </summary>
public class MConexion {
    private readonly IConfiguration _config;

    public MConexion() {
    }

    public MConexion(IConfiguration config) {
        _config = config;
    }

    public OracleConnection getConexion(string ID_CONEXION) {
        OracleConnection conexion = null;
        try {

            if (_config.GetValue<string>(ID_CONEXION).ToString() != null) {
                conexion = new OracleConnection();
                conexion.ConnectionString = _config.GetValue<string>(ID_CONEXION);
                conexion.Open();
            } else {

                throw new Exception("La fuente de datos " + ID_CONEXION + "no existe");
            }

        } catch (Exception e) {
            throw new Exception("Error tecnico de conexion " + e.Message);
        }

        return conexion;
    }
}