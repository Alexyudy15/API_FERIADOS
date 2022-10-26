using API_FERIADOS.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FERIADOS.DAO
{
    public class FeriadoDAO
    {
        string conn = "";
        public FeriadoDAO(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("Conn");
        }

        public List<Feriado> RetornaTodosFeriados()
        {
            try
            {
                DataSet ds = new DataSet();

                string sql = "SELECT FER_DESCRICAO, FER_DATA FROM TB_FERIADO WHERE DATEPART(YEAR,FER_DATA) = DATEPART(YEAR,GETDATE())";

                using (SqlConnection cn = new SqlConnection(conn))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 360000;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            da.Dispose();
                        }
                    }
                }


                List<Feriado> fr = new List<Feriado>();
                DataTable dt = new DataTable();
                dt = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Feriado feriadoObj = new Feriado();

                        feriadoObj.Descricao_Feriado = dt.Rows[i]["FER_DESCRICAO"].ToString();
                        feriadoObj.Data = dt.Rows[i]["FER_DATA"].ToString();
                        fr.Add(feriadoObj);

                        
                    }
                    return fr;
                }
                else
                {
                    throw new Exception("Não foi localizado nenhum feriado");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public Feriado BuscaFeriadoEspecifico(string nome_Feriado)
        {
            try
            {
                DataSet ds = new DataSet();

                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT TOP 1 FER_DESCRICAO, FER_DATA FROM TB_FERIADO WHERE FER_DESCRICAO = @FERIADO " +
                    " AND DATEPART(YEAR, FER_DATA) = DATEPART(YEAR, GETDATE()) ");

                using (SqlConnection cn = new SqlConnection(conn))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 360000;

                        cmd.Parameters.AddWithValue("@FERIADO", nome_Feriado);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            da.Dispose();
                        }
                    }
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    Feriado feriadoObj = new Feriado();

                    feriadoObj.Descricao_Feriado = ds.Tables[0].Rows[0]["FER_DESCRICAO"].ToString();
                    feriadoObj.Data = ds.Tables[0].Rows[0]["FER_DATA"].ToString();

                    return feriadoObj;
                }
                else
                {
                    throw new Exception("Não foi localizado nenhum feriado");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








    }
}
