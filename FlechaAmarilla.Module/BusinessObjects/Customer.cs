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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Customer : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Customer(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string campo1;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Campo1
        {
            get => campo1;
            set => SetPropertyValue(nameof(Campo1), ref campo1, value);
        }


        DateTime campoDate;
        public DateTime CampoDate
        {
            get => campoDate;
            set => SetPropertyValue(nameof(CampoDate), ref campoDate, value);
        }


        int campoAge;
        public int CampoAge
        {
            get => campoAge;
            set => SetPropertyValue(nameof(CampoAge), ref campoAge, value);
        }

        [Association("Customer-Invoices")]
        public XPCollection<Invoice> Invoices
        {
            get
            {
                return GetCollection<Invoice>(nameof(Invoices));
            }
        }

        [Association("Customer-Payments")]
        public XPCollection<Payment> Payments
        {
            get
            {
                return GetCollection<Payment>(nameof(Payments));
            }
        }
    }
}