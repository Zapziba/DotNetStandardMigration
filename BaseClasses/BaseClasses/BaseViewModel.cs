using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseClasses
{
    public class BaseViewModel : BaseINPC
    {
        #region Command Helpers
        /// <summary>
        /// Runs a command if the updating flag is not set
        /// If the flag is true (indicating the function is already running) then the action is not run
        /// If the flag is false (indicating no running function) then the action is run
        /// Once the action is finished if it was run, the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining ifthe command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Check if the flag property is true (meaning the function is already running
            if (updatingFlag.GetPropertyValue() ) { return; }

            //todo : continue from 43:00
            //Set the property flag to true to indicate that we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                //Set the property flag back to false
                updatingFlag.SetPropertyValue(false);
            }




        }
        #endregion
    }
}
