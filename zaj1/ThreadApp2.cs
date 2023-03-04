using System;
using System.Threading;

namespace threads {
	class ThreadApp1 {

		int x = 0;

		void increase() {
			lock(this) {
				x = x+1;
				x = x+1;
			}
		}

		bool test() {
			lock(this) {
				return x % 2 == 0;
			}
		}

		void t1() {
			while(true) {
				increase();
			}
		}


		void t2() {
			while(true) {
				if (!test()) {
					Console.WriteLine("ERROR: " + x);
					throw new SystemException("shutdown!");
				}
	 		}
		}

		public static void Main() {
			ThreadApp1 c = new ThreadApp1();
			Thread t1 = new Thread(new ThreadStart(c.t1));
			Thread t2 = new Thread(new ThreadStart(c.t2));
			t1.Start();
			t2.Start();
		}
	}
}
