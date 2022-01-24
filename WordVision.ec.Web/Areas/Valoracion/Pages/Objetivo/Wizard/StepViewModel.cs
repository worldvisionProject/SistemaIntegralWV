namespace WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard
{
    public abstract class StepViewModel
    {
        /// <summary>
        /// Allows to control the order of a list of steps.
        /// </summary>
        public int Position { get; protected set; }
    }
}