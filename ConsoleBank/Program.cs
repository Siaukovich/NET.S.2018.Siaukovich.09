namespace ConsoleBank
{
    using System;
    using System.Linq;

    using AccountService;
    using BankAccount;
    using HolderService;
    using Repository;

    class Program
    {
        static void Main(string[] args)
        {
            AbstractAccountService service = ServiceProvider.GetService();

            service.OpenAccount("Kyril Siaukovich", "+1 (123) 123-1234", "k.sevkovich@gmail.com", "11 Foo st.", new BaseBankAccountFactory());
            service.OpenAccount("Kyril Siaukovich", "+1 (123) 123-1234", "k.sevkovich@gmail.com", "11 Foo st.", new BaseBankAccountFactory());
            service.OpenAccount("Dmitry Siaukovich", "+1 (012) 123-1234", "d.sevkovich@gmail.com", "12 Foo st.", new SilverBankAccountFactory());
            service.OpenAccount("Foo Bar", "+1 (012) 123-1234", "i.am.still.using@mail.ru", "22 Alef st.", new GoldBankAccountFactory());

            Console.WriteLine("All holders:");
            foreach (Holder holder in HolderService.GetAllHolders())
            {
                Console.WriteLine(holder.Name);
                foreach (var account in holder.GetAllAccounts())
                {
                    Console.WriteLine("\t" + account.Number);
                }
                Console.WriteLine();
            }

            var kyril = HolderService.GetAllHolders().First(h => h.Name == "Kyril Siaukovich");

            var accNumber = kyril.GetAllAccounts().First().Number;
            service.CloseAccount(accNumber);

            accNumber = kyril.GetAllAccounts().ElementAt(1).Number;
            service.FrozeAccount(accNumber);

            var accounts = FakeRepository.Instance.GetAllBankAccounts();
            var zipped = accounts.Zip(Enumerable.Range(0, accounts.Count()), (acc, num) => new { Number = num, Account = acc });

            Console.WriteLine("All accounts:");
            foreach (var an in zipped)
            {
                Console.WriteLine(an.Number);
                Console.WriteLine($"\tHolder: {an.Account.Holder.Name}");
                Console.WriteLine($"\tStatus: {an.Account.Status}");
                Console.WriteLine($"\tNumber: {an.Account.Number}");
                Console.WriteLine();
            }

            service.UnfrozeAccount(accNumber);
            Console.WriteLine(FakeRepository.Instance.GetAccountByNumber(accNumber).Status);

            Console.ReadKey();
        }
    }
}
