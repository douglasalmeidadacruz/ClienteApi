
using Npgsql;

namespace ClienteApi.Data
{
    public class ConexaoBanco
    {
        private readonly string _connectionString;

        public ConexaoBanco(IConfiguration configuration)
        {
            _connectionString = configuration
                .GetConnectionString("ConexaoPostgres")!;
        }

        public NpgsqlConnection CriarConexao()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
