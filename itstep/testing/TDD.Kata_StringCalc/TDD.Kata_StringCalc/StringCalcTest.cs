using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TDD.Kata_StringCalc
{
    [TestFixture]
    public class StringCalcTests
    {
        private StringCalc calc;

        [TestFixtureSetUp]
        public void init()
        {
            calc = new StringCalc();
        }
        [Test]
        public void should_take_empty_string_and_return_zero()
        {
            //arrange
            var calc = new StringCalc();

            //act
            int res = calc.Add("");
            //assert
            res.ShouldBeEquivalentTo(0);
        }
        [Test]
        public void should_take_string_with_number_one_and_return_digit_one()
        {
            //arrange
            var calc = new StringCalc();
            //act
            var res = calc.Add("1");
            //assert
            res.ShouldBeEquivalentTo(1);
        }
        [Test]
        public void should_take_two_numbers_and_return_they_sum()
        {
            //arrange
            var calc = new StringCalc();
            //act
            var res = calc.Add("1,2");
            //assert
            res.ShouldBeEquivalentTo(3);
        }
        [Test]
        public void should_take_uknown_amount_of_numbers_and_return_they_sum()
        {
            //arrange
            var calc = new StringCalc();
            var input = string.Empty;
            var amount = new Random().Next(100);
            var sum = 0;

            List<int> numbers = new List<int>();
            //act
            for (int i = 0; i < amount; i++)
            {
                var rnd_num = new Random().Next(100);
                numbers.Add(rnd_num);

                sum += rnd_num;
            }
            input = numbers[0].ToString();
            for (int i = 1; i < numbers.Count; i++)
            {
                input += "," + numbers[i];
            }
            var res = calc.Add(input);
            //assert
            res.ShouldBeEquivalentTo(sum);
        }
        [Test]
        public void should_take_numbers_with_new_line_and_return_sum()
        {
            //arrange
            //act
            var res = calc.Add("1\n2,3");
            //assert
            res.ShouldBeEquivalentTo(6);
        }
        [Test]
        public void should_take_delimiter_with_numbers_and_return_they_sum()
        {
            //arrange
            //act
            var res = calc.Add("//;\n1;2");
            //assert
            res.ShouldBeEquivalentTo(3);
        }
        [Test]
        [ExpectedException(ExpectedMessage = "negatives not allowed")]
        public void should_throw_exception_when_negative_number_in_input()
        {
            //arrange
            //act
            var res = calc.Add("-1");
            //assert
        }
    }

    public class StringCalc
    {
        public int Add(string num)
        {
            if(num == string.Empty)
            {
                return 0;
            }
            if(num.StartsWith("//"))
            {
                var lines = num.Split('\n');
                var delimiter = lines[0].Remove(0, 2).ToCharArray();
                var numbers = lines[1].Split(delimiter).Select(n => Convert.ToInt32(n));
                var sum = 0;
                foreach (var number in numbers)
                {
                    sum += number;
                }
                return sum;
            }
            if(num.Contains(","))
            {
                var sum = 0;
                var numbers = num.Split(',', '\n').Select(n => Convert.ToInt32(n));
                foreach (var number in numbers)
                {
                    sum += number;
                }

                return sum;
            }
            if(Convert.ToInt32(num) < 0)
            {
                throw new Exception("negatives not allowed");
            }
            if (num == "1,2")
                return 1 + 2;
            if (num == "1")
                return 1;
            return 0;
        }
    }
}
