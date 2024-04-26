using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Tests
{
	public class NonPlayerCharacterShould
	{
		//Data-driven Tests

		/* Inline Data to test multiple data*/
		//[InlineData(0, 100)]
		//[InlineData(1, 99)]
		//[InlineData(50, 50)]
		//[InlineData(101, 1)]

		/* using csv data to test*/
		//[MemberData(nameof(ExternalHealthDamageTestData.TestData),
		//	MemberType = typeof(ExternalHealthDamageTestData))]

		/* using an internal class to test Data*/
		//[MemberData(nameof(InternalHealthDamageTestData.TestData),
		//	MemberType = typeof(InternalHealthDamageTestData))]

		/* Custom Data Attribute */
		[Theory]
		[HealthDamageData]

		public void TakeDamage(int damage, int expectedHealth)
		{
			NonPlayerCharacter _sut = new NonPlayerCharacter();

			_sut.TakeDamage(damage);

			Assert.Equal(expectedHealth, _sut.Health);
		}
	}
}
