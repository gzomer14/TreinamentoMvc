using NW.CursoMvc.Infra.Data.UnitOfWork;

namespace NW.CursoMvc.Application
{
    public class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}