﻿using Xunit;
using System;

namespace GameEngine.Tests
{
	[Trait("Category", "Enemy")]
	public class EnemyFactoryShould
	{
		//Type Check

		[Fact]
		public void CreateNormalEnemyByDefault()
		{
			EnemyFactory sut = new EnemyFactory();

			Enemy enemy = sut.Create("Zombie");

			Assert.IsType<NormalEnemy>(enemy);
		}


		[Fact(Skip = "Don't need to run this")]
		public void CreateNormalEnemyByDefault_NotTypeExample()
		{
			EnemyFactory sut = new EnemyFactory();

			Enemy enemy = sut.Create("Zombie");

			Assert.IsNotType<DateTime>(enemy);
		}

		[Fact]
		public void CreateBossEnemy()
		{
			EnemyFactory sut = new EnemyFactory();

			Enemy enemy = sut.Create("Zombie King", true);

			Assert.IsType<BossEnemy>(enemy);
		}

		//[Fact]
		//public void CreateBossEnemy_CastReturnedTypeExample()
		//{
		//	EnemyFactory sut = new EnemyFactory();

		//	Enemy enemy = sut.Create("Zombie");

		//	//Assert and get cast result
		//	BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

		//	//Additional asserts on typed object
		//	Assert.Equal("Zombie King", boss.Name);
		//}

		[Fact]
		public void CreateBossEnemy_AssertAssignableTypes()
		{
			EnemyFactory sut = new EnemyFactory();

			Enemy enemy = sut.Create("Zombie King", true);

			Assert.IsAssignableFrom<Enemy>(enemy);

		}

		[Fact]
		public void CreateSeparateInstances()
		{
			EnemyFactory sut = new EnemyFactory();

			Enemy enemy1 = sut.Create("Zombie");
			Enemy enemy2 = sut.Create("Zombie");

			//Check if two objects are not the same
			Assert.NotSame(enemy1, enemy2);
		}

		//Asserting that Code throws the Correct Exceptions
		[Fact]
		public void NotAllowNullName()
		{
			EnemyFactory sut = new EnemyFactory();

			//Assert.Throws<ArgumentNullException>(() => sut.Create(null));

			Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
		}

		[Fact]
		public void OnlyAllowKingOrQueenBossEnemies()
		{
			EnemyFactory sut = new EnemyFactory();

			EnemyCreationException ex =
				Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

			Assert.Equal("Zombie", ex.RequestedEnemyName);
		}
	}
}
