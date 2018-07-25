using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class Program
    {
        public static int search(int accountId, List<BankAccount> accounts)        
        {
            int i = 0;
            foreach ( BankAccount account in accounts)
            {
                i++;
                if (account.AccountID == accountId)
                    return i;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int numberOfAccounts = Convert.ToInt32(Console.ReadLine());
            int accountID;
            double accountBalance;
            AccountHolder userDetails;
            List<BankAccount> accounts = new List<BankAccount>();
            for (int i=0; i<numberOfAccounts; i++)
            {
                Console.WriteLine("Enter The Details for {0} Account", i+1);
                Console.WriteLine("Account ID : ");
                accountID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Account Balance : ");
                accountBalance = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Account Holder's Name : ");
                userDetails.Name = Console.ReadLine();
                Console.WriteLine("Associated Phone Number : ");
                userDetails.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Associated Email Address : ");
                userDetails.EmailAddress = Console.ReadLine();
                Console.WriteLine("Account Type : ");
                Console.WriteLine("Enter 1 For CURRENT : ");
                Console.WriteLine("Enter 2 For SAVING : ");
                Console.WriteLine("Enter 3 for DMAT");
                int accountTypeIndex = Convert.ToInt32(Console.ReadLine())-1;
                accounts.Add(new BankAccount(accountID, (AccountType)accountTypeIndex, accountBalance, userDetails));
                
            }
            while(true)
            {
                Console.WriteLine("Enter the Account ID : ");
                accountID = Convert.ToInt32(Console.ReadLine());
                int index, choice;
                if((index = search(accountID, accounts))>=0)
                {
                    Console.WriteLine("1. Withdraw");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Interest");
                    Console.WriteLine("4. Display Details");
                    Console.WriteLine("5. Exit");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter The Amount To be Withdrawn : ");
                            double amountToBeWithdrawn = Convert.ToDouble(Console.ReadLine());
                            bool success;
                            double availableBalance = accounts[index].Withdraw(amountToBeWithdrawn,out success);
                            if (success)
                                Console.WriteLine("Transaction Successful! Your Available Balance is: {0}", availableBalance);
                            else
                                Console.WriteLine("Transaction Failed! Insufficient Balance!");
                            break;
                        case 2:
                            Console.WriteLine("Enter The Amount To Deposit: ");
                            double amountToDeposit = Convert.ToDouble(Console.ReadLine());
                            accounts[index].Deposit(amountToDeposit);
                            break;
                        case 3:
                            Console.WriteLine("Enter The Number Of Year : ");
                            int noOfYears = Convert.ToInt32(Console.ReadLine());
                            double interest;
                            interest = accounts[index].CalculateInterest(noOfYears);
                            break;
                        case 4:
                            accounts[index].DisplayAccountDetails();
                            break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid Account Details, Enter A valid Account Detail or Press 5 to exit!");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                if (choice == 5)
                {
                    break;
                }
            }
            
        }
    }
}
