using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador.resultados
{
    public class ResultadosDAO
    {
        Clasedatos clasedatos = null;
        DataTable listaDatos = null;
        ResultadosDTO resultadosDTO = null;

        public ResultadosDAO(ResultadosDTO resultadosDTO)
        {
            this.resultadosDTO = resultadosDTO;
        }

        public DataTable ListarResultados()
        {
            listaDatos = new DataTable();
            try
            {
                clasedatos = new Clasedatos();
                SqlParameter[] parametros = null;

                if (this.resultadosDTO == null)
                {

                    parametros = new SqlParameter[4];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@numerodocumento";
                    parametros[0].SqlDbType = SqlDbType.BigInt;
                    parametros[0].SqlValue = resultadosDTO.getNumerodocumento();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@nombreparticipante";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = resultadosDTO.getNombreparticipante();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@idposicion";
                    parametros[2].SqlDbType = SqlDbType.TinyInt;
                    parametros[2].SqlValue = resultadosDTO.getIdposicion();

                    parametros[3] = new SqlParameter();
                    parametros[3].ParameterName = "@idpais";
                    parametros[3].SqlDbType = SqlDbType.TinyInt;
                    parametros[3].SqlValue = resultadosDTO.getIdpais();
                }
                else
                {
                    parametros = null;
                }

                listaDatos = clasedatos.retornaTabla(parametros, "spresultados_listar");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return listaDatos;
        }


        public void guardarNuevoResultado() {

            
            //ParametrosGenerico parametrosGenerico = new ParametrosGenerico();

            try {

                clasedatos = new Clasedatos();
               SqlParameter[] parametros = new SqlParameter[3];
                
                 parametros[0] = new SqlParameter();
                 parametros[0].ParameterName = "@numerodocumento";
                 parametros[0].SqlDbType = SqlDbType.BigInt;
                 parametros[0].SqlValue = resultadosDTO.getNumerodocumento();
                
                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@nombreparticipante";
                parametros[1].SqlDbType = SqlDbType.VarChar;
                parametros[1].Size = 50;
                parametros[1].SqlValue = resultadosDTO.getNombreparticipante();
                
                parametros[2] = new SqlParameter();
                parametros[2].ParameterName = "@idposicion";
                parametros[2].SqlDbType = SqlDbType.TinyInt;
                parametros[2].SqlValue = resultadosDTO.getIdposicion();
                
               

                clasedatos.ejecutarSP(parametros, "spresultados_guardar");
            }
            catch (Exception exception) {
                throw new Exception(exception.Message);
            }
        }

        public void guardarCambiosResultados()
        {

           

            try
            {
                clasedatos = new Clasedatos();

               SqlParameter[]  parametros = new SqlParameter[2];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@numerodocumento";
                parametros[0].SqlDbType = SqlDbType.BigInt;
                parametros[0].SqlValue = resultadosDTO.getNumerodocumento();

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@idposicion";
                parametros[1].SqlDbType = SqlDbType.TinyInt;
                parametros[1].SqlValue = resultadosDTO.getIdposicion();

                clasedatos.ejecutarSP(parametros, "spresultados_guardarcambios");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }

        public void eliminarResultado()
        {
             
            //ParametrosGenerico parametrosGenerico = new ParametrosGenerico();

            try
            {

                clasedatos = new Clasedatos();
                SqlParameter[] parametros = new SqlParameter[1];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@numerodocumento";
                parametros[0].SqlDbType = SqlDbType.BigInt;
                parametros[0].SqlValue = resultadosDTO.getNumerodocumento();

                clasedatos.ejecutarSP(parametros, "spresultados_eliminar");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);

            }

        }
    }
}
