using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using BasicKnowledge;


[TestFixture]
public class Tests
{
    //First test variables
    private List<object> list = new List<object> { 1, "one", 2, "two", "THREE", 3, 4, 5, 6, "sEvEn" };
    private List<int> expectedList = new List<int> { 1, 2, 3, 4, 5, 6 };
    //Second test variables
    private string str1 = "bbcccada";
    private char c1 = 'd';
    private string str2 = "bBcCcADa";
    private char c2 = 'D';
    //Third test variables
    private int int1 = 16;
    private int int2 = 493193;
    //Fourth test variables
    private int[] arr1 = { 6, 0, 1, 2, 1, 5 };
    private int[] arr2 = { 1, 3, 6, 2, 2, 0, 4, 5 };
    //Fifth test variables
    private string s1 = "Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
    private string s2 = "";
    private string s1_result = "(CORWILL, ALFRED)(CORWILL, FIRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
    //Seventh test variables
    private uint num1 = 2149583361;
    private uint num2 = 32;
    string num1_result = "128.32.10.1";
    string num2_result = "0.0.0.32";

    //Test functions
    private bool isRawListEmpty(List<object> list)
    {
        if (list.Count() == 0)
            return true;
        else
            return false;
    }

    private static bool isListsEqual<T>(List<T> list1, List<T> list2)
    {
        if (list1 == null || list2 == null)
        {
            return list1 == list2;
        }

        if (list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (!list1[i].Equals(list2[i]))
            {
                return false;
            }
        }

        return true;
    }

    private bool isStringAndCharEmpty(string str, char c)
    {
        return string.IsNullOrEmpty(str) && c == '\0';
    }

    private bool isCharsEqual(char c1, char c2)
    {
        return c1.Equals(c2);
    }

    private bool isIntegersEqual(int result, int expected)
    {
        if(result == expected)
            return true;
        else return false;
    }

    private bool isStringsEqual(string result, string expected)
    {
        if (result == expected)
            return true;
        else return false;
    }

    //Tests

    [Test]
    public void Task1CheckingForListEmptiness()
    {
        Assert.IsFalse(isRawListEmpty(list));
    }

    [Test]
    public void Task1CheckingForBehaviour()
    {
        Assert.IsTrue(isListsEqual(Task1.GetIntegersFromList(list), expectedList));
    }

    [Test]
    public void Task2CheckingForCorrectInput() 
    {
        Assert.IsFalse(isStringAndCharEmpty(str1, c1));
    }

    [Test]
    public void Task2CheckingForBehaviour()
    {
        Assert.IsTrue(isCharsEqual(Task2.FirstNonRepeatingLetter(str1), c1) || isCharsEqual(Task2.FirstNonRepeatingLetter(str2), c2));
    }

    [Test]
    public void Task3CheckingForBehaviour1()
    {
        Assert.IsTrue(isIntegersEqual(Task3.DigitalRoot(int1), 7));
    }

    [Test]
    public void Task3CheckingForBehaviour2()
    {
        Assert.IsTrue(isIntegersEqual(Task3.DigitalRoot(int2), 2));
    }

    [Test]
    public void Task4CheckingForBehaviour1()
    {
        Assert.IsTrue(isIntegersEqual(Task4.FindNumberOfPairs(arr1, 1), 2));
    }

    [Test]
    public void Task4CheckingForBehaviour2()
    {
        Assert.IsTrue(isIntegersEqual(Task4.FindNumberOfPairs(arr2, 5), 4));
    }

    [Test]
    public void Task5CheckingForBehaviour1()
    {
        Assert.IsTrue(isStringsEqual(Task5.InvitationList(s1), s1_result));
    }

    [Test]
    public void Task5CheckingForBehaviour2()
    {
        Assert.IsTrue(isStringsEqual(Task5.InvitationList(s2), "There is no guests"));
    }

    [Test]
    public void Task6CheckingForBehaviour1()
    {
        Assert.IsTrue(isIntegersEqual(Task6.NextBigger(531), -1));
    }

    [Test]
    public void Task6CheckingForBehaviour2()
    {
        Assert.IsTrue(isIntegersEqual(Task6.NextBigger(2017), 2071));
    }

    [Test]
    public void Task7CheckingForBehaviour1()
    {
        Assert.IsTrue(isStringsEqual(Task7.UIntToIPAddress(num1), num1_result));
    }

    [Test]
    public void Task7CheckingForBehaviour2()
    {
        Assert.IsTrue(isStringsEqual(Task7.UIntToIPAddress(num2), num2_result));
    }
}