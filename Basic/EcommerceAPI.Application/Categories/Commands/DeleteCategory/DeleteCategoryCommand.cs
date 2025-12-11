using MediatR;

namespace EcommerceAPI.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand() { }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
