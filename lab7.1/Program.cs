using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;

public class Test
{

	class Organisation : IComparable
	{

		public string name;
		public int number;
		public int rating;
		public int successRating;
		public int year;


		public Organisation()
		{
			name = "none";
			number = 10;
			rating = 5;
			successRating = sr();
			year = 2020;

		}

		public Organisation(string nm, int n, int r, int y)
		{
			name = nm;
			number = n;
			rating = r;
			successRating = sr();
			year = y;
		}

		public int sr()
		{
			if (rating <= 3)
			{
				return 1;
			}
			if (rating > 3 && rating <= 7)
			{
				return 2;
			}
			if (rating > 7 && rating <= 10)
			{
				return 3;
			}
			if (rating > 10 && rating <= 15)
			{
				return 4;
			}
			if (rating > 15)
			{
				return 5;
			}
			return 0;
		}

		public void print()
		{
			Console.WriteLine("Name: " + name);
			Console.WriteLine("Number: " + number);
			Console.WriteLine("Rating: " + rating);
			Console.WriteLine("SuccessRating: " + successRating);
			Console.WriteLine("Year: " + year);
			Console.WriteLine("-----------------------------");
		}

		public void IComparer(Organisation o2)
		{

			if (this.number == o2.number && this.successRating == o2.successRating)
			{
				Console.WriteLine("Organisation: " + this.name + " and Organisation: " + o2.name + " are compare.");
			}
			else
			{
				Console.WriteLine("Organisation: " + this.name + " and Organisation: " + o2.name + " are not compare!");
			}
		}


		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			Organisation otherOrganisation = obj as Organisation;

			if (otherOrganisation != null)
			{
				if (otherOrganisation.number == this.number)
				{
					Console.WriteLine("Number Organisation1 and Organisation2 are equal.");
				}
				return this.number.CompareTo(otherOrganisation.number);
			}
			else
			{
				throw new ArgumentException("Object is not a Organisation");
			}
		}

	}

	class Organisations : IEnumerable
	{

		protected int s;
		protected Organisation[] c;
		Random rnd = new Random();

		public Organisations()
		{
			s = 10;
			c = new Organisation[s];
			fc();
		}

		public Organisations(int size)
		{
			s = size;
			c = new Organisation[s];
			fc();
		}

		public Organisations(Organisation[] c)
		{
			this.c = c;
			s = c.Length;
		}

		void fc()
		{

			for (int i = 0; i < s; i++)
			{
				c[i] = new Organisation("none", 10, 2, 2020);
			}


		}

		public IEnumerator GetEnumerator()
		{
			return c.GetEnumerator();
		}

		public void print()
		{
			for (int i = 0; i < s; i++)
			{
				c[i].print();
			}
		}

	}



	public static void Main()
	{
		Organisation o1 = new Organisation("A", 100, 2, 2018);
		Organisation o2 = new Organisation("B", 100, 5, 2018);
		o1.IComparer(o2);
		int z = o1.CompareTo(o2);


		Organisations or1 = new Organisations();
		or1.print();
	}
}