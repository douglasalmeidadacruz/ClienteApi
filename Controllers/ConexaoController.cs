
using Microsoft.AspNetCore.Mvc;
using ClienteApi.Data;
using Npgsql;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConexaoController : ControllerBase
    {
        private readonly ConexaoBanco _conexaoBanco;

        public ConexaoController(ConexaoBanco conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }

        [HttpGet("testar")]
        public IActionResult TestarConexao()
        {
            try
            {
                using var conexao = _conexaoBanco.CriarConexao();

                conexao.Open();

                using var comando = new NpgsqlCommand(
                    "SELECT 1", conexao);

                var resultado = comando.ExecuteScalar();

                return Ok(new
                {
                    mensagem = "Conexão com o banco realizada com sucesso!",
                    resultado = resultado
                });
            }
            catch (Exception erro)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro ao conectar com o banco de dados.",
                    erro = erro.Message
                });
            }
        }
    }
}
