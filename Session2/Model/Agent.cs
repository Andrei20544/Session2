namespace Session2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Agent")]
    public partial class Agent : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            AgentPriorityHistory = new HashSet<AgentPriorityHistory>();
            ProductSale = new HashSet<ProductSale>();
            Shop = new HashSet<Shop>();
        }

        public int ID { get; set; }

        [StringLength(150)]
        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnProppertyChanged();
            }
        }

        public int? AgentTypeID { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [StringLength(12)]
        public string INN { get; set; }

        [StringLength(9)]
        public string KPP { get; set; }

        [StringLength(100)]
        public string DirectorName { get; set; }

        [StringLength(30)]
        private string _phone { get; set; }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnProppertyChanged();
            }
        }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Logo { get; set; }

        public double? Priority { get; set; }

        public virtual AgentType AgentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shop { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProppertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
