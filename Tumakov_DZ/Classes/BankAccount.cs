using System;

namespace Tumakov_DZ
{
    public class BankAccount
    {
        private static int lastAccountNumber = 0; 
        private readonly int accountNumber; 
        private string accountHolder;
        private decimal balance;
        public int AccountNumber => accountNumber; 
        public string AccountHolder
        {
            get => accountHolder;
            set => accountHolder = value;
        }
        public decimal Balance => balance; 

      
        public BankAccount(string holderName, decimal initialBalance)
        {
            accountNumber = ++lastAccountNumber; 
            accountHolder = holderName;
            balance = initialBalance > 0 ? initialBalance : 0; 
        }

        
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Счет {accountNumber}: Пополнен на сумму {amount}. Новый баланс: {balance}");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть больше 0.");
            }
        }

   
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Счет {accountNumber}: Снято {amount}. Новый баланс: {balance}");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств для снятия.");
            }
            else
            {
                Console.WriteLine("Сумма снятия должна быть больше 0.");
            }
        }


        public void TransferTo(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                Console.WriteLine("Ошибка: Целевой счет не найден.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше 0.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств для перевода.");
                return;
            }

          
            balance -= amount;
            targetAccount.Deposit(amount);
            Console.WriteLine($"Переведено {amount} со счета {accountNumber} на счет {targetAccount.AccountNumber}.");
        }

     
        public void DisplayInfo()
        {
            Console.WriteLine($"Счет №{accountNumber}, Владелец: {accountHolder}, Баланс: {balance}");
        }
    }
}
