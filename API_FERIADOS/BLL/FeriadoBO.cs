using API_FERIADOS.DAO;
using API_FERIADOS.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_FERIADOS.BLL
{
    public class FeriadoBO
    {
        

        public List<Feriado> RetornaTodosFeriados(IConfiguration configuration)
        {
            try
            {
                List<Feriado> LstFer = new List<Feriado>();
                FeriadoDAO fr = new FeriadoDAO(configuration);

                LstFer = fr.RetornaTodosFeriados();

                return LstFer;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Feriado RetornaFeriadoEspecifico(IConfiguration configuration, string nome_feriado)
        {
            try
            {
                Feriado feriadoObj = new Feriado();
                FeriadoDAO fr = new FeriadoDAO(configuration);

                feriadoObj = fr.BuscaFeriadoEspecifico(nome_feriado);

                return feriadoObj;

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
