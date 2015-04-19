using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mango.Core.Migrations;

namespace Mango.Core.Web
{
    public static class ExceptionLogger
    {
        /// <summary>
        /// Logs custom error without an inner exception (overload)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="objectStates"></param>
        public static void Log(string message, List<object> objectStates = null)
        {
            var builder = new StringBuilder();
            builder.AppendLine(message);
            Log(builder, null, objectStates);
        }

        /// <summary>
        /// Logs custom error without an inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="objectStates"></param>
        public static void Log(StringBuilder message, List<object> objectStates = null)
        {
            if (objectStates != null)
            {
                message.AppendLine(ObjectStates(objectStates));
            }
            Log(message, null, objectStates);
        }

        /// <summary>
        /// Logs custom error with an inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="objectStates"></param>
        public static void Log(StringBuilder message, Exception innerException = null, List<object> objectStates = null)
        {
            if (objectStates != null)
            {
                message.AppendLine(ObjectStates(objectStates));
            }
            var exception = innerException != null
                ? new Exception(message.ToString(), innerException)
                : new Exception(message.ToString());
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectStates"></param>
        /// <returns></returns>
        private static string ObjectStates(List<object> objectStates)
        {
            if (objectStates.Count == 0)
            {
                return string.Empty;
            }
            
            var builder = new StringBuilder();
            builder.Append("\r\n\r\n====Object States============================\r\n");
            foreach (var objectState in objectStates)
            {
                builder.AppendLine(ObjectStateToString(objectState));
                builder.Append("\r\n=============================================\r\n");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Creates a string of all property value pair in the provided object instance
        /// </summary>
        /// <param name="objectState"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        private static string ObjectStateToString(object objectState)
        {
            if (objectState == null)
            {
                //const string PARAMETER_NAME = "objectState";
                //throw new ArgumentException(string.Format("Parameter {0} cannot be null", PARAMETER_NAME), PARAMETER_NAME);
                return "-----NULL OBJECT";
            }
            var builder = new StringBuilder();
            builder.AppendFormat("-----{0}:", objectState.GetType().Name);
            builder.AppendLine("");
            foreach (var property in objectState.GetType().GetProperties())
            {
                object value = property.GetValue(objectState, null);

                builder.Append(property.Name)
                .Append(" = ")
                .Append((value ?? "null"))
                .AppendLine();
            }
            return builder.ToString();
        }

    }
}
