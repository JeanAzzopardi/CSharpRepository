using System;
using System.Text;
using System.Collections;

namespace InfixToPostfix
{
	class MainClass
	{
		static String InfixToPostfix(String postfixString)
		{
			StringBuilder sb = new StringBuilder();
			Stack operatorStack = new Stack();
			Char[] operators = {'+','/','^','*','(',')'};
			
			foreach (char c in postfixString)
			{
				
				Boolean operatorBool = false;
				foreach (Char op in operators)
				{
					if (op == c)
					{
						operatorBool = true;
						break;	
					}
				}
				if (operatorBool)				
				{
					operatorStack.Push(c);
				}
				else (sb.Append(c));
				if (c == ')')
				{
					while ((char)operatorStack.Peek() != '(')
					{
						if ((char)operatorStack.Peek() != '(' && (char) operatorStack.Peek() != ')')
						sb.Append(operatorStack.Pop());
						else operatorStack.Pop();
					}
					operatorStack.Pop();
				}
			}
			return sb.ToString();
		
		}
		public static void Main(string[] args)
		{
			//InfixToPostfix("(a+(b*c))");
			int numberOfTestCases = Int32.Parse(System.Console.ReadLine());
			String[] testCases = new String[numberOfTestCases];
			for (int i = 0; i < numberOfTestCases; i++) testCases[i] = System.Console.ReadLine();
			for (int i = 0; i < numberOfTestCases; i++) System.Console.WriteLine(InfixToPostfix(testCases[i]));
			
		}
	}
}