namespace ProductApplication.Command.Handler
{
    public class InsertRoleCommandHandler : IRequestHandler<InsertRoleCommand, InsertRoleDto>
    {
        private IUnitOfWork UnitOfWork;
        public InsertRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public Task<InsertRoleDto> Handle(InsertRoleCommand request, CancellationToken cancellationToken)
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
