using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Financeiro.Models
{
    public class CashFlowModel
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public double Value { get; set; }

        public DateTime DataTransaction { get; set; }

        public int UserId { get; set; }
    }
}
