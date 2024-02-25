/* TODO - APP responsável por gerenciamento de contas bancárias;
    1. Nossa conta bancária precisa receber um número com 10 digitos que identifica a conta bancária;
    2. Ela tem uma cadeia de caracteres que armazena o nome ou os nomes dos proprietários;
    3. O saldo pode ser recuperado;
    4. Ela aceita depositos;
    5. Ela aceita saques;
    6. O saldo inicial deve ser positivo;
    7. Os saques nao podem resultar em um saldo negativo.
*/

using Classes;

var account = new BankAccount("<name>", 2000);
Console.WriteLine($"Conta: {account.Number} Responsável: {account.Owner} Saldo: {account.Balance}");
account.MakeWithDrawal(500, DateTime.Now, "Pagamento de despesas.");
Console.WriteLine($"Saque R$ 500, Saldo Atual: {account.Balance} - Pagamento de despesas.");
account.MakeDeposit(100, DateTime.Now, "Receita ref. a serviço prestado");
Console.WriteLine($"Deposito R$ 100,00, Saldo Atual: {account.Balance} - Receita ref. a serviço prestado.");
Console.WriteLine($"Conta: {account.Number} Responsável: {account.Owner} Saldo: {account.Balance}");

System.Console.WriteLine("::Histórico de Transações::....................................");
System.Console.WriteLine(account.GetAccountHistory());

