﻿using Char_Solution.Db_Context;
using Char_Solution.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        var user =  new SaveUser();
        user.Save();
        //Data.GetAll();


    }
}