using API_FERIADOS.BLL;
using API_FERIADOS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_FERIADOS.Controllers
{
    /**
     * Autor: ALEX YUDY KITAHARA
     * DATA: 25/10/2022
     * **/



    [Route("api/[controller]")]
    [ApiController]
    public class FeriadoController : Controller
    {
        private readonly IConfiguration configuration;

        public FeriadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        [HttpGet]
        [Route("RetornaTodosFeriados")]
        public async IAsyncEnumerable<Feriado> RetornaTodosFeriados()
        {
            List<Feriado> LstFer = new List<Feriado>();
            FeriadoBO bo = new FeriadoBO();

            LstFer = bo.RetornaTodosFeriados(this.configuration);

            foreach (var fer in LstFer)
            {
                yield return fer;
            }

        }



        [HttpGet]
        [Route("RetornaFeriadoEspecifico")]
        public Feriado RetornaFeriadoEspecifico(string nome_feriado)
        {
            Feriado feriado = new Feriado();
            FeriadoBO bo = new FeriadoBO();

            feriado = bo.RetornaFeriadoEspecifico(this.configuration,nome_feriado);

            return feriado;

        }







    }
}
