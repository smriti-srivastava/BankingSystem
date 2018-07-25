using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{   
    struct AccountHolder
    {
        public string Name;
        public string PhoneNumber;
        public string EmailAddress;
    }

    public enum AccountType
    {
        CURRENT,
        SAVING,
        DMAT
    }

    class BankAccount
    {
        public int AccountID;
        private double AccountBalance;
        private double RateOfInterest;
        private double MinimumBalance;
        private AccountType TypeOfAccount;
        private AccountHolder AccountHoldersDetails;
        

        public BankAccount(int AccountID, AccountType TypeOfAccount,double Balance, AccountHolder AccountHoldersDetails)
        {
            this.AccountID = AccountID;
            this.TypeOfAccount = TypeOfAccount;
            this.AccountBalance = Balance;
            this.AccountHoldersDetails = AccountHoldersDetails;
        
            if (this.TypeOfAccount == AccountType.CURRENT)
            {
                this.RateOfInterest = 0.01D;
                this.MinimumBalance = 0.0D;
            }
            else if (this.TypeOfAccount == AccountType.SAVING)
            {
                this.RateOfInterest = 0.04D;
                this.MinimumBalance = 0.0D;
            }
            else if (this.TypeOfAccount == AccountType.DMAT)
            {
                this.RateOfInterest = 0.0D;
                this.MinimumBalance = -10000.0D;
            }
        }

        public double Withdraw(double withdrawAmount, out bool success)
        {
            if(withdrawAmount <=(this.AccountBalance-this.MinimumBalance)  )
            {
                this.AccountBalance =  this.AccountBalance - withdrawAmount;
                success = true;
            }
            else
            {
                success = false;
            }
            return this.AccountBalance;
        }

        public void Deposit(double DepositAmount)
        {
            this.AccountBalance += DepositAmount; 
        }

        public double CalculateInterest(int Years)
        {   
            return (this.AccountBalance * this.RateOfInterest * Years );
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("Account ID : {0} ", this.AccountID);
            if (this.TypeOfAccount == AccountType.SAVING)
                Console.WriteLine("Type Of Account : Saving");
            else if (this.TypeOfAccount == AccountType.CURRENT)
                Console.WriteLine("Type Of Account : Current");
            else if(this.TypeOfAccount == AccountType.DMAT)
                Console.WriteLine("Type Of Account : DMAT");
            Console.WriteLine("Available Balance : {0}", this.AccountBalance);
            Console.WriteLine("Account Holder's Name : {0}", this.AccountHoldersDetails.Name);
            Console.WriteLine("Associated Phone Number : {0}", this.AccountHoldersDetails.PhoneNumber);
            Console.WriteLine("Associated Email Address : {0}", this.AccountHoldersDetails.EmailAddress);
            
        }

    }
}
