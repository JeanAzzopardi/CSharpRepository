using System;

namespace MillerRabin
{
	class MillerRabinTest
	{
		
		
		static long modularExponent(long b, long exponent, long modulus)
		{
			long result = 1;		
    		while (exponent > 0) 
			{
        		if ((exponent & 1) == 1) 
				{
            		// multiply in this bit's contribution while using modulus to keep result small
            		result = (result * b) % modulus;
        		}
        		// move to the next bit of the exponent, square (and mod) the base accordingly
        		exponent >>= 1;
        		b = (b * b) % modulus;
			}
    	
    	return result;
		}

			
		
		
		/*
		 * <param name="n">An odd integer to be tested for primality</param>
		 * <param name="k">A parameter that determines the accuracy of the test</param>
		 * <returns>True if probably prime, False if composite.
		 */
		
		static Boolean isPrime(long n,int k)
		{
			int[] alist = {2,7,61};
			Random rnd = new Random();
			if (n == 2) return true;
			if ((n % 2) == 0) return false;
			if (n == 0) return false;
			if (n == 1) return false;
			if (n == 3) return true;
			long s = 0;
			long d = n - 1;
			while ((d % 2) == 0)
			{
				d /= 2;
				s++;
			}
			for (int i = 0; i < k; i++)
			{
				int j = rnd.Next(0,alist.Length);
				while (alist[j] > n - 2 ) j--;
				long a = alist[j];
				long x = modularExponent(a,d,n);
				if (x == 1 || x == (n - 1)) continue;
				bool cont = false;
				for (int r = 1; r <= s - 1; r++)
				{
					x = (x*x) % n;
					if (x == 1) return false;
					if (x == (n - 1)) { cont = true; break;}
				}
				if (!cont) return false;
			}
			return true;
						
		}
		
		public static void Main(string[] args)
		{
			//System.Console.WriteLine(Int32.MaxValue);
			
			int testcases = Int32.Parse(System.Console.ReadLine());
			int[] rangearray = new int[2*testcases];
			Boolean[] primes = GeneratePrimeNumberList();
			
				
			
			for (int i = 0; i < testcases; i++)
			{
				String s = System.Console.ReadLine();
				string[] split = s.Split(' ');
				rangearray[i*2] = Int32.Parse(split[0]);
				rangearray[(i*2)+1] = Int32.Parse(split[1]);
			}
			
			for (int i = 0; i < rangearray.Length; i+=2)
			{
				Boolean[] test = testPrimes(rangearray[i],rangearray[i+1],primes);

				for (int j = 0; j < test.Length; j++)
				{
					if (test[j]) Console.WriteLine(rangearray[i]+j);
				}
				//for (int j = rangearray[i]; j <= rangearray[i+1];j++)
				//{
					//Console.WriteLine("Testing {0}",j);
					//if (isPrime(j,5)) Console.WriteLine(j);
				//}
				Console.WriteLine();
			}
			
			
		}
		public static Boolean[] GeneratePrimeNumberList()
		{
			Boolean[] sieve = new Boolean[32000];
			for (int i = 0; i < sieve.Length; i++) sieve[i] = true;
			sieve[0] = false;
			sieve[1] = false;
			
			for (int i = 2; i < sieve.Length;i+=2)sieve[i]=false;
			sieve[2] = true;
						
			for (int i = 3; i < (int)Math.Sqrt(sieve.Length); i+=2)
			{
				if (sieve[i] == true)
				{
					for (int j = i*i;j < sieve.Length;j+=i)
					{
						sieve[j] = false;
					}
				}
			}
			return sieve;
		}
		
		public static Boolean[] testPrimes(int m, int n,Boolean[] primes)
		{
			
			Boolean[] testNumbers = new Boolean[n-m+1];
			
			for (int i = 0; i < testNumbers.Length; i++) testNumbers[i] = true;
			if (m == 1) testNumbers[0] = false;
			for (int i = 0; i <= (int)Math.Sqrt(n); i++)
			{
				//Console.WriteLine("in i loop {0}",i);
				//if (i > n) break;
				if (primes[i])
				{
					//System.Console.WriteLine("Test {0}",i);
					//999990000 999995000
					int firstj = (m%i) == 0 ? 0:i-(m%i);
					//Console.WriteLine("firstj = {0} length = {1} i = {2}",firstj,testNumbers.Length,i);
					if (firstj < testNumbers.Length)
					{
						testNumbers[firstj]=false;
						
						if ((m+firstj)==i) testNumbers[firstj]=true;
						firstj+=i;
						//System.Console.WriteLine("m%i = {0},firstj = {1}",m%i,firstj);
						for (int j = (firstj); j < testNumbers.Length; j+=i)
						{	
							//Console.WriteLine("in j loop");
							//System.Console.WriteLine("i = {0}, j = {1},m + j = {3},(m+j)%i) = {2} ",i,j,((m+j)%i),m+j);
						
							if ( ((m+j)%i) == 0) {
								testNumbers[j] = false;
								//Console.WriteLine("Setting {0} to false",j);
								}
							if ((m + j) == i) 
							{
								//Console.WriteLine("Setting {0} to true",m+j);
								testNumbers[j] = true;
								
							}
						}
					}
					//System.Console.ReadLine();
				}
			}
			return testNumbers;
		}
		
	}
}