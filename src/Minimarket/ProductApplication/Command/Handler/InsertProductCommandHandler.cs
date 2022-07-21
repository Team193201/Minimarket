using Infrastructure.Interface;
using MediatR;
using ProductApplication.Dto;

namespace ProductApplication.Command.Handler
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, InsertProductDto>
    {
        private IUnitOfWork UnitOfWork;
        public InsertProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public Task<InsertProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            // map InsertProductCommand to entity
            //rep add product 

            // log 
            //event

            // UnitOfWork.CategoryRepository.AddAsyncEntity(new Entities.Category() { }, cancellationToken);


            // add product
            // add cat
            //update useer

            //UnitOfWork.SaveChangesAsync(cancellationToken);
            //save 
            throw new NotImplementedException();
        }
    }
}
