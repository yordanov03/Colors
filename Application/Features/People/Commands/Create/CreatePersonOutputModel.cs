namespace Application.Features.People.Commands.Create
{
    public class CreatePersonOutputModel
    {
        public int Id { get; set; }

        public CreatePersonOutputModel(int id)
        => this.Id = id;
    }
}
