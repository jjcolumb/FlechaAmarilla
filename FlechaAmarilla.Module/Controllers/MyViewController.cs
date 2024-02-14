using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using FlechaAmarilla.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlechaAmarilla.Module.Controllers
{
    public class MyViewController : ViewController
    {
        SimpleAction action;
        public MyViewController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
       
            action = new SimpleAction(this, "Invoice Action", PredefinedCategory.View);
            action.Execute += action_Execute;
            action.TargetViewId = "Invoice_ListView";
            

        }
        private void action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var invoice = e.CurrentObject as Invoice;
            
            if(invoice!= null)
            {
                invoice.InvoiceName = "Invoice Name";
            }
         
            ObjectSpace.CommitChanges();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
