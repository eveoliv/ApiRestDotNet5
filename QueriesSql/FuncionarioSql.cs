using AppNetCore5.Domain;

namespace AppNetCore5.QueriesSql
{
    public static class FuncionarioSql
    {       
        public static string Funcionarios() => $"SELECT * FROM FUNCIONARIO";
        public static string FuncionarioId(int id) => $"SELECT * FROM FUNCIONARIO WHERE ID = {id}";
        public static string FuncionarioInsert(FuncionarioPost f) => $"INSERT INTO FUNCIONARIO (NOME, CPF, DATA_ADMISSAO) VALUES ('{f.Nome}','{f.Cpf}','{f.Data_Admissao}')";
        public static string FuncionarioUpdate(Funcionario f) => $"UPDATE FUNCIONARIO SET NOME = '{f.Nome}', CPF = '{f.Cpf}', DATA_ADMISSAO = '{f.Data_Admissao}' WHERE ID = {f.Id}";
        public static string FuncionarioDelete(int id) => $"DELETE FROM FUNCIONARIO WHERE ID = {id}";             
    }
}
