using System;
using System.Collections;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

/// <summary>
/// Descripción breve de MCommand
/// </summary>
public class MCommand {
    private string sCommandText;
    private OracleConnection conexion;
    private ArrayList arrNomParametros;
    private Hashtable hashParametros;
    private DataTable tableRegresoSP;

    public MCommand() {
        this.arrNomParametros = new ArrayList();
        this.hashParametros = new Hashtable();
        this.tableRegresoSP = new DataTable();
    }

    public DataTable ejecutarMultiRegistro() {
        OracleCommand selectCommand = (OracleCommand)null;
        OracleDataAdapter oracleDataAdapter = (OracleDataAdapter)null;
        DataTable dataTable = new DataTable("RESULTADO");
        try {
            selectCommand = new OracleCommand(this.sCommandText, this.conexion);
            selectCommand.CommandType = CommandType.Text;
            oracleDataAdapter = new OracleDataAdapter(selectCommand);
            oracleDataAdapter.Fill(dataTable);
        } catch (Exception ex) {
            throw new Exception("Error CDCommand.ejecutarMultiRegistro() " + ex.Message);
        } finally {
            oracleDataAdapter.Dispose();
            selectCommand.Dispose();
        }
        return dataTable;
    }

    public DataRow ejecutarRegistro() {
        OracleCommand selectCommand = (OracleCommand)null;
        OracleDataAdapter oracleDataAdapter = (OracleDataAdapter)null;
        DataTable dataTable = new DataTable("RESULTADO");
        DataRow dataRow = (DataRow)null;
        try {
            selectCommand = new OracleCommand(this.sCommandText, this.conexion);
            selectCommand.CommandType = CommandType.Text;
            oracleDataAdapter = new OracleDataAdapter(selectCommand);
            oracleDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
                dataRow = dataTable.Rows[0];
        } catch (Exception ex) {
            throw new Exception("Error CDCommand.ejecutarRegistro() " + ex.Message);
        } finally {
            oracleDataAdapter.Dispose();
            selectCommand.Dispose();
        }
        return dataRow;
    }

    public void ejecutar() {
        OracleCommand oracleCommand = (OracleCommand)null;
        try {
            oracleCommand = new OracleCommand(this.sCommandText, this.conexion);
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.ExecuteNonQuery();
        } catch (Exception ex) {
            throw new Exception("Error CDCommand.ejecutar() " + ex.Message);
        } finally {
            oracleCommand.Dispose();
        }
    }

    public void ejecutarSP() {
        OracleCommand oracleCommand = (OracleCommand)null;
        try {
            oracleCommand = new OracleCommand(this.sCommandText, this.conexion);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            foreach (string arrNomParametro in this.arrNomParametros) {
                OracleParameter hashParametro = (OracleParameter)this.hashParametros[(object)arrNomParametro];
                oracleCommand.Parameters.Add(hashParametro);
            }
            oracleCommand.ExecuteNonQuery();
        } catch (Exception ex) {
            throw new Exception("Error CDCommand.ejecutarSP() " + ex.Message);
        } finally {
            if (oracleCommand != null) {
                oracleCommand.Parameters.Clear();
                oracleCommand.Dispose();
            }
        }
    }

    public DataRow ejecutarRegistroSP() {
        OracleCommand oracleCommand = (OracleCommand)null;
        DataRow row = (DataRow)null;
        OracleParameter oracleParameter = (OracleParameter)null;
        try {
            oracleCommand = new OracleCommand(this.sCommandText, this.conexion);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            foreach (string arrNomParametro in this.arrNomParametros) {
                oracleParameter = (OracleParameter)this.hashParametros[(object)arrNomParametro];
                oracleCommand.Parameters.Add(oracleParameter);
            }
            oracleCommand.ExecuteNonQuery();
            row = this.tableRegresoSP.NewRow();
            foreach (string arrNomParametro in this.arrNomParametros) {
                oracleParameter = (OracleParameter)this.hashParametros[(object)arrNomParametro];
                if ((oracleParameter.Direction.Equals((object)ParameterDirection.Output) || oracleParameter.Direction.Equals((object)ParameterDirection.InputOutput) || oracleParameter.Direction.Equals((object)ParameterDirection.ReturnValue)) && oracleParameter.Value != DBNull.Value) {
                    if (oracleParameter.OracleDbType.Equals((object)OracleDbType.Date)) {
                        OracleDate oracleDate = (OracleDate)oracleParameter.Value;
                        row[arrNomParametro] = (object)oracleDate.Value;
                    } else if (oracleParameter.OracleDbType.Equals((object)OracleDbType.Clob)) {
                        OracleClob oracleClob = (OracleClob)oracleParameter.Value;
                        row[arrNomParametro] = (object)oracleClob.Value;
                    } else
                        row[arrNomParametro] = (object)oracleParameter.Value.ToString();
                }
            }
            this.tableRegresoSP.Rows.Add(row);
        } catch (Exception ex) {
            throw new Exception("Error CDCommand.ejecutarRegistroSP() " + oracleParameter.ParameterName + "  " + oracleParameter.OracleDbType.ToString() + "  " + oracleParameter.Value + " " + ex.Message);
        } finally {
            if (oracleCommand != null) {
                oracleCommand.Parameters.Clear();
                oracleCommand.Dispose();
            }
        }
        return row;
    }

