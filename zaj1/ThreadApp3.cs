using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads {

	class Program {
		static void Main(string[] args) {
			List<Client> q = new List<Client>();
			for	(int n =0; n <100; n++) {
				q.Add(new Client());
			}
			for	(int n = 0; n < 3; n++) {
				Clerk c = new Clerk(q);
				Thread t = new Thread(
					new ThreadStart(c.Work)
				);
				t.Start();
			}
		}
	}

	class Clerk {
		public int ID { get; private set; }
		private static int lastID = 1;
		private List<Client> q;
		private int servedClients = 0;

		public Clerk(List<Client> queue) {
			ID = lastID++;
			q = queue;
		}
		public void Serve(Client c) {
			c.taskToDo(this);
		}
		public void Work() {
			while (q.Count > 0) {
				Client c = null;
				lock (q) {
					c = q[0];
					q.Remove(c);
				}
				c.taskToDo(this);
				servedClients++;
			}
			Console.WriteLine("okienko" + ID + "Obsluguje" + servedClients);
		}
	}

	class Client {
		public int ID { get; private set; }
		static int lastId = 0;
		static Random rand = new Random();

		public Client() {
			ID = lastId++;
		}
		public void taskToDo(Clerk c) {
			Console.WriteLine(String.Format("Klient {0}: Podchodzę do okienka {1}", ID, c.ID));
			Thread.Sleep(rand.Next(10));
			Console.WriteLine(String.Format("Klient {0}: Odchodzę od okienka {1}", ID, c.ID));
		}
	}
}