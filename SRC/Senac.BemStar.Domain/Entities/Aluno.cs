namespace Senac.BemStar.Domain.Entities
{
    public class Aluno
    {
        public Aluno(string nome, DateTime dataNascimento, string email)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
