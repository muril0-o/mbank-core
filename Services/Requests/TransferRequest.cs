namespace Services.Requests;

public class TransferRequest()
{
    public decimal Amount { get; set; }
    public string? FromAccountNumber { get; set; }
    public string? ToAccountNumber { get; set; }
}