namespace Classes;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransaction)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }
    private static int accountNumberSeed = 1234567890;
    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;
        MakeDeposit(initialBalance, DateTime.Now, "Deposito Inicial");
    }

    private List<Transaction> allTransaction = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "O valor do deposito deve ser positivo");
        }
        var deposit = new Transaction(amount, date, note);
        allTransaction.Add(deposit);
    }
    public void MakeWithDrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "O valor da retirada deve ser positivo");
        }
        else if (Balance - amount < 0)
        {
            throw new InvalidOperationException("O valor da retirada nao pode ser executada, favor verificar o saldo!");
        };
        var withDrawal = new Transaction(-amount, date, note);
        allTransaction.Add(withDrawal);
    }
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();
        decimal balance = 0;
        report.AppendLine("Data     \tValor \tSaldo \tDescricao");
        foreach (var item in allTransaction)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}
