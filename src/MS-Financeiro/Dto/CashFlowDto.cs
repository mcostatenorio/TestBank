using System.ComponentModel.DataAnnotations;

namespace MS_Financeiro.Dto
{
    public class CashFlowDto
    {
        public CashFlowDto()
        {

        }

        [Required(ErrorMessage = "Value is required.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Data transaction is required.")]
        public DateTime DataTransaction { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
    }
}
