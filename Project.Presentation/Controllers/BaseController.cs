using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Presentation.Models;
using CategoryAlert = Project.Presentation.Models.Style;

namespace Project.Presentation.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Esta função retorna em uma lista de Strings todos os erros de um dicionário ModelState. 
        /// </summary>
        /// <param name="modelState">Dicionário ModelState</param>
        /// <returns>Lista de erros do tipo String</returns>
        protected static List<string> ModelStateErrors(ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList;
        }

        #region Tipos de mensagens
        /// <summary>
        /// Este método envia uma mensagem de sucesso
        /// </summary>
        /// <param name="msg">Mensagem</param>
        /// <param name="descartavel">É possível fecha-lá?</param>
        protected void SuccessMessage(string msg, bool descartavel = false)
        {
            SendMessage(CategoryAlert.Success, msg, descartavel);
        }

        /// <summary>
        /// Este método envia uma mensagem de informação
        /// </summary>
        /// <param name="msg">Conteúdo da mensagem</param>
        /// <param name="descartavel">É possível fecha-lá?</param>
        protected void InformationMessage(string msg, bool descartavel = false)
        {
            SendMessage(CategoryAlert.Information, msg, descartavel);
        }

        /// <summary>
        /// Este método envia uma mensagem de alerta
        /// </summary>
        /// <param name="msg">Conteúdo da mensagem</param>
        /// <param name="descartavel">É possível fecha-lá?</param>
        public void AlertMessage(string msg, bool descartavel = false)
        {
            SendMessage(CategoryAlert.Atention, msg, descartavel);
        }

        /// <summary>
        /// Este método envia uma mensagem de erro
        /// </summary>
        /// <param name="msg">Conteúdo da mensagem</param>
        /// <param name="descartavel">É possível fecha-lá?</param>
        protected void ErrorMessage(string msg, bool descartavel = false)
        {
            SendMessage(CategoryAlert.Error, msg, descartavel);
        }

        /// <summary>
        /// Este método envia uma mensagem
        /// </summary>
        /// <param name="category">Estilo da mensagem</param>
        /// <param name="content">Conteúdo da mensagem</param>
        /// <param name="isDispensable">É possível fecha-lá?</param>
        private void SendMessage(string category, string content, bool isDispensable)
        {
            var msg = TempData.ContainsKey(Message.TempDataKey)
                ? (List<Message>)TempData[Message.TempDataKey]
                : new List<Message>();

            msg.Add(new Message
            {
                Style = category,
                Content = content,
                IsDispensable = isDispensable
            });

            TempData[Message.TempDataKey] = msg;
        }
        #endregion
    }
}