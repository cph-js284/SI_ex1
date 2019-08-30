using System;

namespace server
{
    public class Bank
    {
        int[] Accounts;
        public Bank()
        {
            Accounts = new int[10];
        }

        public string DoBanking(int AccNo, int Amount){
            //yes - its a small bank
            if(AccNo > 9 || AccNo < 0){
                return "Invalid Accountnumber";
            }

            var currentAmount = Accounts[AccNo];
            if(currentAmount + Amount < 0){
                return "Insufficient funds";
            }else{
                Accounts[AccNo] += Amount;
                return "New balance: " + Accounts[AccNo];
            }
        }
    }
}