    public DataSet ejecutarRefCursorSP() {
        OracleCommand selectCommand = (OracleCommand)null;
        OracleParameter oracleParameter = (OracleParameter)null;
        OracleDataAdapter oracleDataAdapter = (OracleDataAdapter)null;
        DataSet dataSet = new DataSet();
        try {
            selectCommand = new OracleCommand(this.sCommandText, this.conexion);
            selectCommand.CommandType = CommandType.StoredProcedure;
            foreach (string arrNomParametro in this.arrNomParametros) {
                oracleParameter = (OracleParameter)this.hashParametros[(object)arrNomParametro];
                selectCommand.Parameters.Add(oracleParameter);
            }
            oracleDataAdapter = new OracleDataAdapter(selectCommand);
            oracleDataAdapter.Fill(dataSet);
            DataRow row = this.tableRegresoSP.NewRow();
            foreach (string arrNomParametro in this.arrNomParametros) {
                oracleParameter = (OracleParameter)this.hashParametros[(object)arrNomParametro];
                if (!oracleParameter.OracleDbType.Equals((object)OracleDbType.RefCursor) && (oracleParameter.Direction.Equals((object)ParameterDirection.Output) || oracleParameter.Direction.Equals((object)ParameterDirection.InputOutput)) && oracleParameter.Value != DBNull.Value) {
                    if (oracleParameter.OracleDbType.Equals((object)OracleDbType.Date)) {
                        OracleDate oracleDate = (OracleDate)oracleParameter.Value;
                        row[arrNomParametro] = (object)oracleDate.Value;
                    } else if (oracleParameter.OracleDbType.Equals((object)OracleDbType.Clob)) {
                        OracleClob oracleClob = (OracleClob)oracleParameter.Value;
                        row[arrNomParametro] = (object)oracleClob.Value;
                    } else
                        row[arrNomParametro] = (object)oracleParameter.Value.ToString();
                }
            }
            this.tableRegresoSP.Rows.Add(row);
            dataSet.Tables.Add(this.tableRegresoSP);
        } catch (Exception ex) {
            throw new Exception("Error CDCommand.ejecutarRefCursorSP() " + oracleParameter.ParameterName + "  " + oracleParameter.OracleDbType.ToString() + "  " + oracleParameter.Value + " " + ex.Message);
        } finally {
            oracleDataAdapter.Dispose();
            if (selectCommand != null) {
                selectCommand.Parameters.Clear();
                selectCommand.Dispose();
            }
        }
        return dataSet;
    }

    public void agregarINParametro(string NOMBRE, OracleDbType TIPO, object VALOR) {
        this.hashParametros.Add((object)NOMBRE, (object)new OracleParameter(NOMBRE, TIPO, ParameterDirection.Input) {
            Value = (VALOR == null ? (object)DBNull.Value : VALOR)
        });
        this.arrNomParametros.Add((object)NOMBRE);
    }

    public void agregarOUTParametro(string NOMBRE, OracleDbType TIPO, int SIZE) {
        OracleParameter oracleParameter = new OracleParameter(NOMBRE, TIPO, (object)SIZE, ParameterDirection.Output);
        oracleParameter.Size = SIZE;
        if (TIPO.Equals((object)OracleDbType.Date))
            this.tableRegresoSP.Columns.Add(new DataColumn(NOMBRE, typeof(DateTime)));
        else if (!TIPO.Equals((object)OracleDbType.RefCursor))
            this.tableRegresoSP.Columns.Add(new DataColumn(NOMBRE, typeof(string)));
        this.hashParametros.Add((object)NOMBRE, (object)oracleParameter);
        this.arrNomParametros.Add((object)NOMBRE);
    }

    public void agregarINOUTParametro(string NOMBRE, OracleDbType TIPO, int SIZE, object VALOR) {
        OracleParameter oracleParameter = new OracleParameter(NOMBRE, TIPO, (object)SIZE, ParameterDirection.InputOutput);
        oracleParameter.Size = SIZE;
        oracleParameter.Value = VALOR != null ? VALOR : (object)DBNull.Value;
        if (TIPO.Equals((object)OracleDbType.Date))
            this.tableRegresoSP.Columns.Add(new DataColumn(NOMBRE, typeof(DateTime)));
        else
            this.tableRegresoSP.Columns.Add(new DataColumn(NOMBRE, typeof(string)));
        this.hashParametros.Add((object)NOMBRE, (object)oracleParameter);
        this.arrNomParametros.Add((object)NOMBRE);
    }

    public void agregarRETURNParametro(string NOMBRE, OracleDbType TIPO, int SIZE) {
        OracleParameter oracleParameter = new OracleParameter(NOMBRE, TIPO, (object)SIZE, ParameterDirection.ReturnValue);
        oracleParameter.Size = SIZE;
        if (TIPO.Equals((object)OracleDbType.Date))
            this.tableRegresoSP.Columns.Add(new DataColumn(NOMBRE, typeof(DateTime)));
        else if (!TIPO.Equals((object)OracleDbType.RefCursor))
            this.tableRegresoSP.Columns.Add(new DataColumn(NOMBRE, typeof(string)));
        this.hashParametros.Add((object)NOMBRE, (object)oracleParameter);
        this.arrNomParametros.Add((object)NOMBRE);
    }

    public void removeAll() {
        this.arrNomParametros.Clear();
        this.hashParametros.Clear();
        this.tableRegresoSP.Clear();
        this.tableRegresoSP.Columns.Clear();
    }

    public string CommandText {
        get {
            return this.sCommandText;
        }
        set {
            this.sCommandText = value;
        }
    }

    public OracleConnection Connection {
        get {
            return this.conexion;
        }
        set {
            this.conexion = value;
        }
    }
}