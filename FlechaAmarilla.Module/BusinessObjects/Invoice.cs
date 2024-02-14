using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FlechaAmarilla.Module.BusinessObjects
{
    [DefaultClassOptions] 
    [ImageName("BO_Note")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Invoice : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Invoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).

            InvoiceDate = DateTime.Now;
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (InvoiceNumber == 0)
            {
                
                    InvoiceNumber = new XPQuery<Invoice>(Session).Count() + 1;
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

           

        }

       

        string invoiceName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceName
        {
            get => invoiceName;
            set => SetPropertyValue(nameof(InvoiceName), ref invoiceName, value);
        }

        int invoiceNumber;
        public int InvoiceNumber
        {
            get => invoiceNumber;
            set => SetPropertyValue(nameof(InvoiceNumber), ref invoiceNumber, value);
        }

        DateTime invoiceDate;
        public DateTime InvoiceDate
        {
            get => invoiceDate;
            set => SetPropertyValue(nameof(InvoiceDate), ref invoiceDate, value);
        }

        decimal cost;
        public decimal Cost
        {
            get => cost;
            set => SetPropertyValue(nameof(Cost), ref cost, value);
        }

        double order;
        public double Order
        {
            get => order;
            set => SetPropertyValue(nameof(Order), ref order, value);
        }

        Customer customer;
        [Association("Customer-Invoices")]
        public Customer Customer
        {
            get => customer;
            set => SetPropertyValue(nameof(Customer), ref customer, value);
        }

        [Association("xyz"), DevExpress.Xpo.Aggregated]
        public XPCollection<InvoiceDetails> InvoiceDetails
        {
            get
            {
                return GetCollection<InvoiceDetails>(nameof(InvoiceDetails));
            }
        }

        [Association("Invoice-Payments")]
        public XPCollection<Payment> Payments
        {
            get
            {
                return GetCollection<Payment>(nameof(Payments));
            }
        }



        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}