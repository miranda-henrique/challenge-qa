
namespace CadastroAlunoTest.Models
{
    public class CandidatoModel
    {
        public string cpf { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string dataNascimento { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }

        public CandidatoModel()
        {
        }

        public CandidatoModel(string cpf, string nome, string sobrenome, string dataNascimento, string email, string celular, string cep, string endereco, string bairro, string cidade, string estado, string pais)
        {
            cpf = cpf;
            nome = nome;
            sobrenome = sobrenome;
            dataNascimento = dataNascimento;
            email = email;
            celular = celular;
            cep = cep;
            endereco = endereco;
            bairro = bairro;
            cidade = cidade;
            estado = estado;
            pais = pais;
        }
    }
}
