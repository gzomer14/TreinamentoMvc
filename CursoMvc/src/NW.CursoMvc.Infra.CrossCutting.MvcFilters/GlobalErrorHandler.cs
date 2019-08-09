using System.Web.Mvc;

namespace NW.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                //Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                // -> Gravar log do erro
                // -> Email para o admin
                // -> Retornar cod de erro amigavel

                filterContext.Controller.TempData["ErrorCode"] = "123664";
            }

            base.OnActionExecuted(filterContext);
        }
    }
}