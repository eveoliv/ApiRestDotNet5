using AppNetCore5.Domain;

namespace AppNetCore5.Repository
{
    public static class RepositoryQuery
    {
        #region operacoes_funcionarios
        public static string QryFuncionarios() => $"SELECT * FROM FUNCIONARIO";
        public static string QryFuncionarioId(int id) => $"SELECT * FROM FUNCIONARIO WHERE ID = {id}";
        public static string InsertFuncionario(FuncionarioPost f) => $"INSERT INTO FUNCIONARIO (NOME, CPF, DATA_ADMISSAO) VALUES ('{f.Nome}','{f.Cpf}','{f.Data_Admissao}')";
        public static string UpdateFuncionario(Funcionario f) => $"UPDATE FUNCIONARIO SET NOME = '{f.Nome}', CPF = '{f.Cpf}', DATA_ADMISSAO = '{f.Data_Admissao}' WHERE ID = {f.Id}";
        public static string DeleteFuncionario(int id) => $"DELETE FROM FUNCIONARIO WHERE ID = {id}";
        #endregion

        #region operacoes_clientes 
        public static string QryClientes() => $"SELECT * FROM CLIENTE";
        public static string QryClienteId(int id) => $"SELECT * FROM CLIENTE WHERE ID = {id}";
        public static string InsertCliente(ClientePost c) => $"INSERT INTO CLIENTE (NOME, CPF, DATA_INCLUSAO) VALUES ('{c.Nome}','{c.Cpf}','{c.Data_Inclusao}')";
        public static string UpdateCliente(Cliente c) => $"UPDATE CLIENTE SET NOME = '{c.Nome}', CPF = '{c.Cpf}', DATA_INCLUSAO = '{c.Data_Inclusao}' WHERE ID = {c.Id}";
        public static string DeleteCliente(int id) => $"DELETE FROM CLIENTE WHERE ID = {id}";
        #endregion

    }
}
