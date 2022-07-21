using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interface;
using MediatR;

namespace ProductApplication.Command.Handler
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, List<string>>
    {
        private IUnitOfWork UnitOfWork;
        public InsertProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public Task<List<string>> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            // map InsertProductCommand to entity
            //rep add product 

            // log 
            //event

            UnitOfWork.CategoryRepository.AddAsyncEntity(new Entities.Category() { }, cancellationToken);


            // add product
            // add cat
            //update useer

            UnitOfWork.SaveChangesAsync(cancellationToken);
            //save 
            throw new NotImplementedException();
        }
    }
}
