using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_sandbox
{
	public interface IIntroductable
	{
		void Introduction();
	}

	public interface IFlyable
	{
		void Fly();
	}

	public interface IEating
	{
		void Eating();
	}

	public interface IMoving
	{
		void Move();
	}

	public interface IVocalize
	{
		void Vocalize();
	}

	public interface IParovozikThomas
	{
		void Chugga();
	}

	public abstract class Animal : IMoving, IEating, IIntroductable
	{
		protected string _name;

		public Animal(string name)
		{
			_name = name;
		}

		public virtual void Introduction()
		{
			Console.WriteLine($"{this.GetType().Name} {this._name}:");
		}

		public virtual void Move()
		{
			Console.WriteLine("I can jump!");
		}

		public virtual void Eating()
		{
			Console.WriteLine("Oh! My seeds and fruits!");
		}
	}

	public abstract class Bird : Animal, IFlyable
	{
		public Bird(string name) : base(name) { }

		public virtual void Fly()
		{
			Console.WriteLine("I believe, I can fly");
		}

	}

	public class Parrot : Bird, IVocalize, IParovozikThomas
	{
		public Parrot(string name) : base(name) { }

		public void Vocalize()
		{
			Console.WriteLine("Krya-Krya-Krya...");
		}

		public void Chugga()
		{
			Console.WriteLine("Chuh-Chuh-Chuh...");
		}
	}

	public class Sparrow : Bird
	{
		public Sparrow(string name) : base(name) { }

		public override void Eating()
		{
			Console.WriteLine("Oh! My corn!");
		}
	}

	public class Duck : Bird, IVocalize
	{
		public Duck(string name) : base(name) { }

		public override void Eating()
		{
			Console.WriteLine("Oh! My corn!");
		}

		public void Vocalize()
		{
			Console.WriteLine("Krya-Krya!");
		}

		public override void Move()
		{
			Console.WriteLine("I can swimm!");
		}
	}

	public class Cat : Animal, IVocalize
	{
		public Cat(string name) : base(name) { }

		public override void Eating()
		{
			Console.WriteLine("Oh! My milk");
		}

		public void Vocalize()
		{
			Console.WriteLine("Mrrr-Mrrr-Mrrr...");
		}
	}

	public class Program
	{
		public static void Main()
		{
			List<Animal> animals = new List<Animal>()
			{
				new Parrot("Leya"),
				new Sparrow("Sparry"),
				new Duck("McDuck"),
				new Cat("Tom")
			};

			foreach (var animal in animals)
			{
				
				animal.Introduction();

				PerformActions(animal);

				Console.WriteLine("");
			}
		}

		private static void PerformActions(Animal animal)
		{
			if (animal is IFlyable flyable)
			{
				flyable.Fly();
			}

			if (animal is IParovozikThomas parovozikThomas)
			{
				parovozikThomas.Chugga();
			}

			if (animal is IVocalize vocalize)
			{
				vocalize.Vocalize();
			}

			animal.Eating();
			animal.Move();
		}
	}
}
