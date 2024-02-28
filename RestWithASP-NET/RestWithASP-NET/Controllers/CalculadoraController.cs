using Microsoft.AspNetCore.Mvc;

namespace RestWithASP_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
       
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetSoma(string primeiroNumero, string segundoNumero)
        {
            if (heNumerico(primeiroNumero) && heNumerico(segundoNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) + ConverteParaDecimal(segundoNumero);
                 
                return Ok(soma.ToString());
            }
            
            return BadRequest("Valores Inv�lidos");
        }

        [HttpGet("subtracao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetSubtracao(string primeiroNumero, string segundoNumero)
        {
            if (heNumerico(primeiroNumero) && heNumerico(segundoNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) - ConverteParaDecimal(segundoNumero);

                return Ok(soma.ToString());
            }

            return BadRequest("Valores Inv�lidos");
        }

        [HttpGet("multiplicacao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetMultiplicacao(string primeiroNumero, string segundoNumero)
        {
            if (heNumerico(primeiroNumero) && heNumerico(segundoNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) * ConverteParaDecimal(segundoNumero);

                return Ok(soma.ToString());
            }

            return BadRequest("Valores Inv�lidos");
        }

        [HttpGet("divisao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetDivisao(string primeiroNumero, string segundoNumero)
        {
            if (heNumerico(primeiroNumero) && heNumerico(segundoNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) * ConverteParaDecimal(segundoNumero);

                return Ok(soma.ToString());
            }

            return BadRequest("Valores Inv�lidos");
        }

        [HttpGet("media/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetMedia(string primeiroNumero, string segundoNumero)
        {
            if (heNumerico(primeiroNumero) && heNumerico(segundoNumero))
            {
                var soma = (ConverteParaDecimal(primeiroNumero) + ConverteParaDecimal(segundoNumero))/2;

                return Ok(soma.ToString());
            }

            return BadRequest("Valores Inv�lidos");
        }

        [HttpGet("raiz/{primeiroNumero}")]
        public IActionResult GetRaiz(string numero)
        {
            if (heNumerico(numero) )
            {
                var raiz = Convert.ToSingle(Math.Sqrt( ConverteParaDouble(numero)));

                return Ok(raiz.ToString());
            }

            return BadRequest("Valores Inv�lidos");
        }

        private double ConverteParaDouble(string numero)
        {
            double valorDoble;
            if (double.TryParse(numero, out valorDoble))
            {
                return valorDoble;
            }
            return 0;
        }

        private bool heNumerico(string numero)
        {
            double valorDecimal;

            bool ehNumero = double.TryParse(numero,
                                            System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo,
                                            out valorDecimal);

            return ehNumero;

        }

        private decimal ConverteParaDecimal(string numero)
        {
            decimal valorDecimal;
            if (decimal.TryParse(numero,out valorDecimal))
            {
                return valorDecimal;
            }
            return 0;
        }
    }
}
