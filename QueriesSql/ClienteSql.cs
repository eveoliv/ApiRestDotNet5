using AppNetCore5.Domain;

namespace AppNetCore5.QueriesSql
{    
    public class ClienteSql
    {
        public static string Clientes() => $"SELECT * FROM CLIENTE";
        public static string ClienteId(int id) => $"SELECT * FROM CLIENTE WHERE ID = {id}";
        public static string ClienteInsert(ClientePost c) => $"INSERT INTO CLIENTE (NOME, CPF, DATA_INCLUSAO) VALUES ('{c.Nome}','{c.Cpf}','{c.Data_Inclusao}')";
        public static string ClienteUpdate(Cliente c) => $"UPDATE CLIENTE SET NOME = '{c.Nome}', CPF = '{c.Cpf}', DATA_INCLUSAO = '{c.Data_Inclusao}' WHERE ID = {c.Id}";
        public static string ClienteDelete(int id) => $"DELETE FROM CLIENTE WHERE ID = {id}";
    }
}
