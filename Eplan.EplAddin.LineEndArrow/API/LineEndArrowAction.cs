using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.HEServices;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.Graphics;

namespace Eplan.EplAddin.LineEndArrow.API
{

    /// <summary>
    /// This class implements a EPLAN action.  The Action will register the Addins in that  <seealso cref="IEplAddIn.OnRegister"/> Registerst.
    /// <seealso cref="Eplan::EplApi::ApplicationFramework::IEplAction"/> 
    /// </summary>
    public class LineEndArrowAction : IEplAction
    {
        /// <summary>
        /// Execution of the Action.  
        /// </summary>
        /// <returns>True:  Execution of the Action was successful</returns>
        public bool Execute(ActionCallingContext ctx)
        {

            SelectionSet sel = new SelectionSet();

            List<Line> lines = sel.Selection.OfType<Line>().ToList();

            foreach (Line l in lines)
            {
                l.EndArrow = !l.EndArrow;
            }

            return true;
        }
        /// <summary>
        /// Function is called through the ApplicationFramework
        /// </summary>
        /// <param name="Name">Under this name, this Action in the system is registered</param>
        /// <param name="Ordinal">With this overload priority, this Action is registered</param>
        /// <returns>true: the return parameters are valid</returns>
        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = "LineEndArrowAction";
            Ordinal = 20;
            return true;
        }

        /// <summary>
        /// Documentation function for the Action; is called of the system as required 
        /// Bescheibungstext delivers for the Action itself and if the Action String-parameters ("Kommandozeile")
        /// also name and description of the single parameters evaluates
        /// </summary>
        /// <param name="actionProperties"> This object must be filled with the information of the Action.</param>
        public void GetActionProperties(ref ActionProperties actionProperties)
        {

        }

    }

